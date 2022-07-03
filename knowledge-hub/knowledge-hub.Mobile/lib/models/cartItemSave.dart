import 'dart:convert';

class CartItemSave {
  int book = 0;
  bool digital = true;

  CartItemSave();
  Map<String, dynamic> toJson() => {
        'book': book,
        'digital': digital,
      };

  CartItemSave.fromJson(Map<String, dynamic> jsonFile)
      : book = jsonFile['book'] ?? 0,
        digital = jsonFile['digital'] ?? true;
}
