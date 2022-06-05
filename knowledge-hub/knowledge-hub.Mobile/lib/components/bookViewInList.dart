import 'package:flutter/material.dart';
import '../models/book.dart';
import '../models/loginRegister.dart';
import 'package:event/event.dart';

class BookInListWidget extends StatefulWidget {
  BookInListWidget(this.book, {Key? key}) : super(key: key);

  var bookSelectedEvent = Event<Value<Book>>();
  Book book;

  @override
  BookInListState createState() => BookInListState();
}

class BookInListState extends State<BookInListWidget> {
  @override
  Widget build(BuildContext context) {
    return InkWell(
      child: Container(
        width: 100,
        decoration: const BoxDecoration(
          borderRadius: BorderRadius.all(Radius.circular(10)),
          color:  Colors.white,
        ),
        child: Column(
          children: [
            Container(
              decoration: BoxDecoration(
                  boxShadow: [
                    BoxShadow(
                      color: Colors.blueGrey.withOpacity(0.2),
                      spreadRadius: 5,
                      blurRadius: 7,
                      offset: Offset(0, 3),
                    )
                  ]
              ),
              child: ClipRRect(
                borderRadius: BorderRadius.circular(10),
                child: Image.asset(
                  'assets/book.png',
                  fit: BoxFit.contain,
                  scale: 1,
                ),
              ),
            ),
            const SizedBox(
              height: 20,
            ),
            Container(
              padding: const EdgeInsets.only(left: 10, right: 10),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.stretch,
                children: [
                  Text(
                    widget.book.BookName,
                    style: TextStyle(
                        fontWeight: FontWeight.bold
                    ),),
                  const Divider(
                      height: 10,
                      thickness: 1,
                      color: Color.fromARGB(30, 0, 0, 0)
                  ),
                  Text(widget.book.AuthorName),
                  SizedBox(
                    height: 10,
                  ),
                  Align(
                    alignment: Alignment.centerRight,
                    child: Text("${widget.book.PricePhysical.toString()} KM"),
                  )
                ],
              ),
            )
          ],
        ),
      ),
      onTap: () {
        widget.bookSelectedEvent.broadcast(Value<Book>(widget.book));
      },
    );
  }
}
