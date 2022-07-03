import 'dart:convert';
import '../services/persistentDataService.dart';
import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/components/bookViewInList.dart';
import 'package:event/event.dart';
import 'package:http/http.dart' as http;
import 'package:knowledge_hub_mobile/services/accountService.dart';

import '../models/book.dart';

class WishlistWidget extends StatefulWidget {
  WishlistWidget({Key? key}) : super(key: key);

  var selectedBookEvent = Event<Value<Book>>();
  List<Book> wishlistBooks = List<Book>.empty(growable: true);

  @override
  WhishlistState createState() => WhishlistState();
}

class WhishlistState extends State<WishlistWidget> {
  late Book selectedBook = new Book();
  late bool loaded = false;
  late List<Book> wishlistBooks = List<Book>.empty(growable: true);

  WhishlistState(){
    fetchWishlistBooks();
  }

  fetchWishlistBooks()async{
    final response = await http.get(
      Uri.parse('${PersistentDataService.instance.BackendUri}/api/Wishlist/WishlistByUserId?userId=${AccountService.instance.userData.UserId.toString()}'),
      headers: <String, String>{
        'Content-Type' : 'application/json; charset=UTF-8',
        'Authorization' : "Basic ${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}"
      }
    );
    if(response.statusCode == 200){
      var jsonBody = jsonDecode(response.body);

      setState((){
        Iterable iterable = jsonBody;
        wishlistBooks = List<Book>.from(iterable.map((e) => Book.fromJson(e)));
        loaded = true;
      });
    }
  }

  selectBook(){
    widget.selectedBookEvent.broadcast(Value<Book>(selectedBook));
  }

  List<Widget> constructListWidget(){
    List<Widget> temp = List<Widget>.empty(growable: true);

    for (var bookValue in wishlistBooks) {
      var bookInList = BookInListWidget(bookValue, 90);
      bookInList.bookSelectedEvent.subscribe((args) {
        selectedBook = args!.value;
        selectBook();
      });
      temp.add(bookInList);
    }

    return temp;
  }

  @override
  Widget build(BuildContext context) {
    return loaded? Center(
      child: GridView.count(
        crossAxisCount: 3,
        crossAxisSpacing: 30,
        mainAxisSpacing: 30,
        shrinkWrap: false,
        padding: EdgeInsets.all(20),
        childAspectRatio: 0.47,
        children: constructListWidget(),
      )
    ) :
    Center(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: const [
          CircularProgressIndicator(),
          SizedBox(height: 20),
          Text("Loading...")
        ],
      ),
    );
  }
}
