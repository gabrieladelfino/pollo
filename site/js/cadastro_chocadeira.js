var modal;
var sensor;
var entrada;
var lista_sensores;
var qtde = 0;
var luz =0, umidade =0, temperatura =0;

function abrir_dispositivo() {
	modal = document.getElementById('popup_dispositivo');
	modal.style.display = "block";
}

function fechar_dispositivo() {
	modal = document.getElementById('popup_dispositivo');
	modal.style.display = "none";
}

function abrir_ovo() {
	modal = document.getElementById('popup_ovo');
	modal.style.display = "block";
}

function fechar_ovo() {
	modal = document.getElementById('popup_ovo');
	modal.style.display = "none";
}

function addSensor(){
	sensor = document.getElementById('sensor').value;
	entrada = document.getElementById('entrada').value;
	
	if(qtde==0){
		lista_sensores = document.getElementById('add').value = sensor+','+entrada;
		qtde++;
		if(sensor=='Luz'){
			luz++;
			alert(luz);
		}
	}else{
		lista_sensores = document.getElementById('add').value = lista_sensores+'\n'+sensor+','+entrada;
		qtde++;
		if(sensor=='Luz'){
			luz++;
			alert(luz);
		}
	}
}