
var rules = {
    Name: {
        required: true
    },
    Year: {
        required: true
    },
    Qty: {
        required: true
    }
}

var submitHandler = function (form) {
    var data = {
        Name: $('#Name').val(),
        PartNo: $('#PartNo').val(),
        Year: $('#Year').val(),
        BrandId: $('#BrandId').val(),
        ModelId: $('#ModelId').val(),
        CategoryId: $('#CategoryId').val(),
        Description: $('#Description').val(),
        StoreInfo: $('#StoreInfo').val(),
        Qty: $('#Qty').val(),
        QuotedPrice: $('#QuotedPrice').val(),
        Active: $('#Active').prop('checked')
    };

    $.post('/api/items', data).done(function (data) {
        $('.message-area').showInfo('Successfully updated');
    }, 'json').fail(function (jqXHR, textStatus, err) {
        $('.message-area').showError(err);
    });
    return false;
}


var on_brand_changed = function () {
    $.getJSON('/api/models/bybrand/' + $(this).val())
       .done(function (data) {
           $('#ModelId').empty();
           $('#ModelId').append($('<option>').text('- Select -').attr('value', 0));
           $.each(data, function (i, value) {
               $('#ModelId').append($('<option>').text(value.Name).attr('value', value.Id));
           });
       })
       .fail(function (jqXHR, textStatus, err) {
           alert(err);
       });
}

$(function () {
    $('#BrandId').change(on_brand_changed);

    $('form').validate({
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