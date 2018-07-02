var express = require("express");
var mongodb = require("mongodb");

var app = express();
var mongoClient = mongodb.MongoClient;

var uri = "mongodb://localhost:27017";

app.get("/insert", function(request, response) {
    mongoClient.connect(uri, { useNewUrlParser: true }, (err, db) => {
        if(err) throw err;

        var dbo = db.db("mydb");

        var myCollection = dbo.collection("myCollection");
        var logRecord = {key: "key1", value: "value1"};
        myCollection.insertOne(logRecord, function(err, res){
            if (err) throw err;
            console.log("1 document inserted");                
          });
          
          db.close();
    });

    response.status(200).send("Welcome to our restful API");
});

var server = app.listen(3000, function () {
    console.log("app running on port.", server.address().port);
});
