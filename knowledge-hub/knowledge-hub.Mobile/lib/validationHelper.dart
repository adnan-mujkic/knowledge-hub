String? emailValidation(String? text) {
  if (text == null) return null;
  if (text.isEmpty) {
    return 'Can\'t be empty\n';
  }

  if (!text.contains('@')) {
    return 'Is not a valid email.\n';
  }

  return null;
}

String? passwordValidation(String? text) {
  if (text == null) return null;

  RegExp regex =
      RegExp(r'^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#\$&*~]).{8,}$');

  if (text.isEmpty) {
    return 'Can\'t be empty\n';
  }
  if (!regex.hasMatch(text)) {
    return 'Password needs to have uppercase, lowercase, number, symbol and be at least 8 characters long!';
  }

  return null;
}

String? emptyValidation(String? text) {
  if (text == null) return null;

  if (text.isEmpty) {
    return 'Can\'t be empty\n';
  }

  return null;
}
