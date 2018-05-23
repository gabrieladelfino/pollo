google.charts.load('current', {'packages':['corechart']});
google.charts.setOnLoadCallback(drawChart);

function drawChart() {

    //dados
    var data = google.visualization.arrayToDataTable(dados);

    //titulos
    var options = {
        title: 'Média das temperaturas por minuto',
        hAxis: { title: 'Minuto', titleTextStyle: { color: '#333' } },
        vAxis: { minValue: 0 }
    };

    //criacao
    var chart = new google.visualization.AreaChart(document.getElementById('chart_div'));
    chart.draw(data, options);

}
