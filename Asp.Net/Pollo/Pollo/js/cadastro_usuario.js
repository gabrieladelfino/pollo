function mostra_info_usuario() {
    document.getElementById('info-usuario').style.display = 'block';
    document.getElementById('info-login').style.display = 'none';
    document.getElementById('info-recuperacao-senha').style.display = 'none';
}

function mostra_info_login() {
    document.getElementById('info-usuario').style.display = 'none';
    document.getElementById('info-login').style.display = 'block';
    document.getElementById('info-recuperacao-senha').style.display = 'none';
}

function mostra_info_recuperacao_senha() {
    document.getElementById('info-usuario').style.display = 'none';
    document.getElementById('info-login').style.display = 'none';
    document.getElementById('info-recuperacao-senha').style.display = 'block';
}


function mascara_data(campo) {
    if (campo.value.length == 2) {
    campo.value += '/';
    }
    if (campo.value.length == 5) {
    campo.value += '/';
    }
}

function clicou_telefone(campo) {
    if (campo.value.length <= 0) {
        campo.value += '(';
    }
    else {
    }
}

function mascara_telefone(campo) {
     if (campo.value.length == 3) {
        campo.value += ')';
    } if (campo.value.length == 9) {
        campo.value += '-';
    } 
}

function verificar(campo) {
    if (campo.value.length <= 0) {
        campo.style.borderColor = 'rgba(215, 44, 44, 0.5)';
    }
    if (campo.value == "") {
        campo.style.borderColor = 'rgba(215, 44, 44, 0.5)';
    }
    else {
        campo.style.borderColor = 'rgba(30, 217, 44, 0.5)';
    }
}

function somenteLetras(e) {
    var tecla = new Number();
    if (window.event) {
        tecla = e.keyCode;
    }
    else if (e.evt) {
        tecla = e.which;
    }
    else {
        return true;
    }
    if ((tecla >= "48") && (tecla <= "57")) {
        return false;
    }
}

function somenteNumeros(e) {
    var tecla = new Number();
    if (window.event) {
        tecla = e.keyCode;
    }
    else if (e.which) {
        tecla = e.which;
    }
    else {
        return true;
    }
    if ((tecla >= "97") && (tecla <= "122")) {
        return false;
    }
}