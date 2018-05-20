google.charts.load('current', {'packages':['corechart']});
google.charts.setOnLoadCallback(drawChart);

[temperatura], [minuto];

function drawChart() {

    //dados
    var data = google.visualization.arrayToDataTable(dados);

    //titulos
    var options = {
        title: 'Média das temperaturas por minuto',
        hAxis: {title: 'Hora',  titleTextStyle: {color: '#333'}},
        vAxis: {minValue: 0}
    };

    //criacao
    var chart = new google.visualization.AreaChart(document.getElementById('chart_div'));
    chart.draw(data, options);

}
