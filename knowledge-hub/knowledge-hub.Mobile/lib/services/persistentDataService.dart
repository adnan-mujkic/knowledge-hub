import 'dart:convert';

import 'package:event/event.dart';
import 'package:knowledge_hub_mobile/models/city.dart';
import 'package:http/http.dart' as http;
import 'package:knowledge_hub_mobile/services/accountService.dart';

import '../models/book.dart';
import '../models/cartItem.dart';

class PersistentDataService {
  PersistentDataService._privateConstructor();
  static final PersistentDataService instance =
      PersistentDataService._privateConstructor();

  String BackendUri = "http://10.0.2.2:5000";
  //String BackendUri = "http://10.0.2.2:5125";
  List<City> cities = List<City>.empty(growable: true);
  List<CartItem> cart = List<CartItem>.empty(growable: true);
  var screenWideNotification = Event<Value<String>>();

  fetchCities() async {
    final response = await http.get(
      Uri.parse('$BackendUri/api/City'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
        'Authorization':
            "Basic ${base64Encode(utf8.encode('${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}'))}"
      },
    );

    if (response.statusCode == 200) {
      List<dynamic> map = jsonDecode(response.body) as List<dynamic>;
      map.forEach((element) {
        City city = City.fromJson(element);
        cities.add(city);
      });
    }
  }

  fetchCartItems() async {
    if (AccountService.instance.cart.isEmpty) return;

    for (var i = 0; i < AccountService.instance.cart.length; i++) {
      final response = await http.get(
        Uri.parse(
            '$BackendUri/api/Book/${AccountService.instance.cart[i].book}'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Authorization':
              "Basic ${base64Encode(utf8.encode('${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}'))}"
        },
      );

      if (response.statusCode == 200) {
        var jsonObject = jsonDecode(response.body);
        Book book = Book.fromJson(jsonObject);

        CartItem ci = CartItem();
        ci.book = book;
        ci.digital = AccountService.instance.cart[i].digital;
        cart.add(ci);
      }
    }
  }
}
