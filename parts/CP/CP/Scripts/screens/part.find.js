var $table;

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

function search() {
    var data = {
        Name: $('#Name').val()         
    };

    $table.bootstrapTable('refresh', {
        url: '/api/items/find/?Name=' + $('#Name').val() + '&BrandId=' + $('#BrandId').val()
    });

   
    return false;
}

$(function () {
    $('#BrandId').change(on_brand_changed);
    $table = $('#search-table').bootstrapTable();
});