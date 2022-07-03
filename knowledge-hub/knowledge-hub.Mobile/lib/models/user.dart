class User{
  int UserId = 0;
  String Email = "";
  String Username = "";
  String Biography = "";
  String ImagePath = "";
  String UserRole = "";

  User();

  Map<String, dynamic> toJson() => {
    'userId': UserId,
    'email' : Email,
    'username' : Username,
    'biography' : Biography,
    'imagePath' : ImagePath,
    'userRole' : UserRole,
  };
  User.fromJson(Map<String, dynamic> jsonFile):
        UserId = jsonFile['userId']??0,
        Email = jsonFile['email']??"",
        Username = jsonFile['username']??"",
        Biography = jsonFile['biography']??"",
        ImagePath = jsonFile['imagePath']??"",
        UserRole = jsonFile['userRole']??"";
}