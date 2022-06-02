import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/models/changePassword.dart';
import 'package:knowledge_hub_mobile/models/user.dart';
import '../models/order.dart';
import 'package:event/event.dart';

import '../models/paymentInfo.dart';

class ChangePaymentInfoWidget extends StatefulWidget {
  ChangePaymentInfoWidget({Key? key}) : super(key: key){
    userPaymentInfo = new PaymentInfo();
    userPaymentInfo.CardHolder = "Adnan Mujkic";
    userPaymentInfo.CardNumber = "0000 0000 0000 0000";
    userPaymentInfo.ExpiryDate = "02/22";
    userPaymentInfo.CVC = "987";
  }

  late PaymentInfo userPaymentInfo;

  @override
  ChangePaymentInfoState createState() => ChangePaymentInfoState();
}

class ChangePaymentInfoState extends State<ChangePaymentInfoWidget> {
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
                  "Payment Info",
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
                      child: Text("Card Holder:"),
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
                                  hintText: this.widget.userPaymentInfo.CardHolder),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String? value){
                                this.widget.userPaymentInfo.CardHolder = value;
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
                      child: Text("CardNumber:"),
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
                                  hintText: this.widget.userPaymentInfo.CardNumber),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String? value){
                                this.widget.userPaymentInfo.CardNumber = value;
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
                      child: Text("Expiry Date:"),
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
                                  hintText: this.widget.userPaymentInfo.ExpiryDate),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String? value){
                                this.widget.userPaymentInfo.ExpiryDate = value;
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
                      child: Text("CVC:"),
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
                                  hintText: this.widget.userPaymentInfo.CVC),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String? value){
                                this.widget.userPaymentInfo.CVC = value;
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
