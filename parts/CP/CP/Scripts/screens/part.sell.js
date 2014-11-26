var $table;


function calculate_total() {
    var total = 0;
    $('[name^="QuotedPrice"]').each(function (idx, data) {
        var suffix = $(this).attr('name').replace('QuotedPrice', '');
        var subtot = numeral().unformat($(this).val()) * numeral().unformat($('[name="Qty' + suffix + '"]').val());
        total += subtot;
        
    });
    $('.total').text(numeral(total).format('0,0.00'));
}

function on_figure_changed(elem) {    
    var suffix = $(elem).attr('name').replace('QuotedPrice', '').replace('Qty', '');
    var subtot =  numeral().unformat($('[name="QuotedPrice' + suffix + '"]').val()) * numeral().unformat($('[name="Qty' + suffix + '"]').val());
    $('#Total' + suffix).text(numeral(subtot).format('0,0.00'));
    calculate_total();
}

function delete_item(id) {
    $.post('/Store/Item/DeleteFromCart', { id: id }, delete_item_done, 'json');
}

function delete_item_done(json) {
    $table.bootstrapTable('load', json);
    var total = 0;
    $(json).each(function (idx, row) {
        total += row.QuotedPrice;

    });
    $('.total').text(numeral(total).format('0,0.00'));
}

function on_load() {
    $table = $('#checkout-table').bootstrapTable({
        url: "/Store/Item/Cart/" + $.now(),
        onLoadSuccess: function (data) {
            var total = 0;
            $(data).each(function (idx, row) {
                total += row.QuotedPrice;

            });
            $('.total').text(numeral(total).format('0,0.00'));
        }
    });
}

function on_payment_submit() {
    var items = new Array();
    $('[name^="QuotedPrice"]').each(function (idx, data) {
        var suffix = $(this).attr('name').replace('QuotedPrice', '')
        items.push({
            UnitPrice: $(this).val(),
            Qty: $('[name="Qty' + suffix + '"]').val(),
            ItemId: suffix
        });
    });

    $.post('/api/invoices', { Total: $('.total').text(), Items: items }, on_payment_complete, 'json');
    return false;
}

function on_payment_complete(json) {
    window.location.href = '/Store/Invoice/' + json.InvoiceId;
}

function on_payment_cancel() {
    $.post('/store/item/cancelcheckout', function () {
        window.location.href = '/Store/Item';
    });
    return false;
}

$(function () {
    on_load();

    $('#checkout-table').on('focus', '.number-mask,.qty-mask', function () {
        $(this).maskMoney();
    });
    
    $('#checkout-table').on('keyup', '.number-mask,.qty-mask', function () {
        if ($(this).hasClass('qty-mask') && this.value > parseInt($(this).siblings('span').text()))
        {           
            $(this).val($(this).siblings('span').text());
        }
        on_figure_changed(this);
    });
});