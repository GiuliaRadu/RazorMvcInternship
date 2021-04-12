"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.on("AddMember", function (name, id) {
    alert(`User ${name} with Id = ${id}`);
});

connection.start().then(function () {
    console.log("Connection established")
}).catch(function (err) {
    return console.error(err.toString());
});