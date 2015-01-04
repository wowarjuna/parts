function operateFormatter(value, row, index) {
        return [          
            '<a href="/Store/Item/Edit/' + value + '" title="Edit">',
                '<i class="fa fa-edit"></i>',
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
        Name: $('#Name').val(),
        Description: $('#Description').val(),
        Value: numeral().unformat($('#Value').val()),
        Date: $('#Date').val()

    };

    $.post('/api/stocklots/stocklot', data).done(function (data) {
        $('#add-stocklot-modal').modal('hide');
        $('.message-area').showInfo('Successfully updated');
        $('#stocklot-table').bootstrapTable('refresh');
    }, 'json').fail(function (jqXHR, textStatus, err) {
        $('.message-area').showError(err);
    });
    return false;
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