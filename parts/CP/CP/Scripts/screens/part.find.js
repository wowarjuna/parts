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

var on_add_to_cart_completed = function (data) {
    if (data.success) {
        $('#add-to-checkout-modal').modal('show');
    }
}

function on_checkout() {
   window.location.href = '/Store/Item/Sell';
}

function search() {    
    $table.bootstrapTable('refresh', {
        url: '/api/items/find/?Name=' + $('#Name').val() +
            '&BrandId=' + $('#BrandId').val() +
            '&CategoryId=' + $('#CategoryId').val() +
            '&PartNo=' + $('#PartNo').val() +
            '&ModelId=' + $('#ModelId').val()
    });   
    return false;
}

function addToCart() {
    var ids = new Array();
    var selections = $table.bootstrapTable('getSelections');
    $(selections).each(function(index, d) {
        ids.push(d.Id);
    });
    $.post('/store/item/addtocart', { idList: ids }, on_add_to_cart_completed, 'json');
    return false;
}

$(function () {
    $('#BrandId').change(on_brand_changed);
    $table = $('#search-table').bootstrapTable();
});