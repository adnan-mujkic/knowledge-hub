class UserLogin{
  String? Email;
  String? Password;

  Map<String, dynamic> toJson() => {
    'Email' : Email,
    'Password' : Password,
  };
}


class Register{
  String? Email;
  String? Password;
  String? ConfirmPassword;

  Map<String, dynamic> toJson() => {
    'Email' : Email,
    'Password' : Password,
    'ConfirmPassword' : ConfirmPassword,
  };
}