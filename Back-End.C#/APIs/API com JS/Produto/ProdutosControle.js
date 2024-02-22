const token = localStorage.getItem('chave')
function carregar(){

    document.getElementById("tableprodutos").innerHTML = ""
    fetch("https://localhost:7196/api/produtos", {headers: {'Authorization': 'Bearer ' + token}})
    .then(dados => dados.json())
    .then(resposta => {resposta.forEach(item => {document.getElementById("tableprodutos").innerHTML += 
    `<tr><td>${item.id}</td>
    <td>${item.descricao}</td>
    <td>${item.preco}</td>
    <td>${item.estoque}</td>
    <td>${item.categoria.nome}</td>
    <td><button onclick="deletar(${item.id})">X</button></td>
    <td><button onclick="alt(${item.id})">alt</button></td>
    </tr>`})
})
/*document.getElementById("tableprodutos").innerHTML = ""
    var lista = []
    var listaCategoria = []
    fetch("https://localhost:7196/api/produtos")
    .then(dados => dados.json())
    .then(resposta => {lista = resposta
        console.log(lista[0].categoria.nome)
        fetch("https://localhost:7196/api/categorias")
    .then(dados1 => dados1.json())
    .then(resposta1 => {listaCategoria = resposta1
    
        lista.forEach(element => {
            listaCategoria.forEach(item =>{
                if(element.categoriaid == item.id){
                    element.categoria = {nome: item.nome}
                }
            }
            )
        })
    })
    lista.forEach(item2 => document.getElementById("tableprodutos").innerHTML += `<tr><td>${item2.id}</td><td>${item2.descricao}</td><td>${item2.preco}</td><td>${item2.estoque}</td><td>${item2.categoria.nome}</td></tr>`)
})*/
}
function criar(){
    const obj = {
        descricao: document.getElementById("descricao").value,
        preco: document.getElementById("preco").value, 
        estoque: document.getElementById("estoque").value,
        categoria: {
            id: document.getElementById("categoriaid").value
        }
    }
    const options = {
        method: 'POST',
        headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token,
        },
        body: JSON.stringify(obj),
        };
        fetch('https://localhost:7196/api/produtos', options)
    }
function deletar(id){
        fetch(`https://localhost:7196/api/produtos/${id}`, {method: "Delete", headers: {'Authorization': 'Bearer ' + token}})
}
function alt(id){
    document.getElementById("edit").innerHTML = `
    <input type="text" id="descricao" placeholder="Descrição">
    <input type="number" id="estoque" placeholder="Estoque">
    <input type="number" id="preco" placeholder="Preço">
    <input type="number" id="categoriaid" placeholder="Id da Categoria">
    <button onclick="alterar(${id})">Alterar</button>`}

function alterar(id){
    const obj = {
        id: id,
        descricao: document.getElementById("descricao").value,
        preco: document.getElementById("preco").value, 
        estoque: document.getElementById("estoque").value,
        categoria: {
            id: document.getElementById("categoriaid").value
        }}
    const options = {
        method: "Put",
        headers: { 'content-type': 'application/json',
        'Authorization': 'Bearer ' + token
    },
        body: JSON.stringify(obj)
    }
    fetch(`https://localhost:7196/api/produtos/${id}`, options)
    
}

