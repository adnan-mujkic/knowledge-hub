import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:event/event.dart';
import 'package:knowledge_hub_mobile/services/accountService.dart';
import '../services/persistentDataService.dart';
import '../models/paymentInfo.dart';

class ChangePaymentInfoWidget extends StatefulWidget {
  ChangePaymentInfoWidget({Key? key}) : super(key: key) {
    userPaymentInfo = AccountService.instance.paymentData;
  }

  late PaymentInfo userPaymentInfo;
  var saveChangesEvent = Event();

  @override
  ChangePaymentInfoState createState() => ChangePaymentInfoState();
}

class ChangePaymentInfoState extends State<ChangePaymentInfoWidget> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  savePaymentInfo() async {
    final FormState? form = _formKey.currentState;
    if (form == null || !form.validate()) {
      return;
    }
    final response = await http.post(
      Uri.parse(
          '${PersistentDataService.instance.BackendUri}/api/User/UpdatePayment'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
        'Authorization':
            "Basic ${base64Encode(utf8.encode('${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}'))}"
      },
      body: jsonEncode({
        'userId': AccountService.instance.userData.UserId,
        'fullName': widget.userPaymentInfo.CardHolder,
        'cardNumber': widget.userPaymentInfo.CardNumber,
        'date': widget.userPaymentInfo.ExpiryDate,
        'cvc': widget.userPaymentInfo.CVC
      }),
    );

    if (response.statusCode == 200) {
      Map<String, dynamic> map = jsonDecode(response.body);
      AccountService.instance.paymentData = PaymentInfo.fromJson(map);
      AccountService.instance.saveFileToDisk();
    }
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Align(
        alignment: Alignment.bottomCenter,
        child: Container(
            margin: EdgeInsets.only(top: 10, right: 30, left: 30),
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
                          padding: EdgeInsets.only(
                              top: 0, bottom: 0, right: 20, left: 20),
                          child: TextField(
                            decoration: InputDecoration(
                                border: InputBorder.none,
                                hintText:
                                    this.widget.userPaymentInfo.CardHolder),
                            style: const TextStyle(fontSize: 12),
                            onChanged: (String? value) {
                              this.widget.userPaymentInfo.CardHolder = value!;
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
                          padding: EdgeInsets.only(
                              top: 0, bottom: 0, right: 20, left: 20),
                          child: TextField(
                            decoration: InputDecoration(
                                border: InputBorder.none,
                                hintText:
                                    this.widget.userPaymentInfo.CardNumber),
                            style: const TextStyle(fontSize: 12),
                            onChanged: (String? value) {
                              this.widget.userPaymentInfo.CardNumber = value!;
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
                          padding: EdgeInsets.only(
                              top: 0, bottom: 0, right: 20, left: 20),
                          child: TextField(
                            decoration: InputDecoration(
                                border: InputBorder.none,
                                hintText:
                                    this.widget.userPaymentInfo.ExpiryDate),
                            style: const TextStyle(fontSize: 12),
                            onChanged: (String? value) {
                              this.widget.userPaymentInfo.ExpiryDate = value!;
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
                          padding: EdgeInsets.only(
                              top: 0, bottom: 0, right: 20, left: 20),
                          child: TextField(
                            decoration: InputDecoration(
                                border: InputBorder.none,
                                hintText: this.widget.userPaymentInfo.CVC),
                            style: const TextStyle(fontSize: 12),
                            onChanged: (String? value) {
                              this.widget.userPaymentInfo.CVC = value!;
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
                          shape:
                              MaterialStateProperty.all<RoundedRectangleBorder>(
                                  RoundedRectangleBorder(
                                      borderRadius:
                                          BorderRadius.circular(10)))),
                      onPressed: () {
                        savePaymentInfo();
                        widget.saveChangesEvent.broadcast();
                      },
                      child: Padding(
                        padding: EdgeInsets.all(15),
                        child: Text("Save"),
                      )),
                ),
              ],
            )),
      ),
    );
  }
}
