import 'dart:ui';

import 'package:event/event.dart';
import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/components/paymentScreen.dart';
import 'package:knowledge_hub_mobile/models/paymentInfo.dart';
import 'package:knowledge_hub_mobile/views/changeAddress.dart';
import 'package:knowledge_hub_mobile/views/changePaymentInfo.dart';
import '../models/address.dart';

import '../models/order.dart';

class CartWidget extends StatefulWidget {

  @override
  CartState createState() => CartState();
}

class CartState extends State<CartWidget> {

  bool viewingPayment = false;

  Widget getPaymentWidget(){
    var paymentWidget = PaymentWidget();
    paymentWidget.cancelOrderEvent.subscribe((args) {
      setState((){
        viewingPayment = false;
      });
    });
    return paymentWidget;
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Stack(
        children: [
          Container(
            child: ElevatedButton(
              onPressed: (){
                setState((){
                  viewingPayment = true;
                });
              },
              child: Text("Checkout now"),
            ),
          ),
          viewingPayment? getPaymentWidget() : Container(),
        ],
      ),
    );
  }
}
