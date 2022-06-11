import 'package:json_annotation/json_annotation.dart';

class Comment{
  String UserId = "";
  String Username = "";
  String Date = "";
  String CommentText = "";

  Comment();
  Map<String, dynamic> toJson() => {
    'userId' : UserId,
    'username' : Username,
    'date' : Date,
    'commentText' : CommentText,
  };
  Comment.fromJson(Map<String, dynamic> jsonFile):
        UserId = jsonFile['userId']??"",
        Username = jsonFile['username']??"",
        Date = jsonFile['date']??"",
        CommentText = jsonFile['commentText']??"";
}