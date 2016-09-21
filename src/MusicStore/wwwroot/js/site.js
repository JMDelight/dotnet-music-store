$(document).ready(function () {
    $(".new-item").submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '/item/create',
            type: 'POST',
            data: $(this).serialize(),
            dataType: 'html',
            success: function (result) {
                $('#inventory').html(result);
            }
        });
    });
});