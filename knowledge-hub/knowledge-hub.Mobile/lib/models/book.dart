import 'dart:convert';

import 'comment.dart';
class Book{
  int BookId = 0;
  String AuthorName = "";
  String BookName = "";
  String Language = "";
  String Category = "";
  double PriceDigital = 0;
  double PricePhysical = 0;
  String Description = "";
  double Rating = 5;
  String ImagePath = "";
  List<Comment> comments = List<Comment>.empty(growable: true);

  Book();

  Map<String, dynamic> toJson() => {
    'bookId': BookId,
    'authorName' : AuthorName,
    'bookName' : BookName,
    'language' : Language,
    'category' : Category,
    'priceDigital' : PriceDigital,
    'pricePhysical' : PricePhysical,
    'description' : Description,
    'score' : Rating,
    'imagePath' : ImagePath,
    'comments': comments,
  };
  Book.fromJson(Map<String, dynamic> jsonFile):
        BookId = jsonFile['bookId']??0,
        AuthorName = jsonFile['author']??"",
        BookName = jsonFile['name']??"",
        Language = jsonFile['language']??"",
        Category = jsonFile['category']??"",
        PriceDigital = jsonFile['priceDigital'] is int?
          (jsonFile['priceDigital'] as int).toDouble() : jsonFile['priceDigital'],
        PricePhysical = jsonFile['pricePhysical'] is int?
          (jsonFile['pricePhysical'] as int).toDouble() : jsonFile['pricePhysical'],
        Description = jsonFile['description']??"",
        ImagePath = jsonFile['imagePath']??"",
        Rating = jsonFile['score'] is int?
          (jsonFile['score'] as int).toDouble() : jsonFile['score'],
        comments = (jsonFile.containsKey('comments') && jsonFile['comments'])?
        List<Comment>.from(json.decode(jsonFile['comments']).map((model)=> Comment.fromJson(model)))
        : List<Comment>.empty();
}