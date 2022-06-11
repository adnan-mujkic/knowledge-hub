class Address{
  String? FullName = "";
  String? AdressLine = "";
  String? City = "";
  String? Postcode = "";

  Address();
  Map<String, dynamic> toJson() => {
    'fullName' : FullName,
    'adressLine' : AdressLine,
    'city' : City,
    'postcode' : Postcode
  };
  Address.fromJson(Map<String, dynamic> jsonFile):
        FullName = jsonFile['fullName']??"",
        AdressLine = jsonFile['adressLine']??"",
        City = jsonFile['city']??"",
        Postcode = jsonFile['postcode']??"";
}