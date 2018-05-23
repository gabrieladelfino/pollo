function abrirFrame(id){
	var tipo = document.getElementById(id).id;
	
	if(tipo == 'pollo'){
		window.location.href = "../area_inicio/Monitor.aspx";
		esconder_menu();
	}
	if(tipo == 'chocadeira'){
        window.location.href = "../area_chocadeira/chocadeira.aspx";
		esconder_menu();
	}
	if(tipo == 'ovo'){
        window.location.href = "../area_ovo/ovo.aspx";
		esconder_menu();
	}
	if(tipo == 'analytics'){
        window.location.href = "../area_consulta/analytics.aspx";
		esconder_menu();
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