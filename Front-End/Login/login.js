var dados = []
var dads = {}
function cadastrar() {
    var user = document.getElementById("usuario").value
    var gm = document.getElementById("gmail").value
    var senha = document.getElementById("senha").value
    var senhaconf = document.getElementById("senhaconfirm").value
    if (user == "") {
        alert("Insira um nome de usuario")
        return
    }
    if (!gm.includes("@")) {
        alert("Seu gmail esta inválido")
        return
    }


    if (senha == "") {
        alert("Insira uma senha")
        return
    }
    if (senha != senhaconf) {
        alert("Senhas diferentes")
        return;
    }

    dads = { Gmail: gm, Usuario: user, Senha: senha }
    dados.unshift(dads)
    localStorage.setItem(JSON.stringify("Dados", dados))


}
function verificarLogin() {
    var id = document.getElementById("id").value
    var Senha = document.getElementById("senha").value

    var verificacao = []
    var verificaco = {}

    verificaco = (JSON.parse(localStorage.getItem("Dados")))
    verificacao.unshift
    var verifica = false;
    for (let i = 0; i < verificacao.length; i++) {

        if (dados[i].Usuario == id) {
            alert("válido")
        }
    }
}
