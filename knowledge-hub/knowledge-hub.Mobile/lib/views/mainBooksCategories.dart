import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/components/bookViewInList.dart';
import 'package:event/event.dart';
import 'package:knowledge_hub_mobile/views/bookView.dart';

import '../models/book.dart';

class MainBooksCategoriesWidget extends StatefulWidget {
  MainBooksCategoriesWidget(this.allBooks, {Key? key}) : super(key: key);

  List<Book> allBooks;
  var selectedBookEvent = Event<Value<Book>>();

  @override
  MainBooksCategoriesState createState() => MainBooksCategoriesState();
}

class MainBooksCategoriesState extends State<MainBooksCategoriesWidget> {
  late Book selectedBook = new Book();
  late Map<String, Book> OrderedBooksMap;

  selectBook(){
    widget.selectedBookEvent.broadcast(Value<Book>(selectedBook));
  }

  List<Widget> constructListWidget(){
    List<Widget> temp = List<Widget>.empty(growable: true);

    Map<String, List<Book>> bookCategoryMap = <String, List<Book>>{};
    widget.allBooks.forEach((element) {
      if(!bookCategoryMap.containsKey(element.Category)){
        List<Book> categoryList = List<Book>.filled(1, element,growable: true);
        bookCategoryMap[element.Category] = categoryList;
      }else{
        bookCategoryMap[element.Category]?.add(element);
      }
    });

    bookCategoryMap.forEach((key, value) {
      temp.add(getRowContainer(value, key));
    });

    return temp;
  }

  Widget getRowContainer(List<Book> books, String categoryName){
    List<Container> bookContainers = List<Container>.empty(growable: true);
    books.forEach((bookElement) {
      var bookInView = BookInListWidget(bookElement, 120);
      bookInView.bookSelectedEvent.subscribe((args) {
        setState((){
          selectedBook = args!.value;
          selectBook();
        });
      });
      bookContainers.add(
          Container(
            margin: EdgeInsets.only(right: 10),
            child: bookInView,
          )
      );
    });

    return Container(
      margin: EdgeInsets.only(top: 10, bottom: 10),
      color: Colors.white,
      height: 310,
      width: double.infinity,
      padding: EdgeInsets.all(10),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Expanded(
            child: Container(
              decoration: BoxDecoration(
                border: Border(
                  bottom: BorderSide(width: 1, color: Colors.black.withOpacity(0.1))
                )
              ),
              child: InkWell(
                child: Row(
                  children: [
                    Text(categoryName),
                    SizedBox(width: 5,),
                    Icon(Icons.keyboard_arrow_right, color: Colors.black.withOpacity(0.7),)
                  ],
                ),
                onTap: (){debugPrint("Tapped category: ${categoryName}");},
              ),
            ),
          ),
          SizedBox(height: 10,),
          SingleChildScrollView(
            scrollDirection: Axis.horizontal,
            child: Row(
              children: bookContainers,
            ),
          )
        ],
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        children: constructListWidget(),
      ),
    );
  }
}
