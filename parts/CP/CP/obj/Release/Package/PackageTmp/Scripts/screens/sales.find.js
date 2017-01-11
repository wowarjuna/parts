var $table;
var $datarange;

function dateFormatter(value, row, index) {
    return $.formatDateTime('dd/mm/yy hh:ii', new Date(row.Created));
}

function totalFormatter(value, row, index) {
    return numeral(value).format('0,0.00');
}

function operateFormatter(value, row, index) {
    return [
        '<a class="col-md-4 view" href="javascript:void(0)" title="View">',
            '<i class="fa fa-file-o"></i>',
        '</a>'

    ].join('');
}

window.salesEvents = {
    'click .view': function (e, value, row, index) {
        $('.invoice-no').html(row.Id + ' <small>Invoice</small>');
        $('.date').text($.formatDateTime('dd/mm/yy hh:ii', new Date(row.Created)));
        $('.total').text(numeral(row.Total).format('0,0.00'));
        $('.note p').text(row.Note);
        $('.reference p').text(row.Reference);
        $('#invoice-table').bootstrapTable('refresh', {
            url: '/api/invoices/' + row.Id +'/items'
        });
        $('#view-invoice-modal').modal('show');
    }
};

function search() {
    $table.bootstrapTable('refresh', {
        url: '/api/invoices/find/?Start=' + (($('#sales-range').val() != '') ?  $('#sales-range').data('daterangepicker').startDate.format('MM/DD/YYYY') : '') +
            '&End=' + (($('#sales-range').val() != '') ? $('#sales-range').data('daterangepicker').endDate.format('MM/DD/YYYY') : '') +
            '&InvoiceNo=' + $('#invoice-no').val()
    });
    return false;
}

$(function () {
    $table = $('#search-table').bootstrapTable();
    $('#sales-range').daterangepicker({
        format: 'DD/MM/YYYY'
    });
    
});