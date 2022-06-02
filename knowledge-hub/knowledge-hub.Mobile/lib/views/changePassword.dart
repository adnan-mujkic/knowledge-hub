import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/models/changePassword.dart';
import 'package:knowledge_hub_mobile/models/user.dart';
import '../models/order.dart';
import 'package:event/event.dart';

class ChangePasswordWidget extends StatefulWidget {
  ChangePasswordWidget({Key? key}) : super(key: key){
    userPassword = new ChangePassword();
  }

  late ChangePassword userPassword;

  @override
  ChangePasswordState createState() => ChangePasswordState();
}

class ChangePasswordState extends State<ChangePasswordWidget> {
  @override
  Widget build(BuildContext context) {
    return Align(
      alignment: Alignment.bottomCenter,
      child: Container(margin: EdgeInsets.only(top: 10, right: 30, left: 30),
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
              const Divider(
                height: 30,
                thickness: 2,
                indent: 60,
                endIndent: 60,
                color: Color.fromARGB(20, 0, 0, 0),
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
                            padding: EdgeInsets.only(top: 2, bottom: 2, right: 20, left: 20),
                            child: TextField(
                              decoration: InputDecoration(
                                  border: InputBorder.none,
                                  hintText: this.widget.userPassword.OldPassword),
                              style: const TextStyle(fontSize: 12),
                                onChanged: (String? value){
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
                            padding: EdgeInsets.only(top: 2, bottom: 2, right: 20, left: 20),
                            child: TextField(
                              decoration: InputDecoration(
                                  border: InputBorder.none,
                                  hintText: this.widget.userPassword.NewPassword),
                              style: const TextStyle(fontSize: 12),
                                onChanged: (String? value){
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
                            padding: EdgeInsets.only(top: 2, bottom: 2, right: 20, left: 20),
                            child: TextField(
                              decoration: InputDecoration(
                                  border: InputBorder.none,
                                  hintText: this.widget.userPassword.ConfirmPassword),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String? value){
                                this.widget.userPassword.ConfirmPassword = value;
                              },
                            ),
                          )),
                    ),
                  ],
                ),
              ),
              ElevatedButton(
                  style: ButtonStyle(
                      backgroundColor: MaterialStateProperty.all<Color>(Colors.green)
                  ),
                  onPressed: () => {},
                  child: Text("Change Password")
              ),
            ],
          )),
    );
  }
}
