"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.on("AddMember", function (name, id) {
    $("#list").append(`<li class="member">
        <span class="name">${user}</span><span class="delete fa fa-remove"></span><i class="startEdit fa fa-pencil" data-toggle="modal" data-target="#editClassmate"></i>
    </li>`);
});

connection.start().then(function () {
    console.log("Connection established")
}).catch(function (err) {
    return console.error(err.toString());
});