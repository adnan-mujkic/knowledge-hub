import 'dart:math';

import '../models/book.dart';
import '../models/comment.dart';

class BookService{
  List<Book> allBooks = List<Book>.empty(growable: true);

  BookService(){
    for(int i = 0; i < 100; i++){
      var book = new Book();
      book.BookName = "Book $i";
      book.PricePhysical = Random.secure().nextInt(100) as double;
      book.PriceDigital = Random.secure().nextInt(100) as double;
      book.Description = "Description";
      book.Author = "John $i Doe";
      book.Rating = 3.5;
      var comment = Comment();
      comment.Username = "Doe";
      comment.CommentText = "Sucks!";
      book.comments.add(comment);
      allBooks.add(book);
    }
  }
}