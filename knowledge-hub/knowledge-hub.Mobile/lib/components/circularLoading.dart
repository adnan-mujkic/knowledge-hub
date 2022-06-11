import 'package:flutter/material.dart';

class CircularLoadingWidget extends StatefulWidget {
  CircularLoadingWidget(this.loadingText, {Key? key}) : super(key: key);

  String loadingText;

  @override
  CircularLoadingState createState() => CircularLoadingState();
}

class CircularLoadingState extends State<CircularLoadingWidget> {
  @override
  Widget build(BuildContext context) {
    return Container(
      width: double.infinity,
      height: double.infinity,
      color: Colors.black.withOpacity(0.7),
      child: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            CircularProgressIndicator(),
            SizedBox(height: 50),
            Text(widget.loadingText, style: TextStyle(color: Colors.white),)
          ],
        ),
      ),
    );
  }
}
