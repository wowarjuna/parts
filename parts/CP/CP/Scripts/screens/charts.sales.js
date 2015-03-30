var $chart;
var $start;
var $end;

function generate() {
   $.get('/store/charts/getsaleschart?from='
        + $('#sales-range-start').val()
        + '&to=' + $('#sales-range-end').val()
        + '&stamp=' + $.now(), generate_done, 'json');
}

function generate_done(json) {
    var data = new Array();
    var j = $start.getMonth() + 1;
    for (var i = $start.getFullYear() ; i <= $end.getFullYear() ; i++) {
        for (; j <= 12; j++) {
            var key = i + '-' + j.toString().padLeft(2,'0');
            var val = 0;
            $(json).each(function (idx, obj) {
                if (obj.Month == key) {
                    val = obj.Val;                   
                }
            });
            data.push({ Month: key, Val: val });
            if(j == 12)
            {
                j = 1;
                break;
            }

            if(j > $end.getMonth() && i == $end.getFullYear())
            {
                break;
            }
        }
    }

    $chart = new Morris.Bar({
        element: 'bar-chart',
        data: data,
        resize: true,
        barColors: ['#00a65a'],
        xkey: 'Month',
        ykeys: ['Val'],
        labels: ['Sales'],
        hideHover: 'auto'
    });

}


$(function () {    
    $("#sales-range-start,#sales-range-end").datepicker({
        format: "mm-yyyy",
        viewMode: "months",
        minViewMode: "months"
    }).on('changeDate', function (ev) {
        if ($(ev.target).attr('id') == 'sales-range-start')
            $start = ev.date;
        else
            $end = ev.date;
    });
});