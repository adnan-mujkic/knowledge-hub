import 'package:knowledge_hub_mobile/models/book.dart';

class Order {
  int orderId = 0;
  String imagePath = "";
  String nameOfOrderPerson = "";
  String bookName = "";
  String bookAuthor = "";
  String orderNumber = "";
  String orderDate = "";
  String shippedDate = "";
  int orderStatus = 0;
  String address = "";
  String orderComment = "";
  double paid = 0;
  String type = "";
  Book book = Book();

  Order();

  Map<String, dynamic> toJson() => {
        'orderId': orderId,
        'imagePath': imagePath,
        'nameOfOrderPerson': nameOfOrderPerson,
        'bookName': bookName,
        'bookAuthor': bookAuthor,
        'orderNumber': orderNumber,
        'orderDate': orderDate,
        'shippedDate': shippedDate,
        'orderStatus': orderStatus,
        'address': address,
        'orderComment': orderComment,
        'paid': paid,
        'type': type,
      };
  Order.fromJson(Map<String, dynamic> jsonFile)
      : orderId = jsonFile['orderId'] ?? 0,
        imagePath = jsonFile['book']['imagePath'] ?? "",
        nameOfOrderPerson = jsonFile['userFullName'] ?? "",
        bookName = jsonFile['book']['name'] ?? "",
        bookAuthor = jsonFile['book']['author'] ?? "",
        orderNumber = jsonFile['orderNumber'] ?? "",
        orderDate = jsonFile['orderDate'] ?? "",
        shippedDate = jsonFile['shippingDate'] ?? "",
        orderStatus = jsonFile['orderStatus'] ?? 0,
        address = jsonFile['addressLine'] ?? "",
        orderComment = jsonFile['comment'] ?? "",
        paid = jsonFile['paid'] ?? 0,
        type = jsonFile['type'] ?? "",
        book = Book.fromJson(jsonFile['book']);

  void populate(
      String _imagePath,
      String _nameOfPerson,
      String _bookName,
      String _bookAuthor,
      String _orderNumber,
      String _orderDate,
      String _shippedDate,
      int _orderStatus,
      String _address) {
    imagePath = _imagePath;
    nameOfOrderPerson = _nameOfPerson;
    bookName = _bookName;
    bookAuthor = _bookAuthor;
    orderNumber = _orderNumber;
    orderDate = _orderDate;
    shippedDate = _shippedDate;
    orderStatus = _orderStatus;
    address = _address;
  }
}
