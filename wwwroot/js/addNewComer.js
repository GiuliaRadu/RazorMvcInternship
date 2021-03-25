// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#add").click(function () {
        var newcomerName = $("#newcomer").val();
        // Remember string interpolation
        $("#list").append(`<li>${newcomerName}</li>`);
        $("#newcomer").val("");
    })
    $("#clear").click(function () {
        $("#newcomer").val("");
    })
});