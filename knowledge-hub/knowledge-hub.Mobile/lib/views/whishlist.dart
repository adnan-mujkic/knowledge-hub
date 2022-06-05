import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/components/bookViewInList.dart';
import 'package:event/event.dart';
import 'package:knowledge_hub_mobile/views/bookView.dart';

import '../models/book.dart';

class WishlistWidget extends StatefulWidget {
  WishlistWidget({Key? key}) : super(key: key);

  var selectedBookEvent = Event<Value<Book>>();

  @override
  WhishlistState createState() => WhishlistState();
}

class WhishlistState extends State<WishlistWidget> {
  late Book selectedBook = new Book();

  selectBook(){
    widget.selectedBookEvent.broadcast(Value<Book>(selectedBook));
  }

  List<Widget> constructListWidget(){
    List<Widget> temp = List<Widget>.empty(growable: true);
    var bookInList = BookInListWidget(Book());
    bookInList.bookSelectedEvent.subscribe((args) {
      selectedBook = args!.value;
      selectBook();
    });
    temp.add(bookInList);
    return temp;
  }


  @override
  Widget build(BuildContext context) {
    return Center(
      child: GridView.count(
        crossAxisCount: 2,
        crossAxisSpacing: 30,
        mainAxisSpacing: 30,
        shrinkWrap: false,
        padding: EdgeInsets.all(20),
        childAspectRatio: 0.47,
        children: constructListWidget(),
      )
    );
  }
}
