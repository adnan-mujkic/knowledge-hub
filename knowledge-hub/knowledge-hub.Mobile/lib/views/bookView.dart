import 'dart:convert';

import 'package:event/event.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:knowledge_hub_mobile/components/comment.dart';
import 'package:knowledge_hub_mobile/models/cartItem.dart';
import 'package:knowledge_hub_mobile/models/comment.dart';
import 'package:knowledge_hub_mobile/services/persistentDataService.dart';
import '../models/book.dart';
import 'package:expandable_text/expandable_text.dart';
import 'package:http/http.dart' as http;

import '../models/cartItemSave.dart';
import '../models/order.dart';
import '../services/accountService.dart';

class BookViewWidget extends StatefulWidget {
  BookViewWidget(this.book, {Key? key}) : super(key: key);

  late Book book;
  bool bookInWishlist = false;
  int? digitalSelected = 0;
  int reviewScore = 1;
  String commentText = "";

  List<Widget> getStars() {
    List<Widget> icons = new List<Widget>.empty(growable: true);
    for (int i = 0; i < book.Rating.floor(); i++) {
      icons.add(Icon(
        Icons.star,
        color: Colors.yellow,
      ));
    }
    icons.add(getStarWithFill(book.Rating - book.Rating.floor()));
    for (int i = 0; i < 5 - book.Rating.ceil(); i++) {
      icons.add(Icon(Icons.star, color: Colors.black.withOpacity(0.4)));
    }
    return icons;
  }

  getStarWithFill(double percentage) {
    return ShaderMask(
      blendMode: BlendMode.srcATop,
      shaderCallback: (Rect rect) {
        return LinearGradient(
          stops: [0, 0.5, 0.5],
          colors: [Colors.yellow, Colors.yellow, Colors.black.withOpacity(0.4)],
        ).createShader(rect);
      },
      child: SizedBox(
        child: Icon(Icons.star, color: Colors.grey[300]),
      ),
    );
  }

  @override
  BookViewState createState() => BookViewState();
}

class BookViewState extends State<BookViewWidget> {
  int currentlyDisplayedComments = 0;
  List<Comment> comments = List<Comment>.empty(growable: true);
  List<Widget> commentsWidgets = List<Widget>.empty(growable: true);
  late Future<List<Comment>> futureComments;
  bool userCommentExists = true;

  @override
  void initState() {
    super.initState();
    futureComments = getReviews(widget.book.BookId);
  }

  selectStar(int index) {
    setState(() {
      widget.reviewScore = index;
    });
  }

  checkIfBookInWishlist() {
    for (var value in AccountService.instance.wishlist) {
      if (value == widget.book.BookId) {
        return true;
      }
    }
    return false;
  }

  addOrRemoveFromWishlist() async {
    if (checkIfBookInWishlist()) {
      final response = await http.delete(
        Uri.parse(
            '${PersistentDataService.instance.BackendUri}/api/Wishlist?ID=${widget.book.BookId}'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Authorization':
              "Basic ${base64Encode(utf8.encode('${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}'))}"
        },
      );
      if (response.statusCode == 200) {
        debugPrint(response.body);
        AccountService.instance.wishlist
            .removeWhere((element) => element == widget.book.BookId);
        AccountService.instance.saveFileToDisk();
        setState(() {});
      }
    } else {
      final response = await http.post(
        Uri.parse('${PersistentDataService.instance.BackendUri}/api/Wishlist'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Authorization':
              "Basic ${base64Encode(utf8.encode('${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}'))}"
        },
        body: jsonEncode({
          'bookId': widget.book.BookId,
          'userId': AccountService.instance.userData.UserId
        }),
      );
      if (response.statusCode == 200) {
        var book = Book.fromJson(jsonDecode(response.body)['book']);
        AccountService.instance.wishlist.add(book.BookId);
        AccountService.instance.saveFileToDisk();
        setState(() {});
      }
    }
  }

  void addToCart() async {
    bool exists = AccountService.instance.cart
        .where((element) => element.book == widget.book.BookId)
        .isNotEmpty;
    if (exists) {
      PersistentDataService.instance.screenWideNotification
          .broadcast(Value<String>("Book already in cart!"));
      return;
    }

    var newOrder = CartItemSave();
    newOrder.book = widget.book.BookId;
    newOrder.digital = widget.digitalSelected! == 0 ? true : false;
    AccountService.instance.cart.add(newOrder);
    await AccountService.instance.saveFileToDisk();

    await PersistentDataService.instance.fetchCartItems();

    PersistentDataService.instance.screenWideNotification
        .broadcast(Value<String>("Added to cart"));
  }

  initializeComments(List<Comment> commentsToDisplay) {
    userCommentExists = false;
    commentsWidgets.removeRange(0, commentsWidgets.length);
    comments.removeRange(0, comments.length);

    comments = commentsToDisplay;
    currentlyDisplayedComments = comments.length >= 4 ? 4 : comments.length;
    for (int i = 0; i < currentlyDisplayedComments; i++) {
      commentsWidgets.add(Container(
        padding: const EdgeInsets.only(top: 5, bottom: 5),
        child: CommentWidget(comments[i]),
      ));
    }

    return commentsWidgets;
  }

