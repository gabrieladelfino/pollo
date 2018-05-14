function abrirFrame(id){
	var tipo = document.getElementById(id).id;
	
	if(tipo == 'bundinha'){
		window.location.href = "../area_inicio/inicial.html";
		esconder_menu();
	}
	if(tipo == 'chocadeira'){
		document.getElementById('frame').src = "../area_chocadeira/cadastro.html";
		esconder_menu();
	}
	if(tipo == 'ovo'){
		document.getElementById('frame').src = "../area_ovo/cadastro.html";
		esconder_menu();
	}
	if(tipo == 'dispositivo'){
		document.getElementById('frame').src = "../area_chocadeira/dispositivo.html";
		esconder_menu();
	}
	if(tipo == 'grafico'){
		document.getElementById('frame').src = "../area_chocadeira/grafico.html";
		esconder_menu();
	}
	if(tipo == 'logout'){
		 var confirmar = confirm("Tem certeza que deseja sair?");
			if (confirmar == true){
				alert('Saindo...');
			}else{
				
			}
	}
}


function troca_icon(id){
	
	var tipo = document.getElementById(id).id;
	
	if(tipo == 'graph'){
		document.getElementById('graph').src = "../imagens/icones/graficoh.png";
	}
	if(tipo == 'ovo'){
		document.getElementById('ovo').src = "../imagens/icones/ovoh.png";
	}
}

function esconde_icon(id){
	
	var tipo = document.getElementById(id).id;
	
	if(tipo == 'graph'){
		document.getElementById('graph').src = "../imagens/icones/grafico.png";
	}
	if(tipo == 'ovo'){
		document.getElementById('ovo').src = "../imagens/icones/ovo.png";
	}
}

function mostrar_menu(){
    document.getElementById('menu1').style.display = 'block';
	 document.getElementById('submenu').style.display = 'block';
}

function esconder_menu(){
    document.getElementById('menu1').style.display = 'none';
	 document.getElementById('submenu').style.display = 'none';
}