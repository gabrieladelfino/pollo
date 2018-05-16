//  o ID do Monitor eh o cod da chocadeira que vamos pegar do banco 
// vou por partes por enquanto
// primeira linha defini que temos uma FUNÇÃO chamada mostrar(), até ai blz?
// a segunda linha eu to dizendo "procure no documento e pegue um elemento que se chame 'menu'"
//depois busque o estilo dele e um atributo "display" e sete ele como 'block'
//todas as outras linhas repito isso para os elementos filhos do menu, no caso os botoes

function mostrar() {
    document.getElementById('menu').style.display = 'block';
    document.getElementById('salvar').style.display = 'block';
    document.getElementById('editar').style.display = 'block';
    document.getElementById('excluir').style.display = 'block';
    document.getElementById('relatorio').style.display = 'block';
}

function esconder() {
    document.getElementById('menu').style.display = 'none';
    document.getElementById('salvar').style.display = 'none';
    document.getElementById('editar').style.display = 'none';
    document.getElementById('excluir').style.display = 'none';
    document.getElementById('relatorio').style.display = 'none';
}


// Get the modal
var modal = document.getElementById('myModal');

// Get the button that opens the modal
var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal 
btn.onclick = function () {
    modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

