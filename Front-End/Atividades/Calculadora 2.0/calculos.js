
sinal = ''
function get(item) {
    if (sinal == "x" || sinal == "/" || sinal == "+" || sinal == "-") {
        document.getElementById("y").innerHTML += item
    }
    else {
        document.getElementById("x").innerHTML += item
    }
}

function somar() {
    sinal = "+"
    document.getElementById("sinal").innerHTML = " + "
}
function subtrair() {
    sinal = "-"
    document.getElementById("sinal").innerHTML = " - "
}
function multiplicar() {
    sinal = "x"
    document.getElementById("sinal").innerHTML = " x "
}
function dividir() {
    sinal = "/"
    document.getElementById("sinal").innerHTML = " / "
}
function result() {
    var n1 = parseInt(document.getElementById("x").innerHTML)
    var n2 = parseInt(document.getElementById("y").innerHTML)
    var result = 0
    if (sinal == "+")
        var result = (n1 + n2)
    else if (sinal == "-")
        var result = (n1 - n2)
    else if (sinal == "x")
        var result = (n1 * n2)
    else if (sinal == "/") {
        var result = (n1 / n2)
    }
    document.getElementById("result").innerHTML = " = " + result
    
}
function limpar() {
    document.getElementById("x").innerHTML = ''
    document.getElementById("y").innerHTML = ''
    document.getElementById("result").innerHTML = ''
    document.getElementById("sinal").innerHTML = ''
    sinal = ''
}