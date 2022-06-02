import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:knowledge_hub_mobile/models/address.dart';
import 'package:knowledge_hub_mobile/models/changePassword.dart';
import 'package:knowledge_hub_mobile/models/user.dart';
import '../models/book.dart';
import '../models/order.dart';
import 'package:event/event.dart';

import '../models/paymentInfo.dart';

class AddBookWidget extends StatefulWidget {
  AddBookWidget({Key? key}) : super(key: key){
    book = new Book();
    book.Language = "English";
    book.Category = "Fiction";
  }

  late Book book;

  @override
  AddBookState createState() => AddBookState();
}

class AddBookState extends State<AddBookWidget> {
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
                  "New Book:",
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
                      child: Text("Book Name:"),
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
                                  hintText: this.widget.book.BookName),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String? value){
                                this.widget.book.BookName = value;
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
                      child: Text("Language:"),
                    ),
                    Container(
                      width: double.infinity,
                      margin: const EdgeInsets.only(top: 10),
                      decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(50),
                        color: Color.fromARGB(10, 0, 0, 0),
                      ),
                      child: SizedBox(
                          child: Padding(
                            padding: EdgeInsets.only(top: 2, bottom: 2, right: 20, left: 20),
                            child: DropdownButtonHideUnderline(
                              child: DropdownButton(
                                  value: widget.book.Language,
                                  isExpanded: true,
                                  items: <String>["English", "Bosnian"]
                                      .map<DropdownMenuItem<String>>((String value){
                                    return DropdownMenuItem<String>(
                                      value: value,
                                      child: Text(
                                        value,
                                        style: TextStyle(
                                            fontSize: 12
                                        ),),
                                    );
                                  }).toList(),
                                  onChanged: (String? value){
                                    setState(() => {
                                      widget.book.Language = value
                                    });
                                  }
                              ),
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
                      child: Text("Category:"),
                    ),
                    Container(
                      width: double.infinity,
                      margin: const EdgeInsets.only(top: 10),
                      decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(50),
                        color: Color.fromARGB(10, 0, 0, 0),
                      ),
                      child: SizedBox(
                          child: Padding(
                            padding: EdgeInsets.only(top: 2, bottom: 2, right: 20, left: 20),
                            child: DropdownButtonHideUnderline(
                              child: DropdownButton(
                                  value: widget.book.Category,
                                  isExpanded: true,

                                  items: <String>["Fiction", "Biography"]
                                      .map<DropdownMenuItem<String>>((String value){
                                    return DropdownMenuItem<String>(
                                      value: value,
                                      child: Text(
                                        value,
                                        style: TextStyle(
                                            fontSize: 12
                                        ),),
                                    );
                                  }).toList(),
                                  onChanged: (String? value){
                                    setState(() => {
                                      widget.book.Category = value
                                    });
                                  }
                              ),
                            )
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
                      child: Text("Price Digital:"),
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
                                  hintText: this.widget.book.PriceDigital.toString()),
                              style: const TextStyle(fontSize: 12),
                              keyboardType: TextInputType.number,
                              inputFormatters: <TextInputFormatter>[
                                FilteringTextInputFormatter.digitsOnly
                              ],
                              onChanged: (String? value){
                                this.widget.book.PriceDigital = int.parse(value!);
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
                      child: Text("Price Physical:"),
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
                                  hintText: this.widget.book.PricePhysical.toString()),
                              style: const TextStyle(fontSize: 12),
                              keyboardType: TextInputType.number,
                              inputFormatters: <TextInputFormatter>[
                                FilteringTextInputFormatter.digitsOnly
                              ],
                              onChanged: (String? value){
                                this.widget.book.PricePhysical = int.parse(value!);
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
                      child: Text("Description:"),
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
                                  hintText: this.widget.book.Description),
                              style: const TextStyle(fontSize: 12),
                              onChanged: (String? value){
                                this.widget.book.Description = value;
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
                  child: Text("Create")
              ),
            ],
          )),
    );
  }
}
