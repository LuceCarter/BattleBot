"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();


connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says: " + msg;
    var p = document.createElement("p");
    p.className = "message";
    p.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(p);
});

connection.start().then(function () {
   
}).catch(function (err) {
    return console.error(err.toString());
});