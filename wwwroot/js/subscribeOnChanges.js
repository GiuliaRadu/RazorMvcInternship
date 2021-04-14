"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.on("AddMember", function (name, id) {
    
    $("#list").append(`
        <li class="member" member-id="${id}">
            <span class="name">${name}</span>
            <i class="delete fa fa-remove"></i>
            <i class="startEdit fa fa-pencil" data-toggle="modal" data-target="#editClassmate"></i>
		</li>`);
});

connection.on("RemoveMember", function (id) {
    var $li = $(`li.member[member-id=${id}]`) 
    $li.remove();
});

connection.start().then(function () {
    console.log("Connection established");
}).catch(function (err) {
    return console.error(err.toString());
});