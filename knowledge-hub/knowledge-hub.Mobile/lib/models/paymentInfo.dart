class PaymentInfo{
  String CardHolder = "";
  String CardNumber = "";
  String ExpiryDate = "";
  String CVC = "";

  PaymentInfo();
  Map<String, dynamic> toJson() => {
    'cardHolder' : CardHolder,
    'cardNumber' : CardNumber,
    'expiryDate' : ExpiryDate,
    'cVC' : CVC
  };
  PaymentInfo.fromJson(Map<String, dynamic> jsonFile):
        CardHolder = jsonFile['cardHolder']??"",
        CardNumber = jsonFile['cardNumber']??"",
        ExpiryDate = jsonFile['expiryDate']??"",
        CVC = jsonFile['cVC']??"";
}