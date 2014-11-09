jQuery.fn.extend({
    showInfo: function (message) {
        $(this).find('.alert').addClass('alert-info');
        $(this).find('.alert .fa').addClass('fa-check');
        $(this).css('display', 'block');
        $(this).find('.alert p').text(message);
    },
    showError: function (message) {
        $(this).find('.alert').addClass('alert-danger').removeClass('alert-info');
        $(this).find('.alert .fa').addClass('fa-ban').removeClass('fa-check');
        $(this).css('display', 'block');
        $(this).find('.alert p').text(message);
    }
});