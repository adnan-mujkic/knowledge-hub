import 'dart:convert';
import 'dart:io';
import 'package:flutter/material.dart';
import 'package:path_provider/path_provider.dart';
import 'package:knowledge_hub_mobile/models/address.dart';
import 'package:knowledge_hub_mobile/models/paymentInfo.dart';
import 'package:knowledge_hub_mobile/models/user.dart';

import '../models/authData.dart';
import '../models/book.dart';
import '../models/cartItemSave.dart';

class AccountService {
  AccountService._privateConstructor() {
    authData = AuthData();
    userData = User();
    addressData = Address();
    paymentData = PaymentInfo();
    myBooks = List<Book>.empty(growable: true);
    wishlist = List<int>.empty(growable: true);
    cart = List<CartItemSave>.empty(growable: true);

    loadFileFromDisk();
  }
  static final AccountService instance = AccountService._privateConstructor();

  AuthData authData = AuthData();
  User userData = User();
  Address addressData = Address();
  PaymentInfo paymentData = PaymentInfo();
  List<Book> myBooks = List<Book>.empty(growable: true);
  List<int> wishlist = List<int>.empty(growable: true);
  List<CartItemSave> cart = List<CartItemSave>.empty(growable: true);

  Map<String, dynamic> toJson() => {
        'authData': authData,
        'userData': userData,
        'addressData': addressData,
        'paymentData': paymentData,
        'myBooks': myBooks,
        'wishlist': wishlist,
        'cart': cart,
      };
  AccountService.fromJson(Map<String, dynamic> jsonFile)
      : authData = AuthData.fromJson(jsonFile['authData']),
        userData = User.fromJson(jsonFile['userData']),
        addressData = jsonFile['addressData'] != null
            ? Address.fromJson(jsonFile['addressData'])
            : Address(),
        paymentData = jsonFile['paymentData'] != null
            ? PaymentInfo.fromJson(jsonFile['paymentData'])
            : PaymentInfo(),
        myBooks = jsonFile['myBooks'] != null
            ? List<Book>.from(jsonFile['myBooks'])
            : List<Book>.empty(growable: true),
        wishlist = List<int>.empty(growable: true),
        cart = jsonFile['cart'] != null
            ? List<CartItemSave>.from(jsonFile['cart'])
            : List<CartItemSave>.empty(growable: true);

  static getWishlistFromMap(dynamic map) {
    List<Book> books = [];
    map.forEach((element) {
      books.add(Book.fromJson(element));
    });
    return books;
  }

  Future<bool> saveFileToDisk() async {
    var rootPath = await getApplicationDocumentsDirectory();
    var filePath = "${rootPath.path}/accountData.json";
    var actualFile = File(filePath);

    try {
      var jsonObject = jsonEncode(this);
      await actualFile.writeAsString(jsonObject);

      debugPrint("Saved to disk");
      debugPrint(jsonObject);
      return true;
    } catch (e) {
      return false;
    }
  }

  Future<bool> loadFileFromDisk() async {
    var filePath =
        "${(await getApplicationDocumentsDirectory()).path}/accountData.json";
    var actualFile = File(filePath);

    if (await actualFile.exists() == false) {
      return false;
    }

    var jsonString = await actualFile.readAsString();
    var jsonObject = jsonDecode(jsonString);

    debugPrint(jsonObject.toString());

    instance.authData = AuthData.fromJson(jsonObject['authData']);
    instance.userData = User.fromJson(jsonObject['userData']);
    instance.addressData = Address.fromJson(jsonObject['addressData']);
    instance.paymentData = PaymentInfo.fromJson(jsonObject['paymentData']);
    Iterable iterable = jsonObject['myBooks'];
    instance.myBooks = List<Book>.from(iterable.map((e) => Book.fromJson(e)));
    iterable = jsonObject['wishlist'];
    instance.wishlist = List<int>.from(iterable.map((e) => e));
    iterable = jsonObject['cart'];
    instance.cart =
        List<CartItemSave>.from(iterable.map((e) => CartItemSave.fromJson(e)));

    await Future.delayed(const Duration(milliseconds: 500));
    return true;
  }

  void LogOut() async {
    authData = AuthData();
    userData = User();
    addressData = Address();
    paymentData = PaymentInfo();
    myBooks = List<Book>.empty(growable: true);
    wishlist = List<int>.empty(growable: true);
    cart = List<CartItemSave>.empty(growable: true);

    var filePath =
        "${(await getApplicationDocumentsDirectory()).path}/accountData.json";
    var actualFile = File(filePath);

    if (await actualFile.exists() == false) {
      return;
    }
    await actualFile.delete();
  }
}
