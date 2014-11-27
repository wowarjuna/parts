var $table;
var $datarange;

function search() {
    $table.bootstrapTable('refresh', {
        url: '/api/invoices/find/?Start=' + $('#sales-range').data('daterangepicker').startDate.format('MM/DD/YYYY') +
            '&End=' + $('#sales-range').data('daterangepicker').endDate.format('MM/DD/YYYY')
    });
    return false;
}

$(function () {
    $table = $('#search-table').bootstrapTable();
    $('#sales-range').daterangepicker({
        format: 'DD/MM/YYYY'
    });
    
});