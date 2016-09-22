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
    $('body').on("submit", ".new-sale", function (event) {
        event.preventDefault();
        $.ajax({
            url: '/Sale/Create',
            type: 'POST',
            data: $(this).serialize(),
            dataType: 'html',
            success: function (result) {
                console.log("Yo");

                $('.body-content').html(result);
            }
        });
    });
    $('body').on("submit", ".return", function (event) {
        event.preventDefault();
        $.ajax({
            url: '/Sale/Return',
            type: 'POST',
            data: $(this).serialize(),
            dataType: 'html',
            success: function (result) {
                console.log("Yo");

                $('.body-content').html(result);
            }
        });
    });
});