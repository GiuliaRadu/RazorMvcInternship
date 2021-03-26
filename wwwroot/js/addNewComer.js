﻿// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#add").click(function () {
        var newcomerName = $("#newcomer").val();
        // Remember string interpolation
        $.ajax({
            url: `/Home/AddMember?member=${newcomerName}`,
            success: function (data) {
                // Remember string interpolation
                $("#list").append(`
                    <li class="member">
                        <span class="name">${data}</span></span><i class="delete fa fa-remove"><span class=" fa fa-pencil"></i>
                    </li>`
                );
                $("#newcomer").val("");
            },
            error: function (data) {
                alert(`Failed to add ${newcomerName}`);
            },
        });
    })
    $("#clear").click(function () {
        $("#newcomer").val("");
    })
});