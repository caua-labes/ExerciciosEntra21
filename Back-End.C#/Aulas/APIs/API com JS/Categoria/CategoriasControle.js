const token = localStorage.getItem('chave')
function carregar(){
    document.getElementById("table").innerHTML = ""
    fetch("https://localhost:7196/api/categorias", 
    {
        headers : {
            'Authorization': 'Bearer ' + token
        }
    })
    .then(dados => dados.json())
    .then(resposta => resposta.forEach(item => {
        document.getElementById("table").innerHTML += `<tr><td>${item.id}</td><td>${item.nome}</td><td><button onclick="deletar(${item.id})">X</button></td><td><button onclick="alterar(${item.id})">alt</button></td><tr>`}))
    }

function criar(){
    const update = {
        nome : document.getElementById("Nome").value
        };
        
        const options = {
        method: 'POST',
        headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
        },
        body: JSON.stringify(update),
        };
        fetch('https://localhost:7196/api/categorias', options)
    }

    function deletar(id){
        fetch(`https://localhost:7196/api/categorias/${id}`, {method: 'Delete', headers: {'Authorization': 'Bearer ' + token}})
    }
    function alterar(id){
        document.getElementById("edit").innerHTML = `<input type="text" id="nomeCategoria" placeholder="Nome"> <button onclick="alt(${id})">Alterar</button>`
    }
    function alt(id){
        obj = {
            id: id,
            nome: document.getElementById("nomeCategoria").value
        }
        const options = {
            method: 'PUT',
            headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
            },
            body: JSON.stringify(obj),
            };
        fetch(`https://localhost:7196/api/categorias/${id}`, options)
    }

