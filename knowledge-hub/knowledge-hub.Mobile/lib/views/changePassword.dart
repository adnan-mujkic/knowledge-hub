import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/models/changePassword.dart';
import 'package:knowledge_hub_mobile/models/user.dart';
import 'package:knowledge_hub_mobile/validationHelper.dart';
import '../models/order.dart';
import 'package:http/http.dart' as http;
import 'package:event/event.dart';
import '../services/persistentDataService.dart';
import '../services/accountService.dart';

class ChangePasswordWidget extends StatefulWidget {
  ChangePasswordWidget({Key? key}) : super(key: key) {
    userPassword = new ChangePassword();
  }

  late ChangePassword userPassword;

  @override
  ChangePasswordState createState() => ChangePasswordState();
}

class ChangePasswordState extends State<ChangePasswordWidget> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  changePassword() async {
    final FormState? form = _formKey.currentState;
    if (form == null || !form.validate()) {
      return;
    }

    if (widget.userPassword.NewPassword! !=
        widget.userPassword.ConfirmPassword!) {
      PersistentDataService.instance.screenWideNotification
          .broadcast(Value<String>("Passwords do not match!"));
      return;
    }

    final response = await http.put(
      Uri.parse(
          '${PersistentDataService.instance.BackendUri}/api/User/UpdatePassword'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
        'Authorization':
            "Basic ${base64Encode(utf8.encode('${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}'))}"
      },
      body: jsonEncode({
        'userId': AccountService.instance.userData.UserId,
        'oldPassword': widget.userPassword.OldPassword,
        'newPassword': widget.userPassword.NewPassword,
        'confirmPassword': widget.userPassword.ConfirmPassword,
      }),
    );

    if (response.statusCode == 200) {
      AccountService.instance.authData.Password =
          widget.userPassword.NewPassword ?? "";
      AccountService.instance.saveFileToDisk();
      PersistentDataService.instance.screenWideNotification
          .broadcast(Value<String>("Password Chagned!"));
    }
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Align(
        alignment: Alignment.bottomCenter,
        child: Container(
            margin: EdgeInsets.only(top: 10, right: 30, left: 30),
            child: Form(
              key: _formKey,
              child: Column(
                children: [
                  Container(
                    margin: EdgeInsets.only(top: 10),
                    child: Text(
                      "Privacy",
                      style: TextStyle(
                          fontSize: 24,
                          fontWeight: FontWeight.bold,
                          color: Colors.blueGrey),
                    ),
                  ),
                  const SizedBox(
                    height: 20,
                  ),
                  Container(
                    margin: EdgeInsets.only(top: 10, bottom: 10),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Container(
                          margin: EdgeInsets.only(left: 10),
                          child: Text("Old Password:"),
                        ),
                        Container(
                          margin: const EdgeInsets.only(top: 10),
                          decoration: BoxDecoration(
                            borderRadius: BorderRadius.circular(50),
                            color: Color.fromARGB(10, 0, 0, 0),
                          ),
                          child: SizedBox(
                              child: Padding(
                            padding: EdgeInsets.only(
                                top: 2, bottom: 2, right: 20, left: 20),
                            child: TextFormField(
                              validator: emptyValidation,
                              autocorrect: false,
                              obscureText: true,
                              decoration: InputDecoration(
                                border: InputBorder.none,
                              ),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String? value) {
                                this.widget.userPassword.OldPassword = value;
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
                          child: Text("New Password:"),
                        ),
                        Container(
                          margin: const EdgeInsets.only(top: 10),
                          decoration: BoxDecoration(
                            borderRadius: BorderRadius.circular(50),
                            color: Color.fromARGB(10, 0, 0, 0),
                          ),
                          child: SizedBox(
                              child: Padding(
                            padding: EdgeInsets.only(
                                top: 2, bottom: 2, right: 20, left: 20),
                            child: TextFormField(
                              validator: passwordValidation,
                              autocorrect: false,
                              obscureText: true,
                              decoration: InputDecoration(
                                border: InputBorder.none,
                              ),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String? value) {
                                this.widget.userPassword.NewPassword = value;
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
                            borderRadius: BorderRadius.circular(20),
                            color: Color.fromARGB(10, 0, 0, 0),
                          ),
                          child: SizedBox(
                              child: Padding(
                            padding: EdgeInsets.only(
                                top: 2, bottom: 2, right: 20, left: 20),
                            child: TextFormField(
                              validator: passwordValidation,
                              autocorrect: false,
                              obscureText: true,
                              decoration: InputDecoration(
                                border: InputBorder.none,
                              ),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String? value) {
                                this.widget.userPassword.ConfirmPassword =
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
                                MaterialStateProperty.all<Color>(Colors.green),
                            shape: MaterialStateProperty.all<
                                    RoundedRectangleBorder>(
                                RoundedRectangleBorder(
                                    borderRadius: BorderRadius.circular(10)))),
                        onPressed: () {
                          changePassword();
                        },
                        child: Padding(
                          padding: EdgeInsets.all(15),
                          child: Text("Save"),
                        )),
                  ),
                ],
              ),
            )),
      ),
    );
  }
}
