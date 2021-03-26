$(document).ready(function () {

    $("#list").on("click", ".delete", function () {
        var targetMemberTag = $(this).closest('li');
        var index = targetMemberTag.index(targetMemberTag.parent());
        $.ajax({
            url: `/Home/RemoveMember/${index}`,
            type: 'DELETE',
            success: function () {
                targetMemberTag.remove();
            },
            error: function () {
                alert(`Failed to delete member with index=${index}`);
            }
        })
    })

    $("#list").on("click", ".startEdit", function () {
        var targetMemberTag = $(this).closest('li');
        var index = targetMemberTag.index();
        var currentName = targetMemberTag.find(".name").text();
        $('#editClassmate').attr("memberIndex", index);
        $('#classmateName').val(currentName);
    })

    $("#editClassmate").on("click", "#submit", function () {
        var name = $('#classmateName').val();
        var index = $('#editClassmate').attr("memberIndex");

        console.log(`/Home/UpdateMember?index=${index}&name=${name}`);
        $.ajax({
            url: `/Home/UpdateMember?index=${index}&name=${name}`,
            type: 'PUT',
            success: function (response) {
                
            }

        });
    })

    $("#editClassmate").on("click", "#cancel", function () {
        console.log('cancel changes');
    })
})


