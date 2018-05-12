var aceita_user;
var aceita_senha;

function verifica_user(){ //aqui eu defino que existe uma função e dou o nome, sejam sugestivos nessa hora pra conseguir visualizar no futuro
    
    var user_value = document.getElementById('user').value; //aqui estou definindo uma variavel, em js elas não tem tipos, porque acabam assumindo o tipo do valor que você insere

    if(user_value != "adm"){
        document.getElementById('user').style.border = 'solid 2px rgba(255, 100, 100, 0.8)';
        aceita_user = 0;
    }else{
        document.getElementById('user').style.border = 'solid 2px rgba(100, 255, 100, 0.8)';
        aceita_user = 1;
    }

}

function verifica_senha(){ 

    var senha_value = document.getElementById('senha').value; 

    if(senha_value != "1234"){
        document.getElementById('senha').style.border = 'solid 2px rgba(255, 100, 100, 0.8)';
        aceita_senha = 0;
    }else {
        document.getElementById('senha').style.border = 'solid 2px rgba(100, 255, 100, 0.8)';
        aceita_senha = 1;
    }

}

function aceita_login(){ 

    if(aceita_user == 1 && aceita_senha == 1){
        return true;
    }else{
        alert('User ou senha inválidos');
        return false;
    }

}

function myFunction() {
    var popup = document.getElementById("myPopup");
    popup.classList.toggle("show");
}