"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/primesHub").build();

connection.on("ReceivePrimeSieveResults", function (result) {
    var p = document.createElement("p");
    document.getElementById("prime-sieve-output").appendChild(p);
    p.textContent = result;
});

connection.start().then().catch(function (err) {
    return console.error(err.toString());
});