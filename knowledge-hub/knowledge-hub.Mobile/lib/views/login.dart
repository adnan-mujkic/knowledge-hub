import 'dart:convert';
import 'package:flutter/material.dart';
import '../components/circularLoading.dart';
import '../models/loginRegister.dart';
import 'package:http/http.dart' as http;
import 'package:event/event.dart';
import '../services/accountService.dart';

class LoginWidget extends StatefulWidget {
  LoginWidget({Key? key}) : super(key: key){
    userLogin = new UserLogin();
  }

  late UserLogin userLogin;
  var openRegisterEvent = Event();
  var loginEvent = Event();

  @override
  LoginState createState() => LoginState();
}

class LoginState extends State<LoginWidget> {
  bool loading = false;
  bool showDialogue = false;
  String errorText = "There was an error contacting server";

  login() async {
    setState((){
      loading = true;
    });

    final response = await http.post(
      Uri.parse('http://192.168.1.103:5000/api/User/Login'),
      headers: <String, String>{
        'Content-Type' : 'application/json; charset=UTF-8',
      },
      body: jsonEncode(widget.userLogin.toJson()),
    );

    if(response.statusCode == 200){
      Map<String, dynamic> map = jsonDecode(response.body);
      debugPrint(response.body);

      if(map['message'] != null) {
        setState((){
          errorText = map['message'];
          showDialogue = true;
          loading = false;
        });
      }

      var as = AccountService.fromJson(map);
      AccountService.instance.userData = as.userData;
      AccountService.instance.authData = as.authData;
      AccountService.instance.addressData = as.addressData;
      AccountService.instance.paymentData = as.paymentData;
      AccountService.instance.myBooks = as.myBooks;
      AccountService.instance.wishlist = as.wishlist;
      AccountService.instance.cart = as.cart;
      AccountService.instance.saveFileToDisk();
      widget.loginEvent.broadcast();
    }else{
      setState((){
        showDialogue = true;
        loading = false;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          Center(
            child: SingleChildScrollView(
              child: Container(margin: EdgeInsets.only(top: 100, right: 30, left: 30),
                  child: Column(
                    children: [
                      Container(
                        margin: EdgeInsets.only(top: 10),
                        child: Text(
                          "Login",
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
                                    padding: EdgeInsets.only(top: 2, bottom: 2, right: 20, left: 20),
                                    child: TextField(
                                      decoration: InputDecoration(
                                          border: InputBorder.none,
                                          hintText: this.widget.userLogin.Email),
                                      style: const TextStyle(fontSize: 12),
                                      onChanged: (String value){
                                        this.widget.userLogin.Email = value;
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
                                    padding: EdgeInsets.only(top: 2, bottom: 2, right: 20, left: 20),
                                    child: TextField(
                                      obscureText: true,
                                      autocorrect: false,
                                      decoration: InputDecoration(
                                          border: InputBorder.none,),
                                      style: const TextStyle(fontSize: 12),
                                      onChanged: (String value){
                                        this.widget.userLogin.Password = value;
                                      },
                                    ),
                                  )),
                            ),
                          ],
                        ),
                      ),
                      Align(
                        alignment: Alignment.centerRight,
                        child: TextButton(
                          onPressed: () {},
                          child: Text("Forgot Password?"),
                        ),
                      ),
                      const SizedBox(
                        height: 20,
                      ),
                      SizedBox(
                        width: double.infinity,
                        child: ElevatedButton(
                            style: ButtonStyle(
                                backgroundColor: MaterialStateProperty.all<Color>(Colors.green),
                                shape: MaterialStateProperty.all<RoundedRectangleBorder>(
                                    RoundedRectangleBorder(
                                        borderRadius: BorderRadius.circular(10)
                                    )
                                )
                            ),
                            onPressed: () {
                              login();
                            },
                            child: Padding(
                              padding: EdgeInsets.all(15),
                              child: Text("Login"),
                            )
                        ),
                      ),
                      const SizedBox(
                        height: 50,
                      ),
                      Align(
                        alignment: Alignment.center,
                        child: TextButton(
                          onPressed: () {
                            widget.openRegisterEvent.broadcast();
                          },
                          child: Text("Register"),
                        ),
                      ),
                    ],
                  )),
            )
          ),
          loading? CircularLoadingWidget("Logging in...") : Container(),
          showDialogue? Container(
            width: double.infinity,
            height: double.infinity,
            color: Colors.black.withOpacity(0.7),
            child: Center(
              child: AlertDialog(
                content: Text(errorText),
                actions: [
                  TextButton(
                    onPressed: (){
                      setState((){
                        showDialogue = false;
                      });
                    },
                    child: const Text("Ok"),
                  )
                ],
              ),
            ),
          ) : Container()
        ],
      )
    );
  }
}
