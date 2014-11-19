function on_load() {
    var total = 0;
    $('[name^="QuotedPrice"]').each(function (idx, data) {
        var suffix = $(this).attr('name').replace('QuotedPrice', '');
        var subtot = numeral().unformat($(this).val()) * $('[name="Qty' + suffix + '"]').val();
        total += subtot;
        $('.Total' + suffix).text(numeral(subtot).format('0,0.00'));
    });
    $('.total').text(numeral(total).format('0,0.00'));
}

function on_figure_changed(elem) {    
    var suffix = $(elem).attr('name').replace('QuotedPrice', '').replace('Qty', '');
    var subtot =  numeral().unformat($('[name="QuotedPrice' + suffix + '"]').val()) * numeral().unformat($('[name="Qty' + suffix + '"]').val());
    $('.Total' + suffix).text(numeral(subtot).format('0,0.00'));
    on_load();
}

$(function(){
    on_load();
    $('.number-mask').maskMoney();
    $('.qty-mask').maskMoney();
    $('.number-mask,.qty-mask').blur(function () {
        on_figure_changed(this);
    });
});