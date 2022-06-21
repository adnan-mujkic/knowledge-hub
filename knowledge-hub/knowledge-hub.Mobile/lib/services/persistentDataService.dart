import 'dart:convert';

import 'package:knowledge_hub_mobile/models/city.dart';
import 'package:http/http.dart' as http;

class PersistentDataService{
  PersistentDataService._privateConstructor();
  static final PersistentDataService instance = PersistentDataService._privateConstructor();

  List<City> cities = List<City>.empty(growable: true);

  fetchCities()async{
    final response = await http.get(
      Uri.parse('http://192.168.1.103:5000/api/City'),
      headers: <String, String>{
        'Content-Type' : 'application/json; charset=UTF-8',
      },
    );

    if(response.statusCode == 200){
      List<dynamic> map = jsonDecode(response.body) as List<dynamic>;
      map.forEach((element) {
        City city = City.fromJson(element);
        cities.add(city);
      });
    }
  }
}