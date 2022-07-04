// ignore_for_file: prefer_const_constructors

import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:http/http.dart' as http;
import 'package:knowledge_hub_mobile/components/bookViewInList.dart';
import 'package:knowledge_hub_mobile/services/persistentDataService.dart';
import 'package:knowledge_hub_mobile/views/mainBooksCategories.dart';
import 'package:knowledge_hub_mobile/views/myBooks.dart';
import 'package:knowledge_hub_mobile/views/ordersView.dart';
import 'package:knowledge_hub_mobile/views/searchResults.dart';
import '../services/accountService.dart';
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

void main() async {
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
      home: MyHomePage(title: 'Flutter Demo Home Page'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  MyHomePage({Key? key, required this.title}) : super(key: key);

  final String title;
  late bool userRole = false;
  late int currentDisplayIndex = 0;
  late bool tabs = true;

  User user = User();

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  List<Order> ordersList = List<Order>.empty(growable: true);
  late OrderController selectedOrder;
  List<Book> bookList = List<Book>.empty(growable: true);
  List<Widget> booksWidgets = List<Widget>.empty(growable: true);
  bool displaySelectedOrder = false;
  int _selectedIndex = 0;
  late bool logged = false;
  late bool loginScreen = true;
  late bool viewingBook = false;
  late bool viewingSearch = false;
  bool loadingScreen = true;
  late Book book;
  late int cartItemsNumber = 0;
  var accountService = AccountService.instance;
  var persistentData = PersistentDataService.instance;
  late LoginWidget loginWidget;
  late RegisterWidget registerWidget;
  late WishlistWidget wishlist;
  SearchResultsWidget? searchResultWidget = null;
  late MainBooksCategoriesWidget mainBooksCategoriesWidget;
  late List<Book> searchedBooks = List<Book>.empty(growable: true);

  String fullscreenNotificationText = "";
  bool displayFullscreenNotification = false;

  _MyHomePageState() {
    accountService.loadFileFromDisk().then((value) async {
      await http.get(
        Uri.parse('${PersistentDataService.instance.BackendUri}/api/Book/'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
      ).then((res) {
        setState(() {
          loadingScreen = false;
          if (accountService.authData.Email != "") {
            logged = true;
          }
          if (res.statusCode == 200) {
            List<dynamic> map = jsonDecode(res.body) as List<dynamic>;
            map.forEach((element) {
              Book bookElement = Book.fromJson(element);
              bookList.add(bookElement);
              booksWidgets.add(BookInListWidget(bookElement, 100));
            });

            mainBooksCategoriesWidget = MainBooksCategoriesWidget(bookList);
            mainBooksCategoriesWidget.selectedBookEvent.subscribe((args) {
              setState(() {
                viewingBook = true;
                book = args!.value;
              });
            });
          }
        });
      });

      //LOADING PERSISTENT DATA
      PersistentDataService.instance.fetchCities();
      PersistentDataService.instance.fetchCartItems();

      setState(() {
        widget.userRole =
            AccountService.instance.userData.UserRole != "Delivery";
      });
    });

    loginWidget = LoginWidget();
    registerWidget = RegisterWidget();
    for (int i = 0; i < 5; i++) {
      Order order = Order();
      order.populate('assets/book.png', 'John Doe', 'Book 1', 'Book author',
          '00000', '10.10.2022', '10.10.2022', 0, 'Address line 1');

      ordersList.add(order);
    }

    loginWidget.openRegisterEvent.subscribe((args) {
      setState(() {
        loginScreen = false;
      });
    });
    loginWidget.loginEvent.subscribe((args) {
      setState(() {
        logged = true;
        setState(() {
          widget.userRole =
              AccountService.instance.userData.UserRole != "Delivery";
        });
      });
    });
    registerWidget.openLoginEvent.subscribe((args) {
      setState(() {
        loginScreen = true;
      });
    });
    registerWidget.createAccountEvent.subscribe((args) {
      setState(() {
        logged = true;
        accountService.authData.Email = args!.value1;
        accountService.authData.Password = args.value2;
        setState(() {
          widget.userRole =
              AccountService.instance.userData.UserRole != "Delivery";
        });
      });
    });

    wishlist = WishlistWidget();
    wishlist.selectedBookEvent.subscribe((args) {
      setState(() {
        viewingBook = true;
        book = args!.value;
      });
    });

    PersistentDataService.instance.screenWideNotification.subscribe((args) {
      toggleFullscreenNotification(args!.value, true);
    });
  }

  void toggleDisplaySelectedOrder() {
    setState(() {
      this.displaySelectedOrder = !this.displaySelectedOrder;
    });
  }

  Widget GetDisplayScreen() {
    if (!widget.userRole) {
      return OrdersViewWidget(widget.userRole);
    }

    if (searchedBooks.isNotEmpty && !viewingBook) {
      if (searchResultWidget != null) {
        searchResultWidget?.selectedBookEvent.unsubscribeAll();
      }
      searchResultWidget = SearchResultsWidget(searchedBooks);
      searchResultWidget?.selectedBookEvent.subscribe((args) {
        setState(() {
          viewingBook = true;
          book = args!.value;
        });
      });
      return searchResultWidget!;
    }

    if (widget.tabs == true) {
      if (viewingBook) {
        return Stack(
          children: [
            BookViewWidget(book),
          ],
        );
      }

      switch (_selectedIndex) {
        case 0:
          return Stack(
            children: <Widget>[
              Stack(
                children: [
                  Container(
                    width: double.infinity,
                    margin:
                        EdgeInsets.only(top: (widget.userRole == true ? 0 : 0)),
                    child: Container(
                        padding: const EdgeInsets.all(1),
                        child: mainBooksCategoriesWidget),
                  ),
                ],
              ),
              !displaySelectedOrder
                  ? Container()
                  : SizedBox.expand(
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
          return MyBooksWidget();
        case 2:
          return wishlist;
        case 3:
          return CartWidget();
      }
      return Container();
    }

    switch (this.widget.currentDisplayIndex) {
      case 0:
        return UserManagmentWidget();
      case 1:
        return ChangePasswordWidget();
      case 2:
        return ChangePaymentInfoWidget();
      case 3:
        return OrdersViewWidget(widget.userRole);
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

  void toggleFullscreenNotification(String text, bool activate) {
    setState(() {
      fullscreenNotificationText = text;
      displayFullscreenNotification = activate;
    });
  }

  void searchBooks(String searchQuery) async {
    final response = await http.get(
      Uri.parse(
          '${PersistentDataService.instance.BackendUri}/api/Book/Search?search=$searchQuery'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
        'Authorization':
            "Basic ${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}"
      },
    );
    if (response.statusCode == 200) {
      List<dynamic> map = jsonDecode(response.body) as List<dynamic>;
      searchedBooks.clear();

      setState(() {
        map.forEach((element) {
          searchedBooks.add(Book.fromJson(element));
        });
        viewingSearch = true;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return loadingScreen
        ? Scaffold(
            body: Container(
              height: double.infinity,
              width: double.infinity,
              color: const Color.fromARGB(255, 221, 190, 169),
              child: Center(
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Image.asset('assets/LogoWhite.png'),
                    const SizedBox(height: 30),
                    const Text(
                      "Stocking bookshelves...",
                      style: TextStyle(color: Colors.white),
                    )
                  ],
                ),
              ),
            ),
          )
        : (logged
            ? Scaffold(
                appBar: PreferredSize(
                    preferredSize: const Size.fromHeight(60.0),
                    child: AppBar(
                      backgroundColor: Color.fromARGB(200, 221, 190, 169),
                      elevation: 4,
                      shadowColor: Colors.black.withOpacity(0.25),
                      flexibleSpace: Stack(
                        children: [
                          viewingBook || viewingSearch
                              ? Container(
                                  margin: const EdgeInsets.only(
                                      top: 70, bottom: 10, left: 0, right: 20),
                                  child: TextButton(
                                    style: ButtonStyle(
                                        foregroundColor:
                                            MaterialStateProperty.all<Color>(
                                                Colors.white)),
                                    onPressed: () {
                                      setState(() {
                                        viewingBook = false;
                                        viewingSearch = false;
                                        searchedBooks.clear();
                                      });
                                    },
                                    child: Icon(Icons.arrow_back),
                                  ),
                                )
                              : Container(),
                          !widget.userRole
                              ? Container()
                              : Container(
                                  margin: const EdgeInsets.only(
                                      top: 70, bottom: 10, left: 60, right: 20),
                                  padding: const EdgeInsets.all(0),
                                  decoration: BoxDecoration(
                                    borderRadius: BorderRadius.circular(50),
                                    color: widget.userRole == true
                                        ? Colors.white
                                        : Color.fromARGB(30, 0, 0, 0),
                                  ),
                                  child: SizedBox(
                                      child: Stack(children: <Widget>[
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
                                              labelText: widget.userRole == true
                                                  ? "Search books by name"
                                                  : "Search orders by number, city"),
                                          style: const TextStyle(fontSize: 12),
                                          onChanged: (String val) async {
                                            if (val.length >= 3) {
                                              searchBooks(val);
                                            }
                                          },
                                        ))
                                  ])),
                                ),
                        ],
                      ),
                    )),
                body: SizedBox(
                  child: Stack(
                    children: [
                      Container(
                          width: double.infinity,
                          color: const Color.fromARGB(10, 0, 0, 0),
                          child: Stack(
                            children: [
                              GetDisplayScreen(),
                              displayFullscreenNotification
                                  ? Container(
                                      width: double.infinity,
                                      height: double.infinity,
                                      color: Colors.black.withOpacity(0.3),
                                      child: Align(
                                        child: Container(
                                          width: 250,
                                          height: 150,
                                          decoration: BoxDecoration(
                                              color: Colors.white,
                                              borderRadius:
                                                  BorderRadius.circular(20)),
                                          child: Column(
                                            mainAxisAlignment:
                                                MainAxisAlignment.center,
                                            children: [
                                              Container(
                                                margin: EdgeInsets.all(10),
                                                width: 220,
                                                height: 80,
                                                child: Align(
                                                  child: Text(
                                                    fullscreenNotificationText,
                                                    style: TextStyle(
                                                        color: Colors.black
                                                            .withOpacity(0.8)),
                                                  ),
                                                ),
                                              ),
                                              Spacer(),
                                              Container(
                                                width: 250,
                                                child: TextButton(
                                                    onPressed: () {
                                                      toggleFullscreenNotification(
                                                          "", false);
                                                    },
                                                    child: const Text("OK")),
                                              )
                                            ],
                                          ),
                                        ),
                                      ),
                                    )
                                  : Container()
                            ],
                          ))
                    ],
                  ),
                ),
                bottomNavigationBar: !widget.userRole
                    ? null
                    : BottomNavigationBar(
                        backgroundColor:
                            const Color.fromARGB(255, 221, 190, 169),
                        unselectedItemColor:
                            const Color.fromARGB(200, 110, 90, 84),
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
                              backgroundColor:
                                  Color.fromARGB(255, 221, 190, 169)),
                          BottomNavigationBarItem(
                              icon: Stack(
                                clipBehavior: Clip.none,
                                alignment: Alignment.center,
                                children: [
                                  Icon(Icons.shopping_cart_outlined),
                                  cartItemsNumber > 0
                                      ? Positioned(
                                          right: -11,
                                          top: -11,
                                          child: Stack(
                                            alignment: Alignment.center,
                                            children: [
                                              Container(
                                                width: 24,
                                                height: 24,
                                                decoration: BoxDecoration(
                                                    color: Colors.red
                                                        .withOpacity(1),
                                                    borderRadius:
                                                        BorderRadius.circular(
                                                            20)),
                                              ),
                                              Text(
                                                cartItemsNumber.toString(),
                                                style: TextStyle(
                                                  color: Colors.white,
                                                ),
                                              )
                                            ],
                                          ))
                                      : Container(),
                                ],
                              ),
                              activeIcon: Icon(Icons.shopping_cart),
                              label: 'Cart',
                              backgroundColor:
                                  Color.fromARGB(255, 221, 190, 169)),
                        ],
                      ),
                drawer: viewingBook || viewingSearch
                    ? null
                    : Container(
                        width: 200,
                        child: Drawer(
                          child: ListView(
                            padding: EdgeInsets.zero,
                            children: [
                              Container(
                                height: 150,
                                child: DrawerHeader(
                                  decoration: const BoxDecoration(
                                      color:
                                          Color.fromARGB(200, 221, 190, 169)),
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
                                          color: Color.fromARGB(150, 0, 0, 0)),
                                    ),
                                  )),
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
                              if (widget.userRole)
                                ListTile(
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
                              if (widget.userRole)
                                ListTile(
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
                              if (widget.userRole)
                                ListTile(
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
                                      color: Color.fromARGB(200, 255, 0, 30)),
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
              )
            : (loginScreen ? loginWidget : registerWidget));
  }
}
