var mongodb = require("mongodb");
var mongodbClient = mongodb.MongoClient;
var uri = "mongodb://localhost:27017";

exports.getValue = (id) => {
    
    var modal = {id: id, timeStamp: new Date()};

    mongodbClient.connect(uri, {useNewUrlParser: true}, (err, db) => {
        if(err) throw err;
        console.log("Connected to MongoDb at localhost:27017");

        var dbo = db.db("mydb");

        var testCollection = dbo.collection("testCollection");
        testCollection.insertOne(modal, (err, res)=>{
            if(err) throw err;
            console.log("1 record inserted to testCollection.")
        });

        db.close();
    });
    return `Value returned for ${modal.id} on ${modal.timeStamp}`;
};