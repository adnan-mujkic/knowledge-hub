import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/models/user.dart';
import 'package:http/http.dart' as http;
import 'package:knowledge_hub_mobile/services/accountService.dart';

class UserManagmentWidget extends StatefulWidget {
  UserManagmentWidget({Key? key}) : super(key: key){
    username = AccountService.instance.userData.Username;
    biography = AccountService.instance.userData.Biography;
  }

  late String username;
  late String biography;

  @override
  UserManagmentState createState() => UserManagmentState();
}

class UserManagmentState extends State<UserManagmentWidget> {

  saveAccountSettings()async{
    final response = await http.put(
      Uri.parse('http://192.168.1.103:5000/api/User?ID=${AccountService.instance.userData.UserId.toString()}'),
      headers: <String, String>{
        'Content-Type' : 'application/json; charset=UTF-8',
        'Authorization' : "Basic ${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}"
      },
      body: jsonEncode({
        'username' : widget.username,
        'biography': widget.biography,
        'imagePath' : ''
      }),
    );

    if(response.statusCode == 200){
      Map<String, dynamic> map = jsonDecode(response.body);
      AccountService.instance.userData.Username = map['username']??"";
      AccountService.instance.userData.Biography = map['biography']??"";
      AccountService.instance.saveFileToDisk();
    }
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Align(
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
                                    hintText: this.widget.username),
                                style: const TextStyle(fontSize: 12),
                                onChanged: (String value){
                                  this.widget.username = value;
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
                                    hintText: this.widget.biography),
                                style: const TextStyle(fontSize: 12),
                                onChanged: (String value){
                                  this.widget.biography = value;
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
                          backgroundColor: MaterialStateProperty.all<Color>(Colors.green),
                          shape: MaterialStateProperty.all<RoundedRectangleBorder>(
                              RoundedRectangleBorder(
                                  borderRadius: BorderRadius.circular(10)
                              )
                          )
                      ),
                      onPressed: () {
                        saveAccountSettings();
                      },
                      child: Padding(
                        padding: EdgeInsets.all(15),
                        child: Text("Save"),
                      )
                  ),
                ),
              ],
            )),
      ),
    );
  }
}
