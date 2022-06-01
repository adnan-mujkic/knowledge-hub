import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

import 'models/order.dart';
import 'views/order.dart';



void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        // This is the theme of your application.
        //
        // Try running your application with "flutter run". You'll see the
        // application has a blue toolbar. Then, without quitting the app, try
        // changing the primarySwatch below to Colors.green and then invoke
        // "hot reload" (press "r" in the console where you ran "flutter run",
        // or simply save your changes to "hot reload" in a Flutter IDE).
        // Notice that the counter didn't reset back to zero; the application
        // is not restarted.
        primarySwatch: Colors.blue,
      ),
      home: const MyHomePage(title: 'Flutter Demo Home Page'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({Key? key, required this.title}) : super(key: key);

  // This widget is the home page of your application. It is stateful, meaning
  // that it has a State object (defined below) that contains fields that affect
  // how it looks.

  // This class is the configuration for the state. It holds the values (in this
  // case the title) provided by the parent (in this case the App widget) and
  // used by the build method of the State. Fields in a Widget subclass are
  // always marked "final".

  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  List<Order> ordersList = List<Order>.empty(growable: true);
  late OrderController selectedOrder;
  bool displaySelectedOrder = false;

  _MyHomePageState(){
    for(int i = 0; i < 5; i++){
      Order order = Order();
      order.populate(
          'assets/book.png',
          'John Doe',
          'Book 1',
          'Book author',
          '00000',
          '10.10.2022',
          '10.10.2022',
          'Dispatched',
          'Address line 1');

      ordersList.add(order);
    }
  }

  List<OrderController> getOrderList() {
    List<OrderController> tempList = List<OrderController>.empty(growable: true);

    for(int i = 0; i < 5; i++){
      OrderController temp = OrderController(ordersList[i], true, i);
      temp.updateClickedEvent.subscribe((args) {
        selectedOrder = OrderController(ordersList[i], false, i);
        toggleDisplaySelectedOrder();
      });
      tempList.add(temp);
    }

    return tempList;
  }

  void toggleDisplaySelectedOrder(){
    debugPrint("Clicked update");
    setState(() {
      this.displaySelectedOrder = !this.displaySelectedOrder;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: PreferredSize(
          preferredSize: const Size.fromHeight(60.0),
          child: AppBar(
            backgroundColor: const Color.fromARGB(255, 255, 255, 255),
            elevation: 4,
            shadowColor: Colors.black.withOpacity(0.25),
            flexibleSpace: Stack(
              children: [
                Container(
                  alignment: Alignment.bottomLeft,
                  height: 30,
                  width: 30,
                  margin: const EdgeInsets.only(left: 20, top: 45),
                  child: Image.asset(
                    'assets/Logo.png',
                    fit: BoxFit.cover,
                  ),
                ),
                Container(
                  margin: const EdgeInsets.only(
                      top: 40, bottom: 10, left: 70, right: 20),
                  padding: const EdgeInsets.all(0),
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(50),
                    color: const Color.fromARGB(30, 0, 0, 0),
                  ),
                  child: SizedBox(
                      child: Stack(
                          children: const <Widget>[
                            Positioned(
                                top: 10,
                                left: 20,
                                child: Icon(
                                  Icons.search,
                                  color: Colors.grey,
                                  size: 24,
                                )),
                            Positioned(
                                left: 60,
                                top: -4,
                                height: 50,
                                width: 250,
                                child: TextField(
                                  decoration: InputDecoration(
                                      border: InputBorder.none,
                                      labelText: "Search orders by number, city"),
                                  style: TextStyle(
                                      fontSize: 12
                                  ),
                                ))
                          ])
                  ),
                )
              ],
            ) ,
          )),
      body: Center(
        child: Stack(
          children: <Widget>[
            SingleChildScrollView(
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: getOrderList(),
              ),
            ),
            !displaySelectedOrder? Container() : SizedBox.expand(
              child: Container(
                width: double.infinity,
                height: double.infinity,
                color: Colors.black.withOpacity(0.5),
                child: Stack(
                  children: <Widget>[
                    FractionallySizedBox(
                      widthFactor: 1,
                      heightFactor: 1,
                      child: TextButton(
                        onPressed: toggleDisplaySelectedOrder,
                        child: Text(''),
                      ),
                    ),
                    Align(
                      child: FractionallySizedBox(
                        widthFactor: 1,
                        child: selectedOrder,
                      ),
                    )
                  ],
                ),
              ),
            )
          ],
        ),
      ),
    );
  }
}
