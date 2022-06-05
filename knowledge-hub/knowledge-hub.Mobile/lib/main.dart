import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:knowledge_hub_mobile/components/paymentScreen.dart';
import 'package:knowledge_hub_mobile/views/bookView.dart';
import 'package:knowledge_hub_mobile/views/cart.dart';
import 'package:knowledge_hub_mobile/views/changeAddress.dart';
import 'package:knowledge_hub_mobile/views/changePassword.dart';
import 'package:knowledge_hub_mobile/views/changePaymentInfo.dart';
import 'package:knowledge_hub_mobile/views/login.dart';
import 'package:knowledge_hub_mobile/views/register.dart';
import 'package:knowledge_hub_mobile/views/user.dart';
import 'package:knowledge_hub_mobile/views/whishlist.dart';

import 'models/book.dart';
import 'models/order.dart';
import 'models/user.dart';
import 'views/order.dart';



void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  MyApp({Key? key}) : super(key: key);

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
      home:  MyHomePage(title: 'Flutter Demo Home Page'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  MyHomePage({Key? key, required this.title}) : super(key: key);

  final String title;
  late bool userRole = true;
  late int currentDisplayIndex = 0;
  late bool tabs = true;


  User user = User(
      "0000",
      "adnanmujkic1337@gmail.com",
      "Adnan",
      "Biography");

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  List<Order> ordersList = List<Order>.empty(growable: true);
  late OrderController selectedOrder;
  bool displaySelectedOrder = false;
  int _selectedIndex = 0;
  late bool logged = false;
  late bool loginScreen = true;
  late bool viewingBook = false;
  late Book book;
  late int cartItemsNumber = 0;
  final LoginWidget loginWidget = LoginWidget();
  final RegisterWidget registerWidget = RegisterWidget();
  late WishlistWidget wishlist;

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
          0,
          'Address line 1');

      ordersList.add(order);
    }

    loginWidget.openRegisterEvent.subscribe((args) {
      setState(() {
        loginScreen = false;
      });
    });
    loginWidget.loginEvent.subscribe((args) {
      setState((){
        logged = true;
      });
    });
    registerWidget.openLoginEvent.subscribe((args) {
      setState(() {
        loginScreen = true;
      });
    });

    wishlist = WishlistWidget();
    wishlist.selectedBookEvent.subscribe((args) {
      setState(() {
        viewingBook = true;
        book = args!.value;
      });
    });
  }

  List<OrderController> getOrderList() {
    List<OrderController> tempList = List<OrderController>.empty(growable: true);

    for(int i = 0; i < 5; i++){
      OrderController temp = OrderController(ordersList[i], true, i, widget.userRole);
      temp.updateClickedEvent.subscribe((args) {
        selectedOrder = OrderController(ordersList[i], false, i, widget.userRole);
        toggleDisplaySelectedOrder();
      });
      tempList.add(temp);
    }

    return tempList;
  }

  void toggleDisplaySelectedOrder(){
    setState(() {
      this.displaySelectedOrder = !this.displaySelectedOrder;
    });
  }

  Widget GetDisplayScreen(){
    if(widget.tabs == true){
      if(viewingBook){
        return Stack(
          children: [
            BookViewWidget(book),
          ],
        );
      }

      switch(_selectedIndex){
        case 0:
          return Stack(
            children: <Widget>[
              Stack(
                children: [
                  Container(
                    color: Colors.white,
                    margin: EdgeInsets.only(
                        top: (widget.userRole == true? 30 : 0)),
                    child: (widget.userRole == true? Container() : SingleChildScrollView(
                      child: Container(
                        padding: const EdgeInsets.all(1),
                        child: Column(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: getOrderList(),
                        ),
                      ),
                    )),
                  ),
                  widget.userRole == true? Container(
                    width: double.infinity,
                    height: 30,
                    color: const Color.fromARGB(255, 60, 60, 80),
                    padding: EdgeInsets.all(0),
                    child: Row(
                      mainAxisSize: MainAxisSize.min,
                      crossAxisAlignment: CrossAxisAlignment.center,
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        TextButton(
                            onPressed: null,
                            child: Text(
                              "Categories",
                              style: TextStyle(
                                  color: Colors.white,
                                  fontSize: 12
                              ),
                            )
                        ),
                        TextButton(
                            onPressed: null,
                            child: Text(
                              "Bestsellers",
                              style: TextStyle(
                                  color: Colors.white,
                                  fontSize: 12
                              ),
                            )
                        ),
                        TextButton(
                            onPressed: null,
                            child: Text(
                              "On Sale",
                              style: TextStyle(
                                  color: Colors.white,
                                  fontSize: 12
                              ),
                            )
                        ),
                        TextButton(
                            onPressed: null,
                            child: Text(
                              "Upcoming",
                              style: TextStyle(
                                  color: Colors.white,
                                  fontSize: 12
                              ),
                            )
                        ),
                      ],
                    ),
                  ) : Container(),
                ],
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
              ),
            ],
          );
        case 1:
          return Container();
        case 2:
          return wishlist;
          case 3:
          return CartWidget();
      }
      return Container();
    }


    switch(this.widget.currentDisplayIndex){
      case 0:
        return UserManagmentWidget(widget.user);
      case 1:
        return ChangePasswordWidget();
      case 2:
        return ChangePaymentInfoWidget();
      case 3:
        return Container(
          color: Colors.white,
          margin: EdgeInsets.only(
              top: 0),
          child: SingleChildScrollView(
            child: Container(
              padding: const EdgeInsets.all(1),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: getOrderList(),
              ),
            ),
          ),
        );
      case 4:
        return ChangeAddressWidget();
    }
    return Container();
  }

  void _onItemTapped(int index) {
    setState(() {
      this.widget.tabs = true;
      _selectedIndex = index;
      this.viewingBook = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return logged? Scaffold(
      appBar: PreferredSize(
          preferredSize: const Size.fromHeight(60.0),
          child: AppBar(
            backgroundColor: widget.userRole == true? Color.fromARGB(200, 221, 190, 169) : Color.fromARGB(255, 255, 255, 255),
            elevation: 4,
            shadowColor: Colors.black.withOpacity(0.25),
            flexibleSpace: Stack(
              children: [
                viewingBook? Container(
                  margin: const EdgeInsets.only(
                      top: 40, bottom: 10, left: 0, right: 20),
                  child: TextButton(
                    style: ButtonStyle(
                      foregroundColor: MaterialStateProperty.all<Color>(Colors.white)
                    ),
                    onPressed: (){
                      setState(() {
                        viewingBook = false;
                      });
                    },
                    child: Icon(Icons.arrow_back),
                  ),
                ) : Container(),
                Container(
                  margin: const EdgeInsets.only(
                      top: 40, bottom: 10, left: 60, right: 20),
                  padding: const EdgeInsets.all(0),
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(50),
                    color: widget.userRole == true? Colors.white : Color.fromARGB(30, 0, 0, 0),
                  ),
                  child: SizedBox(
                      child: Stack(
                          children: <Widget>[
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
                                      labelText:
                                        widget.userRole == true?
                                        "Search books, authors, ISBNs" : "Search orders by number, city"
                                  ),
                                  style: const TextStyle(
                                      fontSize: 12
                                  ),
                                ))
                          ])
                  ),
                ),
              ],
            ) ,
          )),
      body: SizedBox(
        child: Stack(
          children: [
            Container(
              width: double.infinity,
              height: double.infinity,
              color: const Color.fromARGB(10, 0, 0, 0),
              child: GetDisplayScreen()
            )
          ],
        ),
      ),
      bottomNavigationBar: BottomNavigationBar(
        backgroundColor: const Color.fromARGB(255, 221, 190, 169),
        unselectedItemColor: const Color.fromARGB(200, 110, 90, 84),
        selectedItemColor: Colors.white,
        showSelectedLabels: false,
        showUnselectedLabels: false,
        currentIndex: _selectedIndex,
        onTap: _onItemTapped,
        items: <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            icon: Icon(Icons.home_outlined),
            activeIcon: Icon(Icons.home),
            label: "Home",
            backgroundColor: Color.fromARGB(255, 221, 190, 169),
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.my_library_books_outlined),
            activeIcon: Icon(Icons.my_library_books),
            label: "My Books",
            backgroundColor: Color.fromARGB(255, 221, 190, 169),
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.turned_in_not),
            activeIcon: Icon(Icons.turned_in),
            label: 'Whishlist',
            backgroundColor: Color.fromARGB(255, 221, 190, 169)
          ),
          BottomNavigationBarItem(
              icon: Stack(
                clipBehavior: Clip.none,
                alignment: Alignment.center,
                children: [
                  Icon(Icons.shopping_cart_outlined),
                  cartItemsNumber > 0? Positioned(
                    right: -11,
                      top: -11,
                      child: Stack(
                        alignment: Alignment.center,
                        children: [
                          Container(
                            width: 24,
                            height: 24,
                            decoration: BoxDecoration(
                                color: Colors.red.withOpacity(1),
                                borderRadius: BorderRadius.circular(20)
                            ),
                          ),
                          Text(
                            cartItemsNumber.toString(),
                            style: TextStyle(
                              color: Colors.white,
                            ),)
                        ],
                      )
                  ) : Container(),
                ],
              ) ,
              activeIcon: Icon(Icons.shopping_cart),
              label: 'Cart',
              backgroundColor: Color.fromARGB(255, 221, 190, 169)
          ),
        ],
      ),
      drawer: viewingBook? null : Container(
        width: 200,
        child: Drawer(
          child: ListView(
            padding: EdgeInsets.zero,
            children: [
              Container(
                height: 100,
                child: DrawerHeader(
                  decoration: const BoxDecoration(
                      color: Color.fromARGB(200, 221, 190, 169)
                  ),
                  child: Container(
                    alignment: Alignment.center,
                    height: 32,
                    width: 32,
                    child: Image.asset(
                      'assets/LogoWhite.png',
                      fit: BoxFit.cover,
                    ),
                  ),
                ),
              ),
              Container(
                margin: EdgeInsets.all(10),
                child: Center(
                  child: Text(
                    "Settings",
                    style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 20,
                        color: Color.fromARGB(150, 0, 0, 0)
                    ),),
                )
              ),
              const Divider(
                height: 10,
                thickness: 1,
                indent: 10,
                endIndent: 10,
                color: Color.fromARGB(20, 0, 0, 0),
              ),
              ListTile(
                title: Text("Account"),
                leading: Icon(Icons.account_circle),
                onTap: () {
                  setState(() {
                    this.widget.tabs = false;
                    this.widget.currentDisplayIndex = 0;
                  });
                  Navigator.pop(context);
                },
              ),
              ListTile(
                title: Text("Privacy"),
                leading: Icon(Icons.lock),
                onTap: () {
                  setState(() {
                    this.widget.tabs = false;
                    this.widget.currentDisplayIndex = 1;
                  });
                  Navigator.pop(context);
                },
              ),
              if(widget.userRole) ListTile(
                title: Text("Payment"),
                leading: Icon(Icons.wallet),
                onTap: () {
                  setState(() {
                    this.widget.tabs = false;
                    this.widget.currentDisplayIndex = 2;
                  });
                  Navigator.pop(context);
                },
              ),
              if(widget.userRole) ListTile(
                title: Text("Orders"),
                leading: Icon(Icons.shopping_bag),
                onTap: () {
                  setState(() {
                    this.widget.tabs = false;
                    this.widget.currentDisplayIndex = 3;
                  });
                  Navigator.pop(context);
                },
              ),
              if(widget.userRole) ListTile(
                title: Text("Adress"),
                leading: Icon(Icons.pin_drop),
                onTap: () {
                  setState(() {
                    this.widget.tabs = false;
                    this.widget.currentDisplayIndex = 4;
                  });
                  Navigator.pop(context);
                },
              ),
              const Divider(
                height: 10,
                thickness: 1,
                indent: 10,
                endIndent: 10,
                color: Color.fromARGB(20, 0, 0, 0),
              ),
              ListTile(
                title: Text(
                  "Log Out",
                  style: TextStyle(
                    color: Color.fromARGB(200, 255, 0, 30)
                  ),
                ),
                leading: Icon(
                  Icons.logout,
                  color: Color.fromARGB(180, 255, 0, 30),
                ),
                onTap: () {
                  setState(() {
                    this.logged = false;
                  });
                  Navigator.pop(context);
                },
              ),
            ],
          ),
        ),
      ),
    ) :
    (loginScreen? loginWidget : registerWidget);
  }
}
