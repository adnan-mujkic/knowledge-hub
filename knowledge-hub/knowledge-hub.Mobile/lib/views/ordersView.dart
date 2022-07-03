import 'dart:convert';
import 'package:knowledge_hub_mobile/views/order.dart';

import '../models/order.dart';
import '../services/persistentDataService.dart';
import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/components/bookViewInList.dart';
import 'package:event/event.dart';
import 'package:http/http.dart' as http;
import 'package:knowledge_hub_mobile/services/accountService.dart';

import '../models/book.dart';

class OrdersViewWidget extends StatefulWidget {
  OrdersViewWidget(this.userRole, {Key? key}) : super(key: key);

  var selectedBookEvent = Event<Value<Book>>();
  bool userRole;

  @override
  OrdersViewState createState() => OrdersViewState();
}

class OrdersViewState extends State<OrdersViewWidget> {
  late bool loaded = false;
  late Future<List<Order>> fetchOrders;

  List<OrderController> getOrderList(List<Order> data) {
    List<OrderController> tempList =
        List<OrderController>.empty(growable: true);

    for (int i = 0; i < data.length; i++) {
      OrderController temp = OrderController(data[i], true, i, widget.userRole);
      tempList.add(temp);
    }

    return tempList;
  }

  Future<List<Order>> getOrders() async {
    final response = await http.get(
        Uri.parse(
            '${PersistentDataService.instance.BackendUri}/api/Order/GetByUser?UserId=${AccountService.instance.userData.UserId}'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Authorization':
              "Basic ${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}"
        });
    if (response.statusCode == 200) {
      var jsonBody = jsonDecode(response.body);
      Iterable iterable = jsonBody;

      var orders = List<Order>.from(iterable.map((e) => Order.fromJson(e)));
      return orders;
    }

    return List<Order>.empty(growable: true);
  }

  @override
  void initState() {
    super.initState();
    fetchOrders = getOrders();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      color: Colors.white,
      margin: EdgeInsets.only(top: 0),
      child: SingleChildScrollView(
        child: Container(
          padding: const EdgeInsets.all(1),
          child: FutureBuilder<List<Order>>(
            future: fetchOrders,
            builder: (context, snapshot) {
              if (snapshot.hasData) {
                return Column(children: getOrderList(snapshot.data!));
              }

              return const CircularProgressIndicator();
            },
          ),
        ),
      ),
    );
  }
}
