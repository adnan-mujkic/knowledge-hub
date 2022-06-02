import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/models/user.dart';
import '../models/order.dart';
import 'package:event/event.dart';

class UserManagmentWidget extends StatefulWidget {
  UserManagmentWidget(User newUser, {Key? key}) : super(key: key){
    user = newUser;
  }

  late User user;

  @override
  UserManagmentState createState() => UserManagmentState();
}

class UserManagmentState extends State<UserManagmentWidget> {
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
                  "Account",
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
                      child: Text("Username:"),
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
                                  hintText: this.widget.user.Username),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String value){
                                this.widget.user.Username = value;
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
                      child: Text("Email:"),
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
                                  hintText: this.widget.user.Email),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String value){
                                this.widget.user.Email = value;
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
                      decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(20),
                        color: Color.fromARGB(10, 0, 0, 0),
                      ),
                      child: SizedBox(
                          child: Padding(
                            padding: EdgeInsets.only(top: 2, bottom: 2, right: 20, left: 20),
                            child: TextField(
                              maxLines: 10,
                              decoration: InputDecoration(
                                  border: InputBorder.none,
                                  hintText: this.widget.user.Biography),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String value){
                                this.widget.user.Biography = value;
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
                  child: Text("Save")
              ),
            ],
          )),
        );
  }
}
