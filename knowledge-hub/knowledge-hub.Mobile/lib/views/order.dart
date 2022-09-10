import 'dart:convert';

import 'package:flutter/material.dart';
import '../models/order.dart';
import 'package:event/event.dart';
import 'package:http/http.dart' as http;

import '../services/accountService.dart';
import '../services/persistentDataService.dart';

class OrderController extends StatefulWidget {
  Order order = Order();
  bool preview;
  bool userRole;
  int index;
  String? orderStatus = "Waiting";
  String? comment = "";
  var updateClickedEvent = Event<Value<int>>();

  OrderController(Order initialOrder, this.preview, this.index, this.userRole,
      {Key? key})
      : super(key: key) {
    order = initialOrder;
  }
  @override
  State<StatefulWidget> createState() => OrderWidget(order, index);
}

class OrderWidget extends State<OrderController> {
  Order order = Order();
  int index;
  bool showDetails = false;

  void onUpdateClicked() {
    widget.updateClickedEvent.broadcast(Value(index));
    setState(() {
      widget.preview = !widget.preview;
    });
  }

  OrderWidget(Order initialOrder, this.index) {
    order = initialOrder;
  }

  void updateOrder() async {
    final response = await http.put(
        Uri.parse(
            '${PersistentDataService.instance.BackendUri}/api/Order?ID=${widget.order.orderId}'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Authorization':
              "Basic ${base64Encode(utf8.encode('${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}'))}"
        },
        body: jsonEncode(
            {'comment': widget.comment, 'orderStatus': getOrderStatusEnum()}));
    if (response.statusCode == 200) {
      var map = jsonDecode(response.body);
      setState(() {
        widget.order = Order.fromJson(map);
      });
    }
  }

  int getOrderStatusEnum() {
    switch (widget.orderStatus) {
      case null:
        return 0;
      case "Waiting":
        return 0;
      case "Dispatch":
        return 1;
      case "Return":
        return 2;
      default:
        return 0;
    }
  }

