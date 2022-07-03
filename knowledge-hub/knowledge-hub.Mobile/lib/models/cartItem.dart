import 'dart:convert';

import 'package:knowledge_hub_mobile/models/book.dart';

class CartItem{
  Book book = Book();
  bool digital = true;

  CartItem();
  Map<String, dynamic> toJson() => {
    'book': book,
    'digital' : digital,
  };

  CartItem.fromJson(Map<String, dynamic> jsonFile):
        book = jsonFile['book']==null? jsonDecode(jsonFile['book']) : Book(),
        digital = jsonFile['digital']??true;
}