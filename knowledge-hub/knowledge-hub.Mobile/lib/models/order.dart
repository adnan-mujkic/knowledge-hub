class Order{
  String imagePath = "";
  String nameOfOrderPerson = "";
  String bookName = "";
  String bookAuthor = "";
  String orderNumber = "";
  String orderDate = "";
  String shippedDate = "";
  String orderStatus = "";
  String address = "";

  void populate(
      String _imagePath,
      String _nameOfPerson,
      String _bookName,
      String _bookAuthor,
      String _orderNumber,
      String _orderDate,
      String _shippedDate,
      String _orderStatus,
      String _address,){
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
  Order();
}