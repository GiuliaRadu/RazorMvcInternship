"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.on("AddMember", function (name, id) {
    alert(`user=${name} with id=${id}`);
    
    $("#list").append(`<li class="member"><span class="name">${name}</span><span class="remove fa fa-remove"></span><i class="startedit fa fa-pencil" data-toggle="modal" data-target="#editclassmate"></i>
    </li>`);
});

connection.start().then(function () {
    console.log("Connection established");
}).catch(function (err) {
    return console.error(err.toString());
});