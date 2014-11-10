
var on_brand_changed = function () {
    $.getJSON('/api/models/bybrand/' + $(this).val())
       .done(function (data) {
           $('#ModelId').empty();
           $.each(data, function (i, value) {
               $('#ModelId').append($('<option>').text(value.Name).attr('value', value.Id));
           });
       })
       .fail(function (jqXHR, textStatus, err) {
           alert(err);
       });
}

function search() {
    var data = {
        Name: $('#Name').val()         
    };

    $.getJSON('/api/items/find', data).done(function (data) {
        $('.message-area').showInfo('Successfully updated');
    }, 'json').fail(function (jqXHR, textStatus, err) {
        $('.message-area').showError(err);
    });
    return false;
}

$(function () {
    $('#BrandId').change(on_brand_changed);
});