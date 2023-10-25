create schema Loja;

create table cliente(
id int primary key not null auto_increment,
nome varchar(25) not null,
fone varchar(15)not null,
cep int not null,
rua varchar(25) not null,
estado varchar(2) not null,
numero int not null
);

create table pedido(
id int primary key not null auto_increment,
data date not null,
produto varchar(15) not null,
cliente int not null,
constraint cliente foreign key (cliente) references cliente(id)
);  
create table fornecedor(
id int primary key not null auto_increment,
nome varchar(25) not null,
produto varchar(25) not null,
preco decimal(5,2) not null
);
create table comprador(
id int primary key not null auto_increment,
nome varchar(25) not null,
cadastro int not null
);
create table compra(
id int primary key not null auto_increment,
id_fornecedor int not null,
constraint id_fornecedor foreign key(id_fornecedor) references fornecedor(id),
quantidade int not null,
id_comprador int not null,
constraint id_comprador foreign key(id_comprador) references comprador(id)
);

CREATE TABLE estoque(
  id INT NOT NULL AUTO_INCREMENT primary key,
  produto VARCHAR(45) NOT NULL,
  precoUnico DECIMAL(5,2) NOT NULL,
  descricao VARCHAR(45) NOT NULL,
  estoque INT NOT NULL,
  id_compra int not null,
  constraint id_compra foreign key(id_compra) references compra(id)
  );
CREATE TABLE IF NOT EXISTS venda (
  quantidade INT NOT NULL,
  preco DECIMAL(5,2) NOT NULL,
  id INT NOT NULL AUTO_INCREMENT primary key,
  id_estoque int not null,
  id_pedido int not null,
  constraint id_estoque foreign key(id_estoque) references estoque(id),
  constraint id_pedido foreign key(id_pedido) references pedido(id)
  );
  
		insert into cliente(id,nome,fone,cep,rua,estado,numero) values(1,'Marcos',4712332543123,89023289,'pinheiro machado','sc',35);
		insert into cliente(id,nome,fone,cep,rua,estado,numero) values(2,'Joana',4712345678910,89043500,'pinheiro arvore','sc',53);
		insert into cliente(id,nome,fone,cep,rua,estado,numero) values(3,'Carlos',4712332543123,890798289,'axado retro','sc',08);
      
		select * from cliente;
        
		select * from pedido;
      
		insert into pedido(id,data,produto,cliente) values(4,'2023-09-01','parafuso',1);
		insert into pedido(id,data,produto,cliente) values(5,'2023-11-29','capacete',1);
		insert into pedido(id,data,produto,cliente) values(3,'2023-09-01','anel de rubi',2);
        
		insert into pedido(id,data,produto,cliente) values(4,'2023-09-01','parafuso',1);
		insert into pedido(id,data,produto,cliente) values(5,'2023-11-29','capacete',1);
		insert into pedido(id,data,produto,cliente) values(3,'2023-09-01','anel de rubi',2);
        


      