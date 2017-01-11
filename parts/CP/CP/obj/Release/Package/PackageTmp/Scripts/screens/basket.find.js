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
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        Description: $('#Description').val()
    };

    $.post('/api/baskets', data).done(function (data) {
        $('#data-basket-modal').modal('hide');
        $('.message-area').showInfo('Successfully updated');
        $('#basket-table').bootstrapTable('refresh');
        $('#Id').val('0');
    }, 'json').fail(function (jqXHR, textStatus, err) {
        $('.message-area').showError(err);
    });
    return false;
}

function on_edit(id) {    
    $.get('/api/baskets/' + id).done(function (data) {
        $('#Name').val(data.Name);
        $('#Description').val(data.Description);
        $('#Id').val(data.Id);
        $('#data-basket-modal').modal('show');
    }).fail(function (jqXHR, textStatus, err) {
        $('.message-area').showError(err);
    });
}

function on_delete(id) {
   
    $.post('/api/baskets/remove/' + id).done(function () {
        $('.message-area').showInfo('Basket has been successfully deleted');
        $('#basket-table').bootstrapTable('refresh');
    }).fail(function (jqXHR, textStatus, err) {
        $('.message-area').showError(jqXHR.responseJSON.ExceptionMessage);
    });
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