class AuthData{
  String Email = "";
  String Password = "";

  AuthData();

  Map<String, dynamic> toJson(){
    return {
      'email': Email,
      'password': Password,
    };
  }
  AuthData.fromJson(Map<String, dynamic> jsonFile):
      Email = jsonFile['email'],
      Password = jsonFile['password'];

}