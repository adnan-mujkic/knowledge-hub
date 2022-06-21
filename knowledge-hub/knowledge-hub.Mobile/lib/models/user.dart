class User{
  int UserId = 0;
  String Email = "";
  String Username = "";
  String Biography = "";
  String ImagePath = "";
  String UserRole = "";

  User();

  Map<String, dynamic> toJson() => {
    'Userid': UserId,
    'Email' : Email,
    'Username' : Username,
    'Biography' : Biography,
    'ImagePath' : ImagePath,
    'UserRole' : UserRole,
  };
  User.fromJson(Map<String, dynamic> jsonFile):
        UserId = jsonFile['userId']??0,
        Email = jsonFile['email']??"",
        Username = jsonFile['username']??"",
        Biography = jsonFile['biography']??"",
        ImagePath = jsonFile['imagePath']??"",
        UserRole = jsonFile['userRole']??"";
}