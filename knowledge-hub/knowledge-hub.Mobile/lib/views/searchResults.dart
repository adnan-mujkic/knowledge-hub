import 'dart:convert';
import '../services/persistentDataService.dart';
import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/components/bookViewInList.dart';
import 'package:event/event.dart';
import 'package:http/http.dart' as http;
import 'package:knowledge_hub_mobile/services/accountService.dart';

import '../models/book.dart';

class SearchResultsWidget extends StatefulWidget {
  SearchResultsWidget(this.searchedBooks, {Key? key}) : super(key: key);

  var selectedBookEvent = Event<Value<Book>>();
  List<Book> searchedBooks = List<Book>.empty(growable: true);

  @override
  SearchResultsState createState() => SearchResultsState();
}

class SearchResultsState extends State<SearchResultsWidget> {
  late Book selectedBook = new Book();
  late bool loaded = false;

  selectBook() {
    widget.selectedBookEvent.broadcast(Value<Book>(selectedBook));
  }

  List<Widget> constructListWidget() {
    List<Widget> temp = List<Widget>.empty(growable: true);

    for (var bookValue in widget.searchedBooks) {
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
    return Center(
        child: GridView.count(
      crossAxisCount: 3,
      crossAxisSpacing: 30,
      mainAxisSpacing: 30,
      shrinkWrap: false,
      padding: EdgeInsets.all(20),
      childAspectRatio: 0.47,
      children: constructListWidget(),
    ));
  }
}
