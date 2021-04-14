// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#add").click(function () {
        var newcomerName = $("#newcomer").val();
        $.ajax({
            url: 'api/Internship/',
            contentType: 'application/json',
            data: JSON.stringify({ "Name": `${newcomerName}` }),
            method: "POST",
            success: function (data) {
                // Remember string interpolation
               
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