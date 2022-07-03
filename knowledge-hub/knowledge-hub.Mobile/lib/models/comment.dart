import 'package:json_annotation/json_annotation.dart';

class Comment {
  int UserId = 0;
  String Username = "";
  String Date = "";
  String CommentText = "";
  double Rating = 0;

  Comment();
  Map<String, dynamic> toJson() => {
        'userId': UserId,
        'username': Username,
        'date': Date,
        'commentText': CommentText,
        'rating': Rating,
      };
  Comment.fromJson(Map<String, dynamic> jsonFile)
      : UserId = jsonFile['userId'] ?? 0,
        Username = jsonFile['username'] ?? "",
        Date = jsonFile['date'] ?? "",
        CommentText = jsonFile['commentText'] ?? "",
        Rating = jsonFile['rating'] is int
            ? (jsonFile['rating'] as int).toDouble()
            : jsonFile['rating'];
}
