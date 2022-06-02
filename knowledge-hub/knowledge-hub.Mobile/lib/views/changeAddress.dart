import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/models/address.dart';
import 'package:knowledge_hub_mobile/models/changePassword.dart';
import 'package:knowledge_hub_mobile/models/user.dart';
import '../models/order.dart';
import 'package:event/event.dart';

import '../models/paymentInfo.dart';

class ChangeAddressWidget extends StatefulWidget {
  ChangeAddressWidget({Key? key}) : super(key: key){
    userAddress = new Address();
    userAddress.FullName = "Adnan Mujkic";
    userAddress.AdressLine = "Kneza Viseslava 69";
    userAddress.City = "Mostar";
    userAddress.Postcode = "0000";
  }

  late Address userAddress;

  @override
  ChangeAddressState createState() => ChangeAddressState();
}

class ChangeAddressState extends State<ChangeAddressWidget> {
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
                  "Address",
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
                      child: Text("Full Name:"),
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
                                  hintText: this.widget.userAddress.FullName),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String? value){
                                this.widget.userAddress.FullName = value;
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
                      child: Text("Address Line:"),
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
                                  hintText: this.widget.userAddress.AdressLine),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String? value){
                                this.widget.userAddress.AdressLine = value;
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
                      child: Text("City:"),
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
                                  hintText: this.widget.userAddress.City),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String? value){
                                this.widget.userAddress.City = value;
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
                      child: Text("Postcode:"),
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
                                  hintText: this.widget.userAddress.Postcode),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String? value){
                                this.widget.userAddress.Postcode = value;
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
