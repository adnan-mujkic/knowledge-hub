import 'dart:convert';
import 'dart:ui';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:event/event.dart';
import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/components/cartItemView.dart';
import 'package:knowledge_hub_mobile/components/paymentScreen.dart';
import 'package:knowledge_hub_mobile/components/stripeLoadingButton.dart';
import 'package:knowledge_hub_mobile/models/cartItem.dart';
import 'package:knowledge_hub_mobile/models/paymentInfo.dart';
import 'package:knowledge_hub_mobile/views/changeAddress.dart';
import 'package:knowledge_hub_mobile/views/changePaymentInfo.dart';
import '../models/address.dart';
import 'package:http/http.dart' as http;
import '../models/book.dart';
import '../models/city.dart';
import '../models/order.dart';
import '../services/accountService.dart';
import '../services/persistentDataService.dart';

class CartWidget extends StatefulWidget {
  @override
  CartState createState() => CartState();
}

class CartState extends State<CartWidget> {
  bool viewingPayment = false;
  int step = 0;
  CardDetails card = CardDetails();
  List<CartItem> cartItems = List<CartItem>.empty(growable: true);
  String paymentIntentId = "";

  Widget getPaymentWidget() {
    var paymentWidget = PaymentWidget();
    paymentWidget.cancelOrderEvent.subscribe((args) {
      setState(() {
        viewingPayment = false;
      });
    });
    return paymentWidget;
  }

  initiateOrder() async {
    if (PersistentDataService.instance.cities
            .firstWhere(
                (element) =>
                    element.Name == AccountService.instance.addressData.City,
                orElse: () => City())
            .Name ==
        "") {
      PersistentDataService.instance.screenWideNotification
          .broadcast(Value<String>("Please update address!"));
    }
    List<int> books = List<int>.empty(growable: true);
    List<bool> digital = List<bool>.empty(growable: true);
    for (var element in cartItems) {
      books.add(element.book.BookId);
      digital.add(element.digital);
    }
  }

  Future<Map<String, dynamic>> fetchPaymentIntentClientSecret() async {
    final url = Uri.parse(
        '${PersistentDataService.instance.BackendUri}/api/Order/InitiatePayment?amount=100&userId=${AccountService.instance.userData.UserId}');
    final response = await http.get(
      url,
      headers: {
        'Content-Type': 'application/json',
        'Authorization':
            "Basic ${base64Encode(utf8.encode('${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}'))}"
      },
    );
    return json.decode(response.body);
  }

