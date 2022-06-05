import 'dart:ui';

import 'package:event/event.dart';
import 'package:expandable_text/expandable_text.dart';
import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/models/paymentInfo.dart';
import 'package:knowledge_hub_mobile/views/changeAddress.dart';
import 'package:knowledge_hub_mobile/views/changePaymentInfo.dart';
import '../models/address.dart';

import '../models/order.dart';

class PaymentWidget extends StatefulWidget {
  PaymentWidget({Key? key}) : super(key: key){
    paymentInfo = new PaymentInfo();
    paymentInfo.CardHolder = "John Doe";
    paymentInfo.CardNumber = "1111-2222-3333-4444";

    address = new Address();
    address.FullName = "John Doe";
    address.City = "Mostar";
    address.Postcode = "88000";
    address.AdressLine = "Kneza Višeslava 69";
    order = new Order();
  }

  late PaymentInfo paymentInfo;
  late Address address;
  late Order order;
  var cancelOrderEvent = Event();


  @override
  PaymentState createState() => PaymentState();
}

class PaymentState extends State<PaymentWidget> {

  bool viewingCardInfo = false;
  bool viewingAddressInfo = false;

  Widget getPaymentChangeWidget(){
    var paymentChangeWidget = ChangePaymentInfoWidget();
    paymentChangeWidget.saveChangesEvent.subscribe((args) {
      setState((){
        viewingCardInfo = false;
      });
    });
    return paymentChangeWidget;
  }
  Widget getAddressChangeWidget(){
    var addressChangeWidget = ChangeAddressWidget();
    addressChangeWidget.saveChangesEvent.subscribe((args) {
      setState((){
        viewingAddressInfo = false;
      });
    });
    return addressChangeWidget;
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(top: 20, bottom: 20, right: 15, left: 15),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.all(Radius.circular(20))
      ),
      child: Stack(
        children: [
          Container(
            margin: EdgeInsets.only(left: 30, right: 30, top: 20, bottom: 20),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.start,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  "Purchase Information",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16),
                ),
                Divider(
                  thickness: 1,
                  height: 10,
                  color: Colors.grey.withOpacity(0.2),
                  endIndent: 100,
                ),
                Text("Order number: ${widget.order.orderNumber}"),
                Text("Product Name: ${widget.order.bookName}"),
                Text("Type: ${widget.order.type}"),
                Text("Price: ${widget.order.paid.toString()}"),
                Text("VAT (20%): ${widget.order.paid.toString()}"),
                Text("Summary: ${widget.order.paid.toString()}", style: TextStyle(fontWeight: FontWeight.bold),),
                const SizedBox(
                  height: 20,
                ),
                Text(
                  "Card Information",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16),
                ),
                Divider(
                  thickness: 1,
                  height: 10,
                  color: Colors.grey.withOpacity(0.2),
                  endIndent: 100,
                ),
                Container(
                  margin: EdgeInsets.only(top: 10),
                  padding: EdgeInsets.only(top: 10, bottom: 10, right: 10, left: 10),
                  decoration: BoxDecoration(
                      color: Colors.white,
                      borderRadius: BorderRadius.circular(10),
                      border: Border.all(style: BorderStyle.solid, color: Colors.green)
                  ),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(
                        widget.paymentInfo.CardHolder,
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          color: Colors.green,
                        ),
                      ),
                      Text(
                        "xxxx - xxxx - xxxx - ${widget.paymentInfo.CardNumber.substring(widget.paymentInfo.CardNumber.length-4)}",
                        style: TextStyle(color: Colors.green),
                      ),
                    ],
                  ),
                ),
                TextButton(
                  onPressed: (){
                    setState((){
                      this.viewingCardInfo = true;
                    });
                  },
                  style: ButtonStyle(
                    foregroundColor: MaterialStateProperty.all(Colors.green),
                  ),
                  child: Text("Update Info"),
                ),
                Text(
                  "Address Information",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16),
                ),
                Divider(
                  thickness: 1,
                  height: 10,
                  color: Colors.grey.withOpacity(0.2),
                  endIndent: 100,
                ),
                Container(
                  margin: EdgeInsets.only(top: 10),
                  padding: EdgeInsets.only(top: 10, bottom: 10, right: 10, left: 10),
                  decoration: BoxDecoration(
                      color: Colors.white,
                      borderRadius: BorderRadius.circular(10),
                      border: Border.all(style: BorderStyle.solid, color: Colors.green)
                  ),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(
                        widget.address.FullName!,
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          color: Colors.green,
                        ),
                      ),
                      Text(
                        widget.address.AdressLine!,
                        style: TextStyle(color: Colors.green),
                      ),
                      Text(
                        "${widget.address.Postcode!}, ${widget.address.City}",
                        style: TextStyle(color: Colors.green),
                      ),
                    ],
                  ),
                ),
                TextButton(
                  onPressed: (){
                    setState((){
                      this.viewingAddressInfo = true;
                    });
                  },
                  style: ButtonStyle(
                    foregroundColor: MaterialStateProperty.all(Colors.green),
                  ),
                  child: Text("Update Info"),
                ),
                Container(
                  height: 46,
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      Container(
                        margin: EdgeInsets.all(5),
                        child: ElevatedButton(
                          onPressed: (){
                            widget.cancelOrderEvent.broadcast();
                          },
                          child: Text("Cancel"),
                          style: ButtonStyle(
                              backgroundColor: MaterialStateProperty.all(Colors.red)
                          ),
                        ),
                      ),
                      Container(
                        margin: EdgeInsets.all(5),
                        child: ElevatedButton(
                          onPressed: (){},
                          child: Text("Pay Now"),
                          style: ButtonStyle(
                              backgroundColor: MaterialStateProperty.all(Colors.green)
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
          this.viewingCardInfo? Container(
            decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.all(Radius.circular(20))
            ),
            child: getPaymentChangeWidget(),
          ) : Container(),
          this.viewingAddressInfo? Container(
            decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.all(Radius.circular(20))
            ),
            child: getAddressChangeWidget(),
          ) : Container(),
        ],
      ),
    );
  }
}
