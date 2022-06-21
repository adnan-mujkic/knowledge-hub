class PaymentInfo{
  int CardInfoId = 0;
  String CardHolder = "";
  String CardNumber = "";
  String ExpiryDate = "";
  String CVC = "";

  PaymentInfo();
  Map<String, dynamic> toJson() => {
    'cardInfoId': CardInfoId,
    'fullName' : CardHolder,
    'cardNumber' : CardNumber,
    'cardDate' : ExpiryDate,
    'cVC' : CVC
  };
  PaymentInfo.fromJson(Map<String, dynamic> jsonFile):
        CardInfoId = jsonFile['cardInfoId']??0,
        CardHolder = jsonFile['fullName']??"",
        CardNumber = jsonFile['cardNumber']??"",
        ExpiryDate = jsonFile['cardDate']??"",
        CVC = jsonFile['cVC']??"";
}