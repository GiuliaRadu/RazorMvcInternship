$(document).ready(function () {

    $("#list").on("click", ".delete", function () {

        var $li = $(this).closest('li');
        var id = $li.attr('member-id');

        $.ajax({
            method: "DELETE",
            url: `/Home/RemoveMember?index=${id}`,
            success: function (data) {

                $li.remove();

            },
            error: function (data) {
                alert(`Failed to remove`);
            },
        });
    })

});