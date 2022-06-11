class RegisterResponse{
  final int loginId;

  const RegisterResponse({
    required this.loginId
  });

  factory RegisterResponse.fromJson(Map<String, dynamic> json){
    return RegisterResponse(loginId: json['LoginId']);
  }
}