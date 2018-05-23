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

function mascara_cpf(campo, evt) {
    if (campo.value.length == 3) {
        campo.value += '.';
    } if (campo.value.length == 7) {
        campo.value += '.';
    } if (campo.value.length == 11) {
        campo.value += '-';
    }
}
