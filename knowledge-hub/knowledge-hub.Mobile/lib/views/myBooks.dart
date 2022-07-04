import 'dart:convert';
import 'dart:isolate';
import 'dart:ui';
import 'package:event/event.dart';
import 'package:flutter_pdfview/flutter_pdfview.dart';
import 'package:flutter/material.dart';
import 'package:knowledge_hub_mobile/models/book.dart';
import 'package:http/http.dart' as http;
import 'package:knowledge_hub_mobile/services/accountService.dart';
import 'package:knowledge_hub_mobile/services/persistentDataService.dart';
import 'package:path_provider/path_provider.dart';
import 'dart:io';
import 'package:permission_handler/permission_handler.dart';
import 'package:dio/dio.dart';
import 'package:open_file/open_file.dart';

class MyBooksWidget extends StatefulWidget {
  MyBooksWidget({Key? key}) : super(key: key);

  @override
  MyBooksState createState() => MyBooksState();
}

class MyBooksState extends State<MyBooksWidget> {
  bool displayPdf = false;
  Dio dio = Dio();

  Future<List<Book>> constructChildren() async {
    final response = await http.get(
        Uri.parse(
            '${PersistentDataService.instance.BackendUri}/api/Order/GetBoughtBooksByUser?ID=${AccountService.instance.userData.UserId}'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Authorization':
              "Basic ${AccountService.instance.authData.Email}:${AccountService.instance.authData.Password}"
        });
    if (response.statusCode == 200) {
      var jsonData = jsonDecode(response.body);
      Iterable iterable = jsonData;

      var books = List<Book>.from(iterable.map((e) => Book.fromJson(e)));
      return books;
    }
    return List<Book>.empty(growable: true);
  }

  List<Widget> getBooksWidgets(List<Book>? books) {
    List<Widget> widgets = List<Widget>.empty(growable: true);

    if (books != null) {
      books.forEach((element) {
        widgets.add(Container(
          color: Colors.white,
          height: 150,
          width: double.infinity,
          margin: EdgeInsets.only(top: 10, bottom: 10),
          padding: EdgeInsets.all(10),
          child: Row(
            children: [
              Container(
                height: 120,
                width: 80,
                child: FadeInImage(
                  image: NetworkImage(element.ImagePath),
                  placeholder: const AssetImage("assets/book.png"),
                ),
              ),
              SizedBox(
                width: 10,
              ),
              Column(
                mainAxisAlignment: MainAxisAlignment.start,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Container(
                      width: MediaQuery.of(context).size.width - 120,
                      child: Text(
                          style: TextStyle(fontWeight: FontWeight.bold),
                          element.BookName)),
                  SizedBox(
                    height: 10,
                  ),
                  Container(
                      width: MediaQuery.of(context).size.width - 120,
                      child: Text(element.Author)),
                  SizedBox(
                    height: 20,
                  ),
                  ElevatedButton(
                      onPressed: () async {
                        try {
                          String path = "/storage/emulated/0/Download/";
                          String fileName = element.FilePath.split('/').last;
                          String fullPath = "$path/$fileName";
                          debugPrint(path);

                          bool permissionGranted =
                              await Permission.storage.isGranted;
                          if (!permissionGranted) {
                            getWritePermission();
                          }

                          Response res = await dio.get(element.FilePath,
                              options: Options(
                                  responseType: ResponseType.bytes,
                                  followRedirects: false));

                          File file = File(fullPath);
                          var raf = file.openSync(mode: FileMode.write);
                          raf.writeFromSync(res.data);
                          await raf.close();

                          final _result = await OpenFile.open(path);
                        } catch (e) {
                          PersistentDataService.instance.screenWideNotification
                              .broadcast(Value<String>("Error opening file"));
                        }
                      },
                      child: Icon(Icons.download))
                ],
              )
            ],
          ),
        ));
      });
      return widgets;
    }
    widgets.add(CircularProgressIndicator());
    return widgets;
  }

  void getWritePermission() async {
    await Permission.storage.request();
  }

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: FutureBuilder<List<Book>>(
        future: constructChildren(),
        builder: (BuildContext context, AsyncSnapshot<List<Book>> snapshot) {
          if (snapshot.hasData && snapshot.data != null) {
            return Column(
              children: getBooksWidgets(snapshot.data),
            );
          }
          return CircularProgressIndicator();
        },
      ),
    );
  }
}
