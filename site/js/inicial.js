function abrirFrame(id){
	var tipo = document.getElementById(id).id;
	
	if(tipo == 'chocadeira'){
		document.getElementById('frame').src = "../area_chocadeira/cadastro.html";
	}
	if(tipo == 'ovo'){
		document.getElementById('frame').src = "../area_ovo/cadastro.html";
	}
	if(tipo == 'dispositivo'){
		document.getElementById('frame').src = "../area_chocadeira/dispositivo.html";
	}
	if(tipo == 'grafico'){
		document.getElementById('frame').src = "../area_chocadeira/grafico.html";
	}
	if(tipo == 'logout'){
		 var confirmar = confirm("Tem certeza que deseja sair?");
			if (confirmar == true){
				alert('Saindo...');
			}else{
				
			}
	}
}