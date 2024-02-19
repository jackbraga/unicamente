$(document).ready(function () {

    "use strict";

    var fullHeight = function () {

        $('.js-fullheight').css('height', $(window).height());
        $(window).resize(function () {
            $('.js-fullheight').css('height', $(window).height());
        });

    };
    fullHeight();

    $('#sidebarCollapse').on('click', function () {
        if ($('#sidebar').hasClass('active')) {
            $("#logo-pequeno").css('display', 'inline-block');
            $("#logo-grande").css('display', 'none');
        }
        else {
            $("#logo-pequeno").css('display', 'none');
            $("#logo-grande").css('display', 'block');

        }

        //$('#sidebar').toggleClass('active');

    });

});