  postReview() async {
    final response = await http.post(
        Uri.parse('${PersistentDataService.instance.BackendUri}/api/Review'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Authorization':
              "Basic ${base64Encode(utf8.encode('${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}'))}"
        },
        body: jsonEncode({
          'userId': AccountService.instance.userData.UserId,
          'bookId': widget.book.BookId,
          'rating': widget.reviewScore,
          'commentText': widget.commentText
        }));
    if (response.statusCode == 200) {}
  }

  Future<List<Comment>> getReviews(int bookId) async {
    final response = await http.get(
        Uri.parse(
            '${PersistentDataService.instance.BackendUri}/api/Review/GetByBook?bookId=$bookId'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Authorization':
              "Basic ${base64Encode(utf8.encode('${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}'))}"
        });
    if (response.statusCode == 200) {
      var jsonBody = jsonDecode(response.body);
      Iterable iterable = jsonBody;

      var comments =
          List<Comment>.from(iterable.map((e) => Comment.fromJson(e)));

      bool commentExists = false;
      comments.forEach((element) {
        if (element.UserId == AccountService.instance.userData.UserId) {
          commentExists = true;
        }
      });

      setState(() {
        userCommentExists = commentExists;
      });

      return comments;
    }
    return List<Comment>.empty();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          SingleChildScrollView(
              child: Container(
            color: Colors.black.withOpacity(0.1),
            child: Align(
              alignment: Alignment.bottomCenter,
              child: Container(
                  margin: EdgeInsets.only(top: 10, right: 30, left: 30),
                  child: Column(
                    children: [
                      Container(
                        margin: EdgeInsets.only(top: 10),
                        child: Text(
                          widget.book.BookName,
                          style: TextStyle(
                              fontSize: 20,
                              fontWeight: FontWeight.bold,
                              color: Colors.blueGrey),
                        ),
                      ),
                      Container(
                        margin: EdgeInsets.only(top: 10),
                        child: Text(
                          widget.book.Author,
                          style: TextStyle(fontSize: 16),
                        ),
                      ),
                      Container(
                        margin: EdgeInsets.only(top: 10, bottom: 10),
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            Row(
                              children: widget.getStars(),
                            ),
                            SizedBox(width: 10),
                            Text(
                              widget.book.Rating.toString(),
                              style: TextStyle(fontSize: 20),
                            ),
                          ],
                        ),
                      ),
                      Container(
                        height: 320,
                        margin: EdgeInsets.only(top: 10),
                        child: ClipRRect(
                          borderRadius: BorderRadius.circular(20),
                          child: FadeInImage(
                            image: NetworkImage(widget.book.ImagePath
                                .replaceFirst("localhost", "10.0.2.2")),
                            placeholder: const AssetImage("assets/book.png"),
                          ),
                        ),
                      ),
                      const SizedBox(
                        height: 30,
                      ),
                      Column(
                        children: [
                          ListTile(
                            title: Text(
                                "Digital ${widget.book.PriceDigital.toString()} KM"),
                            leading: Radio<int>(
                              value: 0,
                              groupValue: widget.digitalSelected,
                              onChanged: (int? value) {
                                setState(() {
                                  widget.digitalSelected = value;
                                });
                              },
                            ),
                          ),
                          ListTile(
                            title: Text(
                                "Physical ${widget.book.PricePhysical.toString()} KM"),
                            leading: Radio<int>(
                              value: 1,
                              groupValue: widget.digitalSelected,
                              onChanged: (int? value) {
                                setState(() {
                                  widget.digitalSelected = value;
                                });
                              },
                            ),
                          ),
                        ],
                      ),
                      SizedBox(
                        width: double.infinity,
                        child: ElevatedButton(
                            style: ButtonStyle(
                                backgroundColor:
                                    MaterialStateProperty.all<Color>(
                                        Colors.green),
                                shape: MaterialStateProperty.all<
                                        RoundedRectangleBorder>(
                                    RoundedRectangleBorder(
                                        borderRadius:
                                            BorderRadius.circular(10)))),
                            onPressed: () {
                              addToCart();
                            },
                            child: Padding(
                              padding: EdgeInsets.all(15),
                              child: Text("Add to cart"),
                            )),
                      ),
                      const SizedBox(
                        height: 20,
                      ),
                      SizedBox(
                        width: double.infinity,
                        child: ElevatedButton(
                            style: ButtonStyle(
                                backgroundColor:
                                    MaterialStateProperty.all<Color>(
                                        checkIfBookInWishlist()
                                            ? Colors.red
                                            : Colors.teal),
                                shape: MaterialStateProperty.all<
                                        RoundedRectangleBorder>(
                                    RoundedRectangleBorder(
                                        borderRadius:
                                            BorderRadius.circular(10)))),
                            onPressed: () {
                              addOrRemoveFromWishlist();
                            },
                            child: Padding(
                              padding: EdgeInsets.all(15),
                              child: Text(checkIfBookInWishlist()
                                  ? "Remove from wishlist"
                                  : "Add to wishlist"),
                            )),
                      ),
                      const SizedBox(
                        height: 30,
                      ),
                      Container(
                        margin: EdgeInsets.only(top: 10, bottom: 10),
                        child: Column(
                          children: [
                            Text(
                              "Description",
                              style: TextStyle(
                                  fontWeight: FontWeight.bold, fontSize: 18),
                            ),
                            Divider(
                              thickness: 1,
                              height: 20,
                            ),
                            ExpandableText(
                              widget.book.Description,
                              expandText: 'show more',
                              collapseText: 'show less',
                              maxLines: 5,
                              linkColor: Colors.blue,
                            )
                          ],
                        ),
                      ),
                      Container(
                        margin: EdgeInsets.only(top: 10, bottom: 10),
                        child: Column(
                          children: [
                            const Text(
                              "Reviews",
                              style: TextStyle(
                                  fontWeight: FontWeight.bold, fontSize: 18),
                            ),
                            const Divider(
                              thickness: 1,
                              height: 20,
                            ),
                            const SizedBox(
                              height: 10,
                            ),
                            userCommentExists
                                ? Container()
                                : Column(
                                    children: [
                                      Row(
                                        children: [
                                          InkWell(
                                            onTap: () {
                                              selectStar(1);
                                            },
                                            child: widget.reviewScore >= 1
                                                ? Icon(
                                                    Icons.star_rounded,
                                                    size: 32,
                                                  )
                                                : Icon(
                                                    Icons.star_border_rounded,
                                                    size: 32,
                                                  ),
                                          ),
                                          InkWell(
                                            onTap: () {
                                              selectStar(2);
                                            },
                                            child: widget.reviewScore >= 2
                                                ? Icon(
                                                    Icons.star_rounded,
                                                    size: 32,
                                                  )
                                                : Icon(
                                                    Icons.star_border_rounded,
                                                    size: 32,
                                                  ),
                                          ),
                                          InkWell(
                                            onTap: () {
                                              selectStar(3);
                                            },
                                            child: widget.reviewScore >= 3
                                                ? Icon(
                                                    Icons.star_rounded,
                                                    size: 32,
                                                  )
                                                : Icon(
                                                    Icons.star_border_rounded,
                                                    size: 32,
                                                  ),
                                          ),
                                          InkWell(
                                            onTap: () {
                                              selectStar(4);
                                            },
                                            child: widget.reviewScore >= 4
                                                ? Icon(
                                                    Icons.star_rounded,
                                                    size: 32,
                                                  )
                                                : Icon(
                                                    Icons.star_border_rounded,
                                                    size: 32,
                                                  ),
                                          ),
                                          InkWell(
                                            onTap: () {
                                              selectStar(5);
                                            },
                                            child: widget.reviewScore >= 5
                                                ? Icon(
                                                    Icons.star_rounded,
                                                    size: 32,
                                                  )
                                                : Icon(
                                                    Icons.star_border_rounded,
                                                    size: 32,
                                                  ),
                                          ),
                                        ],
                                      ),
                                      const SizedBox(
                                        height: 10,
                                      ),
                                      Container(
                                        decoration: BoxDecoration(
                                          borderRadius:
                                              BorderRadius.circular(20),
                                          color: Color.fromARGB(10, 0, 0, 0),
                                        ),
                                        child: SizedBox(
                                            child: Padding(
                                          padding: EdgeInsets.only(
                                              top: 2,
                                              bottom: 2,
                                              right: 20,
                                              left: 20),
                                          child: TextField(
                                            maxLines: 5,
                                            decoration: const InputDecoration(
                                                border: InputBorder.none,
                                                hintText:
                                                    "Type in a comment..."),
                                            style:
                                                const TextStyle(fontSize: 12),
                                            onChanged: (String value) {
                                              setState(() {
                                                widget.commentText = value;
                                              });
                                            },
                                          ),
                                        )),
                                      ),
                                      const SizedBox(
                                        height: 10,
                                      ),
                                      SizedBox(
                                        width: double.infinity,
                                        child: ElevatedButton(
                                            style: ButtonStyle(
                                                backgroundColor:
                                                    MaterialStateProperty.all<
                                                        Color>(Colors.green),
                                                shape: MaterialStateProperty.all<
                                                        RoundedRectangleBorder>(
                                                    RoundedRectangleBorder(
                                                        borderRadius:
                                                            BorderRadius
                                                                .circular(
                                                                    10)))),
                                            onPressed: () => {postReview()},
                                            child: Padding(
                                              padding: EdgeInsets.all(15),
                                              child: Text("Post review"),
                                            )),
                                      ),
                                      const SizedBox(
                                        height: 10,
                                      ),
                                    ],
                                  )
                          ],
                        ),
                      ),
                      FutureBuilder<List<Comment>>(
                        future: futureComments,
                        builder: (context, snapshot) {
                          if (snapshot.hasData) {
                            return Column(
                                children: initializeComments(snapshot.data!));
                          }

                          return const CircularProgressIndicator();
                        },
                      ),
                      const SizedBox(
                        height: 30,
                      ),
                    ],
                  )),
            ),
          ))
        ],
      ),
    );
  }
}
