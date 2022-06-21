import 'package:expandable_text/expandable_text.dart';
import 'package:flutter/material.dart';
import '../models/comment.dart';
import '../models/loginRegister.dart';
import 'package:event/event.dart';

class CommentWidget extends StatefulWidget {
  CommentWidget(this.comment, {Key? key}) : super(key: key);

  late Comment comment;

  @override
  CommentState createState() => CommentState();
}

class CommentState extends State<CommentWidget> {
  @override
  Widget build(BuildContext context) {
    return InkWell(
      child: Container(
        decoration: const BoxDecoration(
          borderRadius: BorderRadius.all(Radius.circular(10)),
          color:  Colors.white,
        ),
        child: Column(
          children: [
            Container(
              padding: const EdgeInsets.only(left: 15, top: 10),
              child: Row(
                children: [
                  Icon(Icons.account_circle, color: Colors.black45, size: 32,),
                  SizedBox(width: 10,),
                  Text(widget.comment.Username),
                ],
              ),
            ),
            const SizedBox(
              height: 20,
            ),
            Container(
              padding: const EdgeInsets.only(left: 30, right: 30, bottom: 20),
              child: Align(
                alignment: Alignment.topLeft,
                child: ExpandableText(
                  widget.comment.CommentText,
                  expandText: 'show more',
                  collapseText: 'show less',
                  maxLines: 5,
                  linkColor: Colors.blue,
                ),
              ),
            )
          ],
        ),
      ),
      onTap: () {},
    );
  }
}
