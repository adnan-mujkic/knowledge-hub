import 'package:flutter/material.dart';
import '../models/book.dart';
import '../models/cartItem.dart';
import '../models/loginRegister.dart';
import 'package:event/event.dart';

class CartItemViewWidget extends StatefulWidget {
  CartItemViewWidget(this.cartItem, {Key? key}) : super(key: key);

  var bookSelectedEvent = Event<Value<Book>>();
  var bookRemoveEvent = Event<Value<Book>>();
  CartItem cartItem;

  @override
  CartItemViewState createState() => CartItemViewState();
}

class CartItemViewState extends State<CartItemViewWidget> {
  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.only(top: 5, bottom: 5, right: 10, left: 10),
      height: 120,
      decoration: const BoxDecoration(
        borderRadius: BorderRadius.all(Radius.circular(10)),
        color: Colors.white,
      ),
      child: Row(
        children: [
          Container(
            margin: const EdgeInsets.all(10),
            child: FadeInImage(
              image: NetworkImage(widget.cartItem.book.ImagePath),
              placeholder: const AssetImage("assets/book.png"),
            ),
          ),
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(
                height: 10,
              ),
              SizedBox(
                width: 160,
                child: Text(
                  widget.cartItem.book.BookName,
                  style: const TextStyle(fontWeight: FontWeight.bold),
                  overflow: TextOverflow.ellipsis,
                  maxLines: 3,
                  softWrap: false,
                ),
              ),
              const SizedBox(
                height: 5,
              ),
              Text(widget.cartItem.book.Author),
              Text(widget.cartItem.digital ? "Digital" : "Physical"),
              Text(widget.cartItem.digital
                  ? widget.cartItem.book.PriceDigital.toString()
                  : widget.cartItem.book.PricePhysical.toString()),
            ],
          ),
          const Spacer(),
          Container(
            margin: const EdgeInsets.all(10),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.end,
              children: [
                ElevatedButton(
                    onPressed: () {
                      widget.bookRemoveEvent
                          .broadcast(Value<Book>(widget.cartItem.book));
                    },
                    child: const Text("Remove"))
              ],
            ),
          )
        ],
      ),
    );
  }
}
