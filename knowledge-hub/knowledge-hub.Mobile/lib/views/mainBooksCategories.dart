import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/components/bookViewInList.dart';
import 'package:event/event.dart';
import 'package:knowledge_hub_mobile/views/bookView.dart';
import 'package:http/http.dart' as http;
import '../models/book.dart';
import '../services/accountService.dart';
import '../services/persistentDataService.dart';

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

  selectBook() {
    widget.selectedBookEvent.broadcast(Value<Book>(selectedBook));
  }

  List<Widget> constructListWidget(List<Book>? recommendations) {
    List<Widget> temp = List<Widget>.empty(growable: true);

    Map<String, List<Book>> bookCategoryMap = <String, List<Book>>{};
    widget.allBooks.forEach((element) {
      if (!bookCategoryMap.containsKey(element.Category)) {
        List<Book> categoryList = List<Book>.filled(1, element, growable: true);
        bookCategoryMap[element.Category] = categoryList;
      } else {
        bookCategoryMap[element.Category]?.add(element);
      }
    });

    if (recommendations != null && recommendations.isNotEmpty) {
      temp.add(getRowContainer(recommendations, "Recommendations"));
    }

    bookCategoryMap.forEach((key, value) {
      temp.add(getRowContainer(value, key));
    });

    return temp;
  }

  Widget getRowContainer(List<Book> books, String categoryName) {
    List<Container> bookContainers = List<Container>.empty(growable: true);
    books.forEach((bookElement) {
      var bookInView = BookInListWidget(bookElement, 120);
      bookInView.bookSelectedEvent.subscribe((args) {
        setState(() {
          selectedBook = args!.value;
          selectBook();
        });
      });
      bookContainers.add(Container(
        margin: EdgeInsets.only(right: 10),
        child: bookInView,
      ));
    });

    return Container(
      margin: EdgeInsets.only(top: 0, bottom: 10),
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
                      bottom: BorderSide(
                          width: 1, color: Colors.black.withOpacity(0.1)))),
              child: InkWell(
                child: Row(
                  children: [
                    Text(categoryName),
                    SizedBox(
                      width: 5,
                    ),
                    Icon(
                      Icons.keyboard_arrow_right,
                      color: Colors.black.withOpacity(0.7),
                    )
                  ],
                ),
                onTap: () {
                  debugPrint("Tapped category: ${categoryName}");
                },
              ),
            ),
          ),
          SizedBox(
            height: 10,
          ),
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

  Future<List<Book>> getRecommendations() async {
    final response = await http.get(
        Uri.parse(
            '${PersistentDataService.instance.BackendUri}/api/Book/RecommenedCourses?userId=${AccountService.instance.userData.UserId}'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Authorization':
              "Basic ${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}"
        });
    if (response.statusCode == 200) {
      var jsonBody = jsonDecode(response.body);
      Iterable iterable = jsonBody;

      var books = List<Book>.from(iterable.map((e) => Book.fromJson(e)));
      return books;
    }
    return List<Book>.empty(growable: true);
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: FutureBuilder<List<Book>>(
        future: getRecommendations(),
        builder: (context, snapshot) {
          if (snapshot.hasData && snapshot.data != null) {
            return Column(
              children: constructListWidget(snapshot.data),
            );
          }
          return Column(
            children: constructListWidget(null),
          );
        },
      ),
    );
  }
}
