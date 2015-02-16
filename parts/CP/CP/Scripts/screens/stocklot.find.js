function operateFormatter(value, row, index) {
        return [          
            '<a href="#" title="Edit">',
                '<i class="fa fa-edit" onclick="on_edit(' + value + ')"></i>',
            '</a>'].join('');
                }
    
var rules = {
    Name: {
        required: true
    },
    Description: {
        required: true
    },
    Date: {
        required: true
    }
}

var submitHandler = function (form) {
    var data = {
        Id : $('#Id').val(),
        Name: $('#Name').val(),
        Description: $('#Description').val(),
        Value: numeral().unformat($('#Value').val()),
        Date: $('#Date').val()

    };

    $.post('/api/stocklots', data).done(function (data) {
        $('#stocklot-data-modal').modal('hide');
        $('.message-area').showInfo('Successfully updated');
        $('#stocklot-table').bootstrapTable('refresh');
    }, 'json').fail(function (jqXHR, textStatus, err) {
        $('.message-area').showError(err);
    });
    return false;
}

function on_add() {
    $('#Name').val('');
    $('#Description').val('');
    $('#Id').val('0');
    $('#stocklot-data-modal').modal('show');
}

function on_edit(id) {
    $.get('/api/stocklots/' + id).done(function (data) {
        $('#Name').val(data.Name);
        $('#Description').val(data.Description);
        $('#Value').val(numeral(data.Value).format('0,0.00'));
        var date = new Date(Date.parse(data.Created));
        $('#Date').val(date.toLocaleDateString());
        $('#Id').val(data.Id);
        $('#stocklot-data-modal').modal('show');
    }).fail(function (jqXHR, textStatus, err) {
        $('.message-area').showError(err);
    });
}

function on_delete(id) {

    $.post('/api/stocklots/remove/' + id).done(function () {
        $('.message-area').showInfo('Stocklot has been successfully deleted');
        $('#stocklot-table').bootstrapTable('refresh');
    }).fail(function (jqXHR, textStatus, err) {
        $('.message-area').showError(jqXHR.responseJSON.ExceptionMessage);
    });
}


$(function () {

    $('.currency').maskMoney();

    $('#stocklot-edit-form').validate({
        rules: rules,
        highlight: function (element) {
            $(element).closest('.input-group-sm,form-group-sm').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.input-group-sm,form-group-sm').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group-sm,form-group-sm').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },
        submitHandler: submitHandler
    });
});