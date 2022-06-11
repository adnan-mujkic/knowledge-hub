class UserRegistrationRequest{
  String Username;
  String Biography;
  int LoginId;

  UserRegistrationRequest({
    required this.Username,
    required this.Biography,
    required this.LoginId
  });

  Map<String, dynamic> toJson() => {
    'Username' : Username,
    'Biography' : Biography,
    'LoginId' : LoginId,
  };
}