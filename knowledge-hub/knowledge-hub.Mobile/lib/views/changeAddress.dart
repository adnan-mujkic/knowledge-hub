import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/models/address.dart';
import 'package:knowledge_hub_mobile/services/accountService.dart';
import 'package:knowledge_hub_mobile/services/persistentDataService.dart';
import 'package:event/event.dart';
import 'package:http/http.dart' as http;

import '../models/city.dart';


class ChangeAddressWidget extends StatefulWidget {
  ChangeAddressWidget({Key? key}) : super(key: key){
    userAddress = AccountService.instance.addressData;
    if(userAddress.City == null ||userAddress.City == "")
      userAddress.City = PersistentDataService.instance.cities[0].Name;
  }

  late Address userAddress;
  var saveChangesEvent = Event();

  @override
  ChangeAddressState createState() => ChangeAddressState();
}

class ChangeAddressState extends State<ChangeAddressWidget> {

  changeAddress()async{
    final response = await http.post(
      Uri.parse('${PersistentDataService.instance.BackendUri}/api/User/UpdateAddress'),
      headers: <String, String>{
        'Content-Type' : 'application/json; charset=UTF-8',
        'Authorization' : "Basic ${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}"
      },
      body: jsonEncode({
        'userId' : AccountService.instance.userData.UserId,
        'fullName': widget.userAddress.FullName,
        'addressLine': widget.userAddress.AdressLine,
        'city': widget.userAddress.City
      }),
    );

    if(response.statusCode == 200){
      Map<String, dynamic> map = jsonDecode(response.body);
      AccountService.instance.addressData.FullName = map['fullName'] ?? "";
      AccountService.instance.addressData.AdressLine = map['addressLine'] ?? "";
      AccountService.instance.addressData.City = map['city'] ?? "";
      AccountService.instance.addressData.Postcode = map['postcode'] ?? "";
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
                    "Address",
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
                              padding: EdgeInsets.only(top: 0, bottom: 0, right: 20, left: 20),
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
                              padding: EdgeInsets.only(top: 0, bottom: 0, right: 20, left: 20),
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
                          width: double.infinity,
                          child: Padding(
                            padding: const EdgeInsets.only(top: 0, bottom: 0, right: 20, left: 20),
                            child: DropdownButton<String>(
                              value: widget.userAddress.City,
                              onChanged: (String? newValue) {
                                setState(() {
                                  widget.userAddress.City = newValue;
                                });
                              },
                              items: PersistentDataService.instance.cities.map<DropdownMenuItem<String>>((City value) {
                                return DropdownMenuItem<String>(
                                  value: value.Name,
                                  child: Text(value.Name),
                                );
                              }).toList(),
                            ),
                          ),
                        ),
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
                      onPressed: ()  {
                        changeAddress();
                        widget.saveChangesEvent.broadcast();
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