  Future<void> initializePaymentSheet() async {
    try {
      Stripe.publishableKey =
          "pk_test_51LDPJEJa87uOA78AXxsAkQOeNKIxlpqz7fh5D4QRNDwTCEr4ImQPeRb3swjMkE9JDobQ7jP7rpUztawadJbDSMjb0037qRk2Va";
      await Stripe.instance.applySettings();
      final sheetData = await createPaymentSheet();
      paymentIntentId = sheetData['paymentIntent'];

      await Stripe.instance.initPaymentSheet(
        paymentSheetParameters: SetupPaymentSheetParameters(
            customFlow: true,
            merchantDisplayName: "Knowledge Hub",
            paymentIntentClientSecret: sheetData['clientSecret'],
            customerEphemeralKeySecret: sheetData['ephermalKey'],
            customerId: sheetData['customer'],
            testEnv: true,
            applePay: true,
            googlePay: true),
      );

      setState(() {
        step = 1;
      });
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Error: $e')),
      );
      rethrow;
    }
  }

  Future<Map<String, dynamic>> createPaymentSheet() async {
    final url = Uri.parse(
        '${PersistentDataService.instance.BackendUri}/api/Order/InitiatePayment');
    final response = await http.post(url,
        headers: {
          'Content-Type': 'application/json',
          'Authorization':
              "Basic ${base64Encode(utf8.encode('${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}'))}"
        },
        body: createOrderRequest());
    if (response.body == "") {
      throw Exception('Empty response');
    }
    return json.decode(response.body);
  }

  Future<void> displayPaymentSheet() async {
    await Stripe.instance.presentPaymentSheet();
    setState(() {
      step = 2;
    });
  }

  Future<void> confirmPayment() async {
    try {
      await Stripe.instance.confirmPaymentSheetPayment();

      final response = await http.post(
          Uri.parse(
              '${PersistentDataService.instance.BackendUri}/api/Order/InsertMany'),
          headers: {
            'Content-Type': 'application/json',
            'Authorization':
                "Basic ${base64Encode(utf8.encode('${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}'))}"
          },
          body: createOrderRequest());
      if (response.statusCode == 200) {
        setState(() {
          step = 0;
          viewingPayment = false;
          clearCart();
          PersistentDataService.instance.screenWideNotification
              .broadcast(Value<String>("Payment Complete!"));
        });
      } else {
        setState(() {
          step = 0;
          viewingPayment = false;
          PersistentDataService.instance.screenWideNotification
              .broadcast(Value<String>("Error processing payment!"));
        });
      }
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Error: $e')),
      );
      rethrow;
    }
  }

  getCart() {
    List<Widget> cartList = List<Widget>.empty(growable: true);
    for (var cartItem in cartItems) {
      var cartItemWidget = CartItemViewWidget(cartItem);
      cartItemWidget.bookRemoveEvent.subscribe((args) {
        removeFromCart(args!.value.BookId);
      });

      cartList.add(cartItemWidget);
    }
    cartList.add(const SizedBox(
      height: 50,
    ));
    return cartList;
  }

  List<Row> getCartItemsAndPrices() {
    List<Row> list = List<Row>.empty(growable: true);
    for (var cartItem in cartItems) {
      list.add(Row(
        children: [
          Container(
            width: 240,
            child: Text(
              cartItem.book.BookName,
              overflow: TextOverflow.ellipsis,
            ),
          ),
          Spacer(),
          Text((cartItem.digital
              ? cartItem.book.PriceDigital.toString()
              : cartItem.book.PricePhysical.toString())),
        ],
      ));
    }

    return list;
  }

  double getPriceSummary() {
    double summary = 0;
    for (var cartItem in cartItems) {
      summary += cartItem.digital
          ? cartItem.book.PriceDigital
          : cartItem.book.PricePhysical;
    }
    return summary;
  }

  removeFromCart(int bookId) {
    setState(() {
      AccountService.instance.cart
          .removeWhere((element) => element.book == bookId);
      AccountService.instance.saveFileToDisk();
      cartItems.removeWhere((element) => element.book.BookId == bookId);
    });
  }

  clearCart() {
    AccountService.instance.cart.clear();
    AccountService.instance.saveFileToDisk();
    cartItems.clear();
  }

  createOrderRequest() {
    List<int> books = List<int>.empty(growable: true);
    List<bool> digital = List<bool>.empty(growable: true);

    cartItems.forEach((element) {
      books.add(element.book.BookId);
      digital.add(element.digital);
    });

    int cityId = 0;
    if (digital.contains(false) &&
        AccountService.instance.addressData.City == "") {
      PersistentDataService.instance.screenWideNotification.broadcast(
          Value<String>("Update your address before ordering a physical copy"));
      return;
    }

    cityId = PersistentDataService.instance.cities
        .firstWhere(
            (element) =>
                element.Name == AccountService.instance.addressData.City,
            orElse: (() => City()))
        .CityId;

    return jsonEncode({
      'books': books,
      'digital': digital,
      'userId': AccountService.instance.userData.UserId,
      'userFullName': AccountService.instance.addressData.FullName,
      'orderDate': DateTime.now().toUtc().toString(),
      'addressLine': AccountService.instance.addressData.AdressLine,
      'cityId': cityId,
      'paymentIntent': paymentIntentId
    });
  }

  @override
  void initState() {
    super.initState();
    PersistentDataService.instance.cart.forEach((element) {
      cartItems.add(element);
    });
  }

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        SingleChildScrollView(
          child: viewingPayment
              ? Stepper(
                  controlsBuilder: controlBuilder,
                  currentStep: step,
                  steps: [
                    Step(
                        title: Text("Review your order"),
                        content: Column(
                          children: [
                            Column(
                              children: getCartItemsAndPrices(),
                            ),
                            Divider(
                              height: 10,
                              thickness: 1,
                            ),
                            Row(children: [
                              Text("Summary:"),
                              Spacer(),
                              Text(getPriceSummary().toString()),
                            ]),
                            LoadingButton(
                              onPressed: () => initializePaymentSheet(),
                              text: "Looks good",
                            )
                          ],
                        )),
                    Step(
                        title: Text("Select payment method"),
                        content: LoadingButton(
                          onPressed: () => displayPaymentSheet(),
                          text: "Select payment method",
                        )),
                    Step(
                        title: Text("Confirm payment"),
                        content: LoadingButton(
                          onPressed: () => confirmPayment(),
                          text: "Pay Now",
                        )),
                  ],
                )
              : Column(
                  children: getCart(),
                ),
        ),
        (!viewingPayment && AccountService.instance.cart.isNotEmpty)
            ? Positioned(
                height: 50,
                width: MediaQuery.of(context).size.width,
                bottom: 0,
                child: ElevatedButton(
                  style: ButtonStyle(
                      backgroundColor: MaterialStateProperty.all(Colors.green)),
                  onPressed: () {
                    setState(() {
                      viewingPayment = true;
                      step = 0;
                    });
                  },
                  child: const Text("Checkout"),
                ),
              )
            : Container(),
        AccountService.instance.cart.isEmpty
            ? Center(
                child: Text("No books in cart..."),
              )
            : Container()
      ],
    );
  }
}

final ControlsWidgetBuilder controlBuilder = (_, __) => Container();
