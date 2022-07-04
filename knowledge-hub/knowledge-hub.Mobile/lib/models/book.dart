import 'dart:convert';

import 'comment.dart';

class Book {
  int BookId = 0;
  String Author = "";
  String BookName = "";
  String Language = "";
  String Category = "";
  double PriceDigital = 0;
  double PricePhysical = 0;
  String Description = "";
  double Rating = 5;
  String ImagePath = "";
  String FilePath = "";
  List<Comment> comments = List<Comment>.empty(growable: true);

  Book();

  Map<String, dynamic> toJson() => {
        'bookId': BookId,
        'author': Author,
        'bookName': BookName,
        'language': Language,
        'category': Category,
        'priceDigital': PriceDigital,
        'pricePhysical': PricePhysical,
        'description': Description,
        'score': Rating,
        'imagePath': ImagePath,
        'filePath': FilePath,
        'reviews': comments,
      };
  Book.fromJson(Map<String, dynamic> jsonFile)
      : BookId = jsonFile['bookId'] ?? 0,
        Author = jsonFile['author'] ?? "",
        BookName = jsonFile['name'] ?? "",
        Language = jsonFile['language'] ?? "",
        Category = jsonFile['category'] ?? "",
        PriceDigital = jsonFile['priceDigital'] is int
            ? (jsonFile['priceDigital'] as int).toDouble()
            : jsonFile['priceDigital'],
        PricePhysical = jsonFile['pricePhysical'] is int
            ? (jsonFile['pricePhysical'] as int).toDouble()
            : jsonFile['pricePhysical'],
        Description = jsonFile['description'] ?? "",
        ImagePath = ("http://10.0.2.2:5000/BookImages/") +
            (jsonFile['imagePath'] ?? "default.jpg"),
        FilePath =
            ("http://10.0.2.2:5000/BookFiles/") + (jsonFile['filePath'] ?? ""),
        Rating = jsonFile['score'] is int
            ? (jsonFile['score'] as int).toDouble()
            : jsonFile['score'],
        comments = List<Comment>.empty(growable: true);
}
