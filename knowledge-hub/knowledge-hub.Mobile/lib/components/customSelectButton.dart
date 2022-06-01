import 'package:event/event.dart';
import 'package:flutter/material.dart';

var fontStyleDeselected = TextStyle(
  color: Colors.green
);
var fontStyleSelected = TextStyle(
  color: Colors.white
);
var buttonStyleSelected = OutlinedButton.styleFrom(
  backgroundColor: Colors.green,
  primary: Colors.white,
  textStyle: fontStyleSelected,
  side: BorderSide(color: Colors.white, width: 1)
);
var buttonStyleDeselected = OutlinedButton.styleFrom(
    backgroundColor: Colors.white,
    primary: Colors.green,
    textStyle: fontStyleDeselected,
    side: BorderSide(color: Colors.green, width: 1)
);

class CustomSelectButton extends StatefulWidget{
  CustomSelectButton(this.selected, this.text, {Key? key}) : super(key: key);

  bool selected = false;
  String text = "";
  var changedState = Event<Value<bool>>();

  @override
  CustomSelectButtonState createState() => CustomSelectButtonState();
}

class CustomSelectButtonState extends State<CustomSelectButton>{
  void onPressed(){
    setState(() => {
      widget.selected = !widget.selected
    });
  }

  @override
  Widget build(BuildContext context){
    return ElevatedButton(
      onPressed: onPressed,
      child: Text(widget.text),
      style: widget.selected == true? buttonStyleSelected : buttonStyleDeselected,
    );
  }
}