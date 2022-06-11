class Order{
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

  Order();

  Map<String, dynamic> toJson() => {
    'imagePath' : imagePath,
    'nameOfOrderPerson' : nameOfOrderPerson,
    'bookName' : bookName,
    'bookAuthor' : bookAuthor,
    'orderNumber' : orderNumber,
    'orderDate' : orderDate,
    'shippedDate' : shippedDate,
    'orderStatus' : orderStatus,
    'address': address,
    'orderComment': orderComment,
    'paid': paid,
    'type': type,
  };
  Order.fromJson(Map<String, dynamic> jsonFile):
        imagePath = jsonFile['imagePath']??"",
        nameOfOrderPerson = jsonFile['nameOfOrderPerson']??"",
        bookName = jsonFile['bookName']??"",
        bookAuthor = jsonFile['bookAuthor']??"",
        orderNumber = jsonFile['orderNumber']??"",
        orderDate = jsonFile['orderDate']??"",
        shippedDate = jsonFile['shippedDate']??"",
        orderStatus = jsonFile['orderStatus']??0,
        address = jsonFile['address']??"",
        orderComment = jsonFile['orderComment']??"",
        paid = jsonFile['paid']??0,
        type = jsonFile['type']??"";


  void populate(
      String _imagePath,
      String _nameOfPerson,
      String _bookName,
      String _bookAuthor,
      String _orderNumber,
      String _orderDate,
      String _shippedDate,
      int _orderStatus,
      String _address){
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