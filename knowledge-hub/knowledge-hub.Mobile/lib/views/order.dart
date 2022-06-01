import 'package:flutter/material.dart';
import '../components/customSelectButton.dart';
import '../models/order.dart';
import 'package:event/event.dart';

class OrderController extends StatefulWidget{
  Order order = Order();
  bool preview;
  int index;
  String? orderStatus = "Waiting";
  var updateClickedEvent = Event<Value<int>>();


  OrderController(Order initialOrder, this.preview, this.index, {Key? key}) : super(key: key){
    order = initialOrder;
  }
  @override
  State<StatefulWidget> createState() => OrderWidget(order, preview, index);
}

class OrderWidget  extends State<OrderController> {
  Order order = Order();
  bool preview;
  int index;

  void onUpdateClicked(){
    widget.updateClickedEvent.broadcast(Value(index));
  }

  OrderWidget(Order initialOrder, this.preview, this.index){
    order = initialOrder;
  }

  @override
  Widget build(BuildContext context) {
  return Container(
      width: double.infinity,
      height: preview != true? 350 : 160,
      margin: const EdgeInsets.only(top: 10, bottom: 10, left: 10, right: 10),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(20),
        color: (preview != true? Colors.white : Color.fromARGB(30, 0, 0, 0)),
      ),
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
                    child: Image.asset(
                      order.imagePath,
                      fit: BoxFit.cover,
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
                              Text(
                                order.nameOfOrderPerson,
                                style: const TextStyle(
                                    fontWeight: FontWeight.bold),
                              ),
                              Text(
                                "${order.bookName} | ${order.bookAuthor}",
                                style: const TextStyle(
                                    fontWeight: FontWeight.normal),
                              ),
                              const SizedBox(
                                height: 10,
                              ),
                              Text(
                                "Order number: ${order.orderNumber}",
                                style: const TextStyle(
                                    fontWeight: FontWeight.normal),
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
                                "Status: ${order.orderStatus}",
                                style: const TextStyle(
                                    fontWeight: FontWeight.normal),
                              ),
                              Text(
                                "Address: ${order.address}",
                                style: const TextStyle(fontWeight: FontWeight.normal),
                              ),
                            ],
                          ),
                        )),
                  ),
                ],
              ),
              getPreview()
            ],
          ),
          if(preview) Positioned(
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
                      decoration: const BoxDecoration(
                        color: Colors.green,
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
                    child: const Text(
                        'Update',
                      style: TextStyle(
                        fontSize: 11
                      ),
                    ),
                  )
                ],
              ),
            ),
          )
        ],
      ));
  }

  Container getPreview(){
    if(!preview){
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
                            value: widget.orderStatus,
                            items: <String>["Waiting", "Dispatch", "Return"]
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
                                widget.orderStatus = value
                              });
                            }
                        ),
                      ),
                    ],
                  ),
                  SizedBox(
                    height: 100,
                    child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children:const [
                          Text("Comment"),
                          Expanded(
                            child:
                            Padding(
                              padding: EdgeInsets.only(top: 6, bottom: 6),
                              child: TextField(
                                maxLines: 5,
                                decoration: InputDecoration(
                                  border: OutlineInputBorder(),
                                  hintText: 'Enter a comment...',
                                ),
                                style: TextStyle(
                                  fontSize: 12
                                ),
                              ),
                            ),
                          )
                        ]
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
              ),
            )
          ],
        ),
      );
    }else{
      return Container();
    }
  }
}
