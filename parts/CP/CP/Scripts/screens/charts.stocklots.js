var $chart;

function generate() {
    $.get('/store/charts/getstocklotchart?from='
        + $('#stocklot-range').data('daterangepicker').startDate.format('MM/DD/YYYY')
        + '&to=' + $('#stocklot-range').data('daterangepicker').endDate.format('MM/DD/YYYY')
        + '&stamp=' + $.now(), generate_done, 'json');
}

function generate_done(json) {
   

    $chart = new Morris.Bar({
        element: 'bar-chart',
        data: json,
        resize: true,
        barColors: ['#f56954', '#00a65a'],
        xkey: 'Name',
        ykeys: ['QuotedVal', 'Return'],
        labels: ['QuotedVal', 'Return'],
        hideHover: 'auto'
    });
    
}

$(function () {
    "use strict";

    $('#stocklot-range').daterangepicker({
        format: 'DD/MM/YYYY'
    });



});