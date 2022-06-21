class City{
  int CityId = 1;
  String Name = "";
  String ZipCode = "";
  String Country = "";

  City();
  Map<String, dynamic> toJson() => {
    'cityId' : CityId,
    'name' : Name,
    'zipCode' : ZipCode,
    'country' : Country
  };
  City.fromJson(Map<String, dynamic> jsonFile):
        CityId = jsonFile['cityId']??"",
        Name = jsonFile['name']??"",
        ZipCode = jsonFile['zipCode']??"",
        Country = jsonFile['country']??"";
}