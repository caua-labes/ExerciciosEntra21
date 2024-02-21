var carta = []
var ca = false
var par = 0

var maior = 0
var menor = 0

var antP1 = 0
var antP2 = 0

var numbers = [];

while (numbers.length < 10) {
    var numeroRandomizado = Math.floor(Math.random() * 10);
    if (!numbers.includes(numeroRandomizado)) {
        numbers.push(numeroRandomizado);
    }
}

var per1 = numbers[0];
var per2 = numbers[1];
var per3 = numbers[2];
var per4 = numbers[3];
var per5 = numbers[4];
var per6 = numbers[5];
var per7 = numbers[6];
var per8 = numbers[7];
var per9 = numbers[8];
var per10 = numbers[9];

console.log(per1, per2, per3, per4, per5, per6, per7, per8, per9, per10);

document.getElementsByTagName("p")[per1].innerHTML = "Perieli "
document.getElementsByTagName("p")[per2].innerHTML = "Primeira Lei de Newton"
document.getElementsByTagName("p")[per3].innerHTML = "2ª lei de Kepler"
document.getElementsByTagName("p")[per4].innerHTML = "8"
document.getElementsByTagName("p")[per5].innerHTML = "Afelio "
document.getElementsByTagName("p")[per6].innerHTML = "1ª lei de Kepler"
document.getElementsByTagName("p")[per7].innerHTML = "Lei da Força e Aceleração"
document.getElementsByTagName("p")[per8].innerHTML = "Isaac Newton"
document.getElementsByTagName("p")[per9].innerHTML = "Lei da Ação e Reação"
document.getElementsByTagName("p")[per10].innerHTML = "Lei dos períodos"

document.getElementsByTagName("p")[per1 + 10].innerHTML = "Perto"
document.getElementsByTagName("p")[per2 + 10].innerHTML = "Lei da Inércia"
document.getElementsByTagName("p")[per3 + 10].innerHTML = "Lei das áreas"
document.getElementsByTagName("p")[per4 + 10].innerHTML = "O sistema solar é composto por quantos planetas"
document.getElementsByTagName("p")[per5 + 10].innerHTML = "Longe"
document.getElementsByTagName("p")[per6 + 10].innerHTML = "Lei das órbitas"
document.getElementsByTagName("p")[per7 + 10].innerHTML = "Segunda Lei de Newton"
document.getElementsByTagName("p")[per8 + 10].innerHTML = "Quem criou as leis da gravitação"
document.getElementsByTagName("p")[per9 + 10].innerHTML = "Terceira Lei de Newton"
document.getElementsByTagName("p")[per10 + 10].innerHTML = "3ª lei de Kepler"

var vez = false

var ps = document.getElementsByTagName("p")
var div = document.getElementsByTagName("div")


function get(item) {

    par += 1
    if (vez == false) {
        if (ca == false) {
            antP1 = item
            ca = true
            ps[antP1 - 1].classList.remove("fechado");
            ps[antP1 - 1].classList.add("vira");
        }

        else if (ca == true) {
            antP2 = item
            ca = false
            ps[item - 1].classList.remove("fechado");
            ps[item - 1].classList.add("vira");
            if (antP1 < antP2) {
                menor = antP1
                antP1 = antP2
                antP2 = menor
            }
            vez = true
        }
    }

    if (antP2 + 10 == antP1) {
        par = 0
        vez = false
        if (antP2 == 1 && antP1 == 11) {

            div[antP2].onclick = null
            div[antP1].onclick = null
        }
        if (antP2 == 2 && antP1 == 12) {
            div[antP2].onclick = null
            div[antP1].onclick = null
        }
        if (antP2 == 3 && antP1 == 13) {
            div[antP2].onclick = null
            div[antP1].onclick = null
        }
        if (antP2 == 4 && antP1 == 14) {
            div[antP2].onclick = null
            div[antP1].onclick = null
        }
        if (antP2 == 5 && antP1 == 15) {
            div[antP2].onclick = null
            div[antP1].onclick = null
        }
        if (antP2 == 6 && antP1 == 16) {
            div[antP2].onclick = null
            div[antP1].onclick = null
        }
        if (antP2 == 7 && antP1 == 17) {
            div[antP2].onclick = null
            div[antP1].onclick = null
        }
        if (antP2 == 8 && antP1 == 18) {
            div[antP2].onclick = null
            div[antP1].onclick = null
        }
        if (antP2 == 9 && antP1 == 19) {
            div[antP2].onclick = null
            div[antP1].onclick = null
        }
        if (antP2 == 10 && antP1 == 20) {
            div[antP2].onclick = null
            div[antP1].onclick = null
        }

    }
    else if (vez == true) {

        if (par == 3) {

            console.log(antP1)
            console.log(antP2)



            par = 0
            ps[antP1 - 1].classList.remove("vira");
            ps[antP1 - 1].classList.add("fechado");

            ps[antP2 - 1].classList.add("fechado");
            ps[antP2 - 1].classList.remove("vira");

            vez = false
        }
    }
}
let tempoRestante = 0;

function atualizarContador() {
    const contador = document.getElementById("contador");
    contador.textContent = tempoRestante;
}

function iniciarTemporizador() {
    const mensagem = document.getElementById("mensagem");

    const intervalo = setInterval(function () {
        tempoRestante++;

        atualizarContador();

    }, 1000);
}
iniciarTemporizador();