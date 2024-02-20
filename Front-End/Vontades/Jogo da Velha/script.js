var troca = false
var lin1 = 0
var lin2 = 0
var lin3 = 0
var lin4 = 0
var lin5 = 0
var lin6 = 0
var lin7 = 0
var lin8 = 0
var lin9 = 0
var l1 = false
var l2 = false
var l3 = false
var l4 = false
var l5 = false
var l6 = false
var l7 = false
var l8 = false
var l9 = false
var vez = false
function linha1() {
    if (l1 == false) {
        if (vez == false) {
            document.getElementById("1").innerHTML = "X"
            vez = true;
            lin1 = 1
            if (lin1 == 1 && lin2 == 1 && lin3 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin1 == 1 && lin4 == 1 && lin7 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin1 == 1 && lin5 == 1 && lin9 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
        }
        else if (vez == true) {
            document.getElementById("1").innerHTML = "O"
            vez = false;
            lin1 = 2
            if (lin1 == 2 && lin2 == 2 && lin3 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin1 == 2 && lin4 == 2 && lin7 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin1 == 2 && lin5 == 2 && lin9 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
        }
        l1 = true
    }
}
function linha2() {
    if (l2 == false) {
        if (vez == false) {
            document.getElementById("2").innerHTML = "X"
            vez = true;
            lin2 = 1
            if (lin1 == 1 && lin2 == 1 && lin3 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin2 == 1 && lin5 == 1 && lin8 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
        }
        else if (vez == true) {
            document.getElementById("2").innerHTML = "O"
            vez = false;
            lin2 = 2
            if (lin1 == 2 && lin2 == 2 && lin3 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin2 == 2 && lin5 == 2 && lin8 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
        }
        l2 = true
    }
}
function linha3() {
    if (l3 == false) {
        if (vez == false) {
            document.getElementById("3").innerHTML = "X"
            vez = true;
            lin3 = 1
            if (lin1 == 1 && lin2 == 1 && lin3 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin3 == 1 && lin6 == 1 && lin9 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin3 == 1 && lin5 == 1 && lin7 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
        }
        else if (vez == true) {
            document.getElementById("3").innerHTML = "O"
            vez = false;
            lin3 = 2
            if (lin1 == 2 && lin2 == 2 && lin3 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin3 == 2 && lin6 == 2 && lin9 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin3 == 2 && lin5 == 2 && lin7 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
        }
        l3 = true
    }
}
function linha4() {
    if (l4 == false) {
        if (vez == false) {
            document.getElementById("4").innerHTML = "X"
            vez = true;
            lin4 = 1
            if (lin1 == 1 && lin4 == 1 && lin7 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin4 == 1 && lin5 == 1 && lin6 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
        }
        else if (vez == true) {
            document.getElementById("4").innerHTML = "O"
            vez = false;
            lin4 = 2
            if (lin1 == 2 && lin4 == 2 && lin7 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin4 == 2 && lin5 == 2 && lin6 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
        }
        l4 = true
    }
}
function linha5() {
    if (l5 == false) {
        if (vez == false) {
            document.getElementById("5").innerHTML = "X"
            vez = true;
            lin5 = 1
            if (lin4 == 1 && lin5 == 1 && lin6 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin3 == 1 && lin5 == 1 && lin7 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin1 == 1 && lin5 == 1 && lin9 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin2 == 1 && lin5 == 1 && lin8 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
        }
        else if (vez == true) {
            document.getElementById("5").innerHTML = "O"
            vez = false;
            lin5 = 2
            if (lin4 == 2 && lin5 == 2 && lin6 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin3 == 2 && lin5 == 2 && lin7 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin1 == 2 && lin5 == 2 && lin9 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin2 == 2 && lin5 == 2 && lin8 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
        }
        l5 = true
    }
}
function linha6() {
    if (l6 == false) {
        if (vez == false) {
            document.getElementById("6").innerHTML = "X"
            vez = true;
            lin6 = 1
            if (lin3 == 1 && lin6 == 1 && lin9 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin4 == 1 && lin5 == 1 && lin6 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
        }
        else if (vez == true) {
            document.getElementById("6").innerHTML = "O"
            vez = false;
            lin6 = 2
            if (lin4 == 2 && lin5 == 2 && lin6 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin3 == 2 && lin6 == 2 && lin9 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
        }
        l6 = true
    }
}
function linha7() {
    if (l7 == false) {
        if (vez == false) {
            document.getElementById("7").innerHTML = "X"
            vez = true;
            lin7 = 1
            if (lin1 == 1 && lin4 == 1 && lin7 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin7 == 1 && lin8 == 1 && lin9 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin3 == 1 && lin5 == 1 && lin7 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
        }
        else if (vez == true) {
            document.getElementById("7").innerHTML = "O"
            vez = false;
            lin7 = 2
            if (lin1 == 2 && lin4 == 2 && lin7 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin7 == 2 && lin8 == 2 && lin9 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin3 == 2 && lin5 == 2 && lin7 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
        }
        l7 = true
    }
}

function linha8() {
    if (l8 == false) {
        if (vez == false) {
            document.getElementById("8").innerHTML = "X"
            vez = true;
            lin8 = 1
            if (lin8 == 1 && lin9 == 1 && lin7 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin8 == 1 && lin5 == 1 && lin2 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
        }
        else if (vez == true) {
            document.getElementById("8").innerHTML = "O"
            vez = false;
            lin8 = 2
            if (lin8 == 2 && lin9 == 2 && lin7 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin8 == 2 && lin5 == 2 && lin2 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
        }
        l8 = true
    }
}
function linha9() {
    if (l9 == false) {
        if (vez == false) {
            document.getElementById("9").innerHTML = "X"
            vez = true;
            lin9 = 1
            if (lin8 == 1 && lin9 == 1 && lin7 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin9 == 1 && lin6 == 1 && lin3 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }
            else if (lin1 == 1 && lin5 == 1 && lin3 == 1) {
                document.getElementById("result").innerHTML = "O jogador 1 ganhou"
            }

        }
        else if (vez == true) {
            document.getElementById("9").innerHTML = "O"
            vez = false;
            lin9 = 2
            if (lin8 == 2 && lin9 == 2 && lin7 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin9 == 2 && lin6 == 2 && lin3 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
            else if (lin1 == 2 && lin5 == 2 && lin3 == 2) {
                document.getElementById("result").innerHTML = "O jogador 2 ganhou"
            }
        }
        l9 = true
    }
}
function Denovo() {
    if (troca == false) {
        vez = false
    }
    else if (troca == true) {
        vez = true
    }
    lin1 = 0
    lin2 = 0
    lin3 = 0
    lin4 = 0
    lin5 = 0
    lin6 = 0
    lin7 = 0
    lin8 = 0
    lin9 = 0
    l1 = false
    l2 = false
    l3 = false
    l4 = false
    l5 = false
    l6 = false
    l7 = false
    l8 = false
    l9 = false
    document.getElementById("result").innerHTML = ""
    document.getElementById("9").innerHTML = ""
    document.getElementById("8").innerHTML = ""
    document.getElementById("7").innerHTML = ""
    document.getElementById("6").innerHTML = ""
    document.getElementById("5").innerHTML = ""
    document.getElementById("4").innerHTML = ""
    document.getElementById("3").innerHTML = ""
    document.getElementById("2").innerHTML = ""
    document.getElementById("1").innerHTML = ""
}
function trocar() {
    if (troca == false) {
        document.getElementById("p1").innerHTML = "Jogador 1 = O"
        document.getElementById("p2").innerHTML = "Jogador 2 = X"
        vez = false
        troca = true
    }
    else if (troca == true) {
        document.getElementById("p2").innerHTML = "Jogador 2 = O"
        document.getElementById("p1").innerHTML = "Jogador 1 = X"
        vez = false
        troca = false
    }

}