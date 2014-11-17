var rules = {
    Name: {
        required: true
    },
    Description: {
        required: true
    }
}

var submitHandler = function (form) {
    var data = {
        Name: $('#Name').val(),
        Description: $('#Description').val(),
        
    };

    $.post('/api/baskets', data).done(function (data) {
        $('#add-basket-modal').modal('hide');
        $('.message-area').showInfo('Successfully updated');
        $('#basket-table').bootstrapTable('refresh');
    }, 'json').fail(function (jqXHR, textStatus, err) {
        $('.message-area').showError(err);
    });
    return false;
}


$(function () {
   
    $('#basket-edit-form').validate({
        rules: rules,
        highlight: function (element) {
            $(element).closest('.input-group-sm').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.input-group-sm').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },
        submitHandler: submitHandler
    });
});