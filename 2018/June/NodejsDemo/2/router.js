var express = require("express");
var db = require("./db");

var router = express.Router();

router.get("/", (request, response) => {
    var valueFromDb = db.getValue(1999);
    response.status(200).send("GET request response! VaueFromDb: " + valueFromDb);
});

module.exports = router;