  @override
  Widget build(BuildContext context) {
    return Container(
        width: double.infinity,
        height: widget.preview != true ? 350 : 180,
        margin: const EdgeInsets.only(top: 10, bottom: 10, left: 10, right: 10),
        decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(20),
            color: Colors.white,
            boxShadow: [
              BoxShadow(
                color: Colors.grey.withOpacity(0.1),
                spreadRadius: 6,
                blurRadius: 6,
                offset: Offset(0, 3), // changes position of shadow
              )
            ]),
        child: Stack(
          children: <Widget>[
            Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                Row(
                  children: <Widget>[
                    Container(
                      alignment: Alignment.topLeft,
                      height: 120,
                      width: 60,
                      margin: const EdgeInsets.only(left: 20, top: 0),
                      child: FadeInImage(
                        image: NetworkImage(widget.order.book.ImagePath),
                        placeholder: const AssetImage("assets/book.png"),
                      ),
                    ),
                    SizedBox(
                      child: Flexible(
                          child: Container(
                        margin: const EdgeInsets.only(
                            left: 20, top: 22, bottom: 10, right: 20),
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Container(
                              width: 200,
                              child: Text(
                                order.nameOfOrderPerson,
                                maxLines: 1,
                                style: const TextStyle(
                                    fontWeight: FontWeight.bold,
                                    overflow: TextOverflow.ellipsis),
                              ),
                            ),
                            Container(
                              width: 200,
                              child: Text(
                                "${order.bookName}",
                                style: const TextStyle(
                                  fontWeight: FontWeight.normal,
                                  overflow: TextOverflow.ellipsis,
                                ),
                                maxLines: 2,
                              ),
                            ),
                            const SizedBox(
                              height: 10,
                            ),
                            Text(
                              "Ordered: ${order.orderDate}",
                              style: const TextStyle(
                                  fontWeight: FontWeight.normal),
                            ),
                            Text(
                              "Shipped: ${order.shippedDate}",
                              style: const TextStyle(
                                  fontWeight: FontWeight.normal),
                            ),
                            Text(
                              "Status: ${getOrderNameFromIndex(widget.order.orderStatus)}",
                              style: const TextStyle(
                                  fontWeight: FontWeight.normal),
                            ),
                            Container(
                              width: 200,
                              child: Text(
                                "Address: ${order.address}",
                                maxLines: 1,
                                style: const TextStyle(
                                    fontWeight: FontWeight.normal,
                                    overflow: TextOverflow.ellipsis),
                              ),
                            ),
                          ],
                        ),
                      )),
                    ),
                  ],
                ),
                Text(
                  "Order number: ${order.orderNumber}",
                  style: const TextStyle(
                      fontWeight: FontWeight.normal, fontSize: 12),
                ),
                getPreview()
              ],
            ),
            if (!widget.userRole)
              Positioned(
                right: 10,
                top: 10,
                width: 50,
                height: 30,
                child: ClipRRect(
                  borderRadius: BorderRadius.circular(20),
                  child: Stack(
                    children: <Widget>[
                      Positioned.fill(
                        child: Container(
                          decoration: BoxDecoration(
                            color: widget.preview
                                ? Colors.green
                                : Colors.lightBlue,
                          ),
                        ),
                      ),
                      TextButton(
                        style: TextButton.styleFrom(
                          padding: const EdgeInsets.all(0),
                          primary: Colors.white,
                          textStyle: const TextStyle(fontSize: 15),
                        ),
                        onPressed: onUpdateClicked,
                        child: Text(
                          (widget.preview ? "Update" : "^"),
                          style: TextStyle(fontSize: 11),
                        ),
                      )
                    ],
                  ),
                ),
              ),
          ],
        ));
  }

  Container getPreview() {
    if (!widget.preview) {
      return Container(
        child: Column(
          children: [
            Padding(
              padding: const EdgeInsets.only(top: 0, left: 30, right: 30),
              child: Column(
                children: <Widget>[
                  Row(
                    children: [
                      Text("Status"),
                      SizedBox(
                        width: 10,
                      ),
                      Container(
                        height: 30,
                        child: DropdownButton(
                            value:
                                getOrderNameFromIndex(widget.order.orderStatus),
                            items: <String>["Waiting", "Dispatch", "Return"]
                                .map<DropdownMenuItem<String>>((String value) {
                              return DropdownMenuItem<String>(
                                value: value,
                                child: Text(
                                  value,
                                  style: TextStyle(fontSize: 12),
                                ),
                              );
                            }).toList(),
                            onChanged: (String? value) {
                              setState(() => {
                                    widget.orderStatus = value,
                                    widget.order.orderStatus =
                                        getOrderIndexFromName(value)
                                  });
                            }),
                      ),
                    ],
                  ),
                  SizedBox(
                    height: 100,
                    child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text("Comment"),
                          Expanded(
                            child: Padding(
                              padding: EdgeInsets.only(top: 6, bottom: 6),
                              child: TextFormField(
                                maxLines: 5,
                                initialValue: widget.comment,
                                onChanged: (String val) => {
                                  setState(() {
                                    widget.comment = val;
                                  })
                                },
                                decoration: InputDecoration(
                                  border: OutlineInputBorder(),
                                  hintText: widget.comment,
                                ),
                                style: TextStyle(fontSize: 12),
                              ),
                            ),
                          )
                        ]),
                  ),
                  ElevatedButton(
                      style: ButtonStyle(
                          backgroundColor:
                              MaterialStateProperty.all<Color>(Colors.green)),
                      onPressed: () => {updateOrder()},
                      child: Text("Save")),
                ],
              ),
            )
          ],
        ),
      );
    } else {
      return Container();
    }
  }

  int getOrderIndexFromName(String? value) {
    switch (value) {
      case "Waiting":
        return 0;
      case "Dispatch":
        return 1;
      case "Return":
        return 2;
    }
    return 0;
  }

  String? getOrderNameFromIndex(int index) {
    switch (index) {
      case 0:
        return "Waiting";
      case 1:
        return "Dispatch";
      case 2:
        return "Return";
    }
    return "Waiting";
  }
}
