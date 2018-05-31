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

var tempo_seg= 5 // Tempo em segundos
var tempo_ms= tempo_seg * 1000 // Tempo em milésimos de segundo
function Atualiza() {
    goAjax("../area_consulta/analytics.aspx")
    setTimeout("Atualiza()", tempo_ms)
}
function goAjax(url) {
    xmlhttp = new XMLHttpRequest()
    xmlhttp.open("GET", url, true)
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4) {
            retorno = xmlhttp.responseText
            divisao = document.getElementById("chart_div")
            divisao.innerHTML = retorno
        }
    }
    xmlhttp.send(null)
}
