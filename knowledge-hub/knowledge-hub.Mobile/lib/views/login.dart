import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/models/user.dart';
import '../models/loginRegister.dart';
import '../models/order.dart';
import 'package:event/event.dart';

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
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
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
                                decoration: InputDecoration(
                                    border: InputBorder.none,
                                    hintText: this.widget.userLogin.Password),
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
                        widget.loginEvent.broadcast();
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
      ),
    );
  }
}
