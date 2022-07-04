import 'package:flutter/material.dart';
import '../models/book.dart';
import '../models/loginRegister.dart';
import 'package:event/event.dart';

class BookInListWidget extends StatefulWidget {
  BookInListWidget(this.book, this.width, {Key? key}) : super(key: key);

  double width;
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
        width: widget.width,
        decoration: const BoxDecoration(
          borderRadius: BorderRadius.all(Radius.circular(10)),
          color: Colors.white,
        ),
        child: Column(
          children: [
            Container(
              width: widget.width,
              height: widget.width * 1.4,
              child: Container(
                margin: EdgeInsets.all(10),
                decoration: BoxDecoration(boxShadow: [
                  BoxShadow(
                    color: Colors.blueGrey.withOpacity(0.2),
                    spreadRadius: 5,
                    blurRadius: 7,
                    offset: Offset(0, 3),
                  )
                ]),
                child: ClipRRect(
                  borderRadius: BorderRadius.circular(10),
                  child: FadeInImage(
                    image: NetworkImage(widget.book.ImagePath),
                    placeholder: const AssetImage("assets/book.png"),
                  ),
                ),
              ),
            ),
            const SizedBox(
              height: 10,
            ),
            Container(
              padding: const EdgeInsets.only(left: 10, right: 10),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.stretch,
                children: [
                  Container(
                    height: 30,
                    child: Text(
                      widget.book.BookName,
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 10),
                      overflow: TextOverflow.ellipsis,
                      maxLines: 2,
                    ),
                  ),
                  const Divider(
                      height: 10,
                      thickness: 1,
                      color: Color.fromARGB(30, 0, 0, 0)),
                  Text(
                    widget.book.Author,
                    style: TextStyle(fontSize: 8),
                    overflow: TextOverflow.ellipsis,
                    maxLines: 1,
                  ),
                  SizedBox(
                    height: 8,
                  ),
                  Align(
                    alignment: Alignment.centerRight,
                    child: Text(
                      "${widget.book.PricePhysical.toString()} KM",
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 10),
                    ),
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
