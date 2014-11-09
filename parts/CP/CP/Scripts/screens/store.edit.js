var apiUrl = '/api/stores/';
var rules = {
    Address: {
        required: true
    },
    LocationLon: {
        required: true,
        range: [-180, 180]
    },
    LocationLat: {
        required: true,
        range: [-180, 180]
    },
    Fax: {
        digits: true
    },
    Phone: {
        digits: true
    },
    Email: {
        email: true
    }
}

var submitHandler = function (form) {
    var data = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        Address: $('#Address').val(),
        Email: $('#Email').val(),
        Phone: $('#Phone').val(),
        LocationLon: $('#LocationLon').val(),
        LocationLat: $('#LocationLat').val()
    };

    $.post(apiUrl, data).done(function (data) {
        $('.message-area').showInfo('Successfully updated');
    }, 'json').fail(function (jqXHR, textStatus, err) {
        $('.message-area').showError(err);
    });
    return false;
}

$(function () {
    var id = $('#Id').val();
    $.getJSON(apiUrl + '/' + id)
        .done(function (data) {
            $('#Name').val(data.Name);
            $('#Address').val(data.Address);
            $('#Email').val(data.Email);
            $('#Phone').val(data.Phone);
            $('#LocationLon').val(data.LocationLon);
            $('#LocationLat').val(data.LocationLat);
        })
        .fail(function (jqXHR, textStatus, err) {
            
        });

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

