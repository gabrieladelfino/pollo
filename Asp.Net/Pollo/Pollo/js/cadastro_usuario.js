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