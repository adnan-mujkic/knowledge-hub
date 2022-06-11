import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:knowledge_hub_mobile/components/comment.dart';
import '../models/book.dart';
import 'package:expandable_text/expandable_text.dart';

class BookViewWidget extends StatefulWidget {
  BookViewWidget(this.book, {Key? key}) : super(key: key);

  late Book book;
  int? digitalSelected = 0;
  int reviewScore = 1;

  List<Widget> getStars(){
    List<Widget> icons = new List<Widget>.empty(growable: true);
    for(int i = 0; i < book.Rating.floor(); i++){
      icons.add(Icon(Icons.star,color: Colors.yellow,));
    }
    icons.add(getStarWithFill(book.Rating - book.Rating.floor()));
    for(int i = 0; i < 5 - book.Rating.ceil(); i++){
      icons.add(Icon(Icons.star,color: Colors.black.withOpacity(0.4)));
    }
    return icons;
  }
  getStarWithFill(double percentage){
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

  selectStar(int index){
    setState((){
      widget.reviewScore = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
          child: Container(
            color: Colors.black.withOpacity(0.1),
            child: Align(
              alignment: Alignment.bottomCenter,
              child: Container(margin: EdgeInsets.only(top: 10, right: 30, left: 30),
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
                          widget.book.AuthorName,
                          style: TextStyle(
                              fontSize: 16),
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
                            Text(widget.book.Rating.toString(), style: TextStyle(fontSize: 20),),
                          ],
                        ),
                      ),
                      Container(
                        margin: EdgeInsets.only(bottom: 15),
                        child: Text("1260 reviews",
                            style: TextStyle(
                                color: Colors.black.withOpacity(0.6),
                                fontSize: 12)),
                      ),
                      Container(
                        height: 320,
                        margin: EdgeInsets.only(top: 10),
                        child: ClipRRect(
                          borderRadius: BorderRadius.circular(20),
                          child: Image.asset(
                            'assets/book.png',
                            fit: BoxFit.contain,
                            scale: 1,
                          ),
                        ),
                      ),
                      const SizedBox(
                        height: 30,
                      ),
                      Column(
                        children: [
                          ListTile(
                            title: Text("Digital ${widget.book.PriceDigital.toString()} KM"),
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
                            title: Text("Physical ${widget.book.PricePhysical.toString()} KM"),
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
                                backgroundColor: MaterialStateProperty.all<Color>(Colors.green),
                                shape: MaterialStateProperty.all<RoundedRectangleBorder>(
                                    RoundedRectangleBorder(
                                        borderRadius: BorderRadius.circular(10)
                                    )
                                )
                            ),
                            onPressed: () => {},
                            child: Padding(
                              padding: EdgeInsets.all(15),
                              child: Text("Add to cart"),
                            )
                        ),
                      ),
                      const SizedBox(
                        height: 20,
                      ),
                      SizedBox(
                        width: double.infinity,
                        child: ElevatedButton(
                            style: ButtonStyle(
                                backgroundColor: MaterialStateProperty.all<Color>(Colors.teal),
                                shape: MaterialStateProperty.all<RoundedRectangleBorder>(
                                    RoundedRectangleBorder(
                                        borderRadius: BorderRadius.circular(10)
                                    )
                                )
                            ),
                            onPressed: () => {},
                            child: Padding(
                              padding: EdgeInsets.all(15),
                              child: Text("Add to whishlist"),
                            )
                        ),
                      ),
                      const SizedBox(
                        height: 30,
                      ),
                      Container(
                        margin: EdgeInsets.only(top: 10, bottom: 10),
                        child: Column(
                          children: [
                            Text("Description",
                              style: TextStyle(
                                  fontWeight: FontWeight.bold,
                                  fontSize: 18
                              ),),
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
                            const Text("Reviews",
                              style: TextStyle(
                                  fontWeight: FontWeight.bold,
                                  fontSize: 18
                              ),),
                            const Divider(
                              thickness: 1,
                              height: 20,
                            ),
                            const SizedBox(
                              height: 10,
                            ),
                            Row(
                              children: [
                                InkWell(
                                  onTap: (){
                                    selectStar(1);
                                  },
                                  child: widget.reviewScore >= 1?
                                  Icon(Icons.star_rounded, size: 32,) :
                                  Icon(Icons.star_border_rounded, size: 32,),
                                ),
                                InkWell(
                                  onTap: (){
                                    selectStar(2);
                                  },
                                  child: widget.reviewScore >= 2?
                                  Icon(Icons.star_rounded, size: 32,) :
                                  Icon(Icons.star_border_rounded, size: 32,),
                                ),
                                InkWell(
                                  onTap: (){
                                    selectStar(3);
                                  },
                                  child: widget.reviewScore >= 3?
                                  Icon(Icons.star_rounded, size: 32,) :
                                  Icon(Icons.star_border_rounded, size: 32,),
                                ),
                                InkWell(
                                  onTap: (){
                                    selectStar(4);
                                  },
                                  child: widget.reviewScore >= 4?
                                  Icon(Icons.star_rounded, size: 32,) :
                                  Icon(Icons.star_border_rounded, size: 32,),
                                ),
                                InkWell(
                                  onTap: (){
                                    selectStar(5);
                                  },
                                  child: widget.reviewScore >= 5?
                                  Icon(Icons.star_rounded, size: 32,) :
                                  Icon(Icons.star_border_rounded, size: 32,),
                                ),
                              ],
                            ),
                            const SizedBox(
                              height: 10,
                            ),
                            Container(
                              decoration: BoxDecoration(
                                borderRadius: BorderRadius.circular(20),
                                color: Color.fromARGB(10, 0, 0, 0),
                              ),
                              child: SizedBox(
                                  child: Padding(
                                    padding: EdgeInsets.only(top: 2, bottom: 2, right: 20, left: 20),
                                    child: TextField(
                                      maxLines: 5,
                                      decoration: const InputDecoration(
                                          border: InputBorder.none,
                                          hintText: "Type in a comment..."),
                                      style: const TextStyle(fontSize: 12),
                                      onChanged: (String value){
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
                                      backgroundColor: MaterialStateProperty.all<Color>(Colors.green),
                                      shape: MaterialStateProperty.all<RoundedRectangleBorder>(
                                          RoundedRectangleBorder(
                                              borderRadius: BorderRadius.circular(10)
                                          )
                                      )
                                  ),
                                  onPressed: () => {},
                                  child: Padding(
                                    padding: EdgeInsets.all(15),
                                    child: Text("Post review"),
                                  )
                              ),
                            ),
                            const SizedBox(
                              height: 10,
                            ),
                          ],
                        ),
                      ),
                      CommentWidget(),
                      TextButton(
                        onPressed: (){},
                        child: Text("Load More"),
                      ),
                      const SizedBox(
                        height: 30,
                      ),
                    ],
                  )),
            ),
          )
      ),
    );
  }
}
