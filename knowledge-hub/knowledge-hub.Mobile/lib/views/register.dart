import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/components/circularLoading.dart';
import 'package:knowledge_hub_mobile/models/requests/userRegistrationRequest.dart';
import 'package:knowledge_hub_mobile/validationHelper.dart';
import '../models/loginRegister.dart';
import 'package:event/event.dart';
import 'package:http/http.dart' as http;
import '../services/persistentDataService.dart';

class RegisterWidget extends StatefulWidget {
  RegisterWidget({Key? key}) : super(key: key) {
    userRegister = new Register();
  }

  late Register userRegister;
  var userRegistration =
      UserRegistrationRequest(Username: "", Biography: "", LoginId: 0);
  var openLoginEvent = Event();
  var createAccountEvent = Event<Values<String, String>>();

  @override
  RegisterState createState() => RegisterState();
}

class RegisterState extends State<RegisterWidget> {
  bool loading = false;
  bool loginOrUserRegistration = true;
  bool showDialogue = false;
  String errorText = "There was an error contacting server";
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  switchLoading(bool on) {
    setState(() {
      loading = on;
    });
  }

  registerToSite() async {
    final FormState? form = _formKey.currentState;
    if (form == null || !form.validate()) {
      return;
    }
    switchLoading(true);
    final response = await http.post(
      Uri.parse(
          '${PersistentDataService.instance.BackendUri}/api/User/Register'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(widget.userRegister.toJson()),
    );
    //switchLoading(false);
    if (response.statusCode == 200) {
      Map<String, dynamic> map = jsonDecode(response.body);

      debugPrint(map['message']);
      if (map['message'] != null) {
        setState(() {
          errorText = map['message'];
          showDialogue = true;
          loading = false;
        });
      }

      widget.userRegistration.LoginId = map['loginId'];
      setState(() {
        loading = false;
        loginOrUserRegistration = false;
      });
    } else if (response.statusCode == 400) {
      setState(() {
        errorText = "Error registering!";
        loading = false;
        showDialogue = true;
      });
    } else {
      setState(() {
        errorText = "Error contacting server!";
        loading = false;
        showDialogue = true;
      });
    }
  }

  createAccount() async {
    switchLoading(true);
    final response = await http.post(
      Uri.parse(
          '${PersistentDataService.instance.BackendUri}/api/User/RegisterUser'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(widget.userRegistration.toJson()),
    );

    if (response.statusCode == 200) {
      widget.createAccountEvent.broadcast(Values<String, String>(
          widget.userRegister.Email!, widget.userRegister.Password!));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          loginOrUserRegistration
              ? Center(
                  child: SingleChildScrollView(
                  child: Container(
                      margin: EdgeInsets.only(top: 10, right: 30, left: 30),
                      child: Form(
                        key: _formKey,
                        child: Column(
                          children: [
                            Container(
                              margin: EdgeInsets.only(top: 10),
                              child: Text(
                                "Register",
                                style: TextStyle(
                                    fontSize: 24,
                                    fontWeight: FontWeight.bold,
                                    color: Colors.blueGrey),
                              ),
                            ),
                            const SizedBox(
                              height: 50,
                            ),
                            Container(
                              margin: EdgeInsets.only(top: 10, bottom: 10),
                              child: Column(
                                crossAxisAlignment: CrossAxisAlignment.start,
                                children: [
                                  Container(
                                    margin: EdgeInsets.only(left: 10),
                                    child: Text("Email:"),
                                  ),
                                  Container(
                                    margin: const EdgeInsets.only(top: 10),
                                    decoration: BoxDecoration(
                                      borderRadius: BorderRadius.circular(10),
                                      color: Color.fromARGB(10, 0, 0, 0),
                                    ),
                                    child: SizedBox(
                                        child: Padding(
                                      padding: EdgeInsets.only(
                                          top: 2,
                                          bottom: 2,
                                          right: 20,
                                          left: 20),
                                      child: TextFormField(
                                        validator: emailValidation,
                                        decoration: InputDecoration(
                                            border: InputBorder.none,
                                            hintText:
                                                this.widget.userRegister.Email),
                                        onChanged: (String value) {
                                          this.widget.userRegister.Email =
                                              value;
                                        },
                                      ),
                                    )),
                                  ),
                                ],
                              ),
                            ),
                            Container(
                              margin: EdgeInsets.only(top: 10, bottom: 10),
                              child: Column(
                                crossAxisAlignment: CrossAxisAlignment.start,
                                children: [
                                  Container(
                                    margin: EdgeInsets.only(left: 10),
                                    child: Text("Password:"),
                                  ),
                                  Container(
                                    margin: const EdgeInsets.only(top: 10),
                                    decoration: BoxDecoration(
                                      borderRadius: BorderRadius.circular(10),
                                      color: Color.fromARGB(10, 0, 0, 0),
                                    ),
                                    child: SizedBox(
                                        child: Padding(
                                      padding: EdgeInsets.only(
                                          top: 2,
                                          bottom: 2,
                                          right: 20,
                                          left: 20),
                                      child: TextFormField(
                                        validator: passwordValidation,
                                        decoration: InputDecoration(
                                            border: InputBorder.none,
                                            hintText: this
                                                .widget
                                                .userRegister
                                                .Password),
                                        onChanged: (String value) {
                                          this.widget.userRegister.Password =
                                              value;
                                        },
                                      ),
                                    )),
                                  ),
                                ],
                              ),
                            ),
                            Container(
                              margin: EdgeInsets.only(top: 10, bottom: 10),
                              child: Column(
                                crossAxisAlignment: CrossAxisAlignment.start,
                                children: [
                                  Container(
                                    margin: EdgeInsets.only(left: 10),
                                    child: Text("Confirm Password:"),
                                  ),
                                  Container(
                                    margin: const EdgeInsets.only(top: 10),
                                    decoration: BoxDecoration(
                                      borderRadius: BorderRadius.circular(10),
                                      color: Color.fromARGB(10, 0, 0, 0),
                                    ),
                                    child: SizedBox(
                                        child: Padding(
                                      padding: EdgeInsets.only(
                                          top: 2,
                                          bottom: 2,
                                          right: 20,
                                          left: 20),
                                      child: TextFormField(
                                        validator: passwordValidation,
                                        decoration: InputDecoration(
                                            border: InputBorder.none,
                                            hintText: this
                                                .widget
                                                .userRegister
                                                .ConfirmPassword),
                                        onChanged: (String value) {
                                          this
                                              .widget
                                              .userRegister
                                              .ConfirmPassword = value;
                                        },
                                      ),
                                    )),
                                  ),
                                ],
                              ),
                            ),
                            const SizedBox(
                              height: 20,
                            ),
                            SizedBox(
                              width: double.infinity,
                              child: ElevatedButton(
                                  style: ButtonStyle(
                                      backgroundColor:
                                          MaterialStateProperty.all<Color>(
                                              Colors.green),
                                      shape: MaterialStateProperty.all<
                                              RoundedRectangleBorder>(
                                          RoundedRectangleBorder(
                                              borderRadius:
                                                  BorderRadius.circular(10)))),
                                  onPressed: () => {registerToSite()},
                                  child: Padding(
                                    padding: EdgeInsets.all(15),
                                    child: Text("Register"),
                                  )),
                            ),
                            const SizedBox(
                              height: 50,
                            ),
                            TextButton(
                              onPressed: () {
                                widget.openLoginEvent.broadcast();
                              },
                              child: Text("Login"),
                            )
                          ],
                        ),
                      )),
                ))
              : Center(
                  child: SingleChildScrollView(
                  child: Container(
                      margin: EdgeInsets.only(top: 10, right: 30, left: 30),
                      child: Column(
                        children: [
                          Container(
                            margin: EdgeInsets.only(top: 10),
                            child: Text(
                              "Create Account",
                              style: TextStyle(
                                  fontSize: 24,
                                  fontWeight: FontWeight.bold,
                                  color: Colors.blueGrey),
                            ),
                          ),
                          const SizedBox(
                            height: 50,
                          ),
                          Container(
                            margin: EdgeInsets.only(top: 10, bottom: 10),
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Container(
                                  margin: EdgeInsets.only(left: 10),
                                  child: Text("Username:"),
                                ),
                                Container(
                                  margin: const EdgeInsets.only(top: 10),
                                  decoration: BoxDecoration(
                                    borderRadius: BorderRadius.circular(10),
                                    color: Color.fromARGB(10, 0, 0, 0),
                                  ),
                                  child: SizedBox(
                                      child: Padding(
                                    padding: EdgeInsets.only(
                                        top: 2, bottom: 2, right: 20, left: 20),
                                    child: TextField(
                                      decoration: InputDecoration(
                                          border: InputBorder.none,
                                          hintText: this
                                              .widget
                                              .userRegistration
                                              .Username),
                                      style: const TextStyle(fontSize: 12),
                                      onChanged: (String value) {
                                        this.widget.userRegistration.Username =
                                            value;
                                      },
                                    ),
                                  )),
                                ),
                              ],
                            ),
                          ),
                          Container(
                            margin: EdgeInsets.only(top: 10, bottom: 10),
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Container(
                                  margin: EdgeInsets.only(left: 10),
                                  child: Text("Biography:"),
                                ),
                                Container(
                                  margin: const EdgeInsets.only(top: 10),
                                  height: 100,
                                  decoration: BoxDecoration(
                                    borderRadius: BorderRadius.circular(10),
                                    color: Color.fromARGB(10, 0, 0, 0),
                                  ),
                                  child: SizedBox(
                                      child: Padding(
                                    padding: EdgeInsets.only(
                                        top: 2, bottom: 2, right: 20, left: 20),
                                    child: TextField(
                                      decoration: InputDecoration(
                                          border: InputBorder.none,
                                          hintText: this
                                              .widget
                                              .userRegistration
                                              .Biography),
                                      style: const TextStyle(fontSize: 12),
                                      onChanged: (String value) {
                                        this.widget.userRegistration.Biography =
                                            value;
                                      },
                                    ),
                                  )),
                                ),
                              ],
                            ),
                          ),
                          const SizedBox(
                            height: 20,
                          ),
                          SizedBox(
                            width: double.infinity,
                            child: ElevatedButton(
                                style: ButtonStyle(
                                    backgroundColor:
                                        MaterialStateProperty.all<Color>(
                                            Colors.green),
                                    shape: MaterialStateProperty.all<
                                            RoundedRectangleBorder>(
                                        RoundedRectangleBorder(
                                            borderRadius:
                                                BorderRadius.circular(10)))),
                                onPressed: () => {createAccount()},
                                child: Padding(
                                  padding: EdgeInsets.all(15),
                                  child: Text("Create"),
                                )),
                          ),
                        ],
                      )),
                )),
          loading ? CircularLoadingWidget("Registering...") : Container(),
          showDialogue
              ? Container(
                  width: double.infinity,
                  height: double.infinity,
                  color: Colors.black.withOpacity(0.7),
                  child: Center(
                    child: AlertDialog(
                      content: Text(errorText),
                      actions: [
                        TextButton(
                          onPressed: () {
                            setState(() {
                              showDialogue = false;
                            });
                          },
                          child: const Text("Ok"),
                        )
                      ],
                    ),
                  ),
                )
              : Container()
        ],
      ),
    );
  }
}
