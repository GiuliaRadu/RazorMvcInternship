$(document).ready(function () {

    $("#list").on("click", ".startEdit", function () {
        var targetMemberTag = $(this).closest('li');
        var serverIndex = targetMemberTag.attr('member-id');
        var clientIndex = targetMemberTag.index();
        var currentName = targetMemberTag.find(".name").text();
        $('#editClassmate').attr("member-id", serverIndex);
        $('#editClassmate').attr("memberIndex", clientIndex);
        $('#classmateName').val(currentName);
    })

    $("#editClassmate").on("click", "#submit", function () {
        console.log('submit changes to server');

        var newName = $('#classmateName').val();
        var id = $('#editClassmate').attr("member-id");
        var index = $('#editClassmate').attr("memberIndex");

        $.ajax({
            contentType: 'application/json',
            data: JSON.stringify({ "Name": `${newName}` }),
            method: "PUT",
            url: `api/Internship/${id}`,
            success: function (response) {
                //$('.name').eq(index).replaceWith(newName);
            },
            error: function (data) {
                alert(`Failed to update`);
            }
        });
    })

    $("#editClassmate").on("click", "#cancel", function () {
        console.log('cancel changes');
    })
});