create table tb_cliente(
id_cliente int primary key not null auto_increment,
nome varchar(45) not null,
fone varchar(14) not null,
gmail varchar(30) not null
);

insert into tb_cliente(id_cliente,nome,fone,gmail)
values(1,'caua','47 9914310599', 'caualabes@gmail.com');

create table tb_pedido(
id_pedido int primary key not null auto_increment,
data date not null,
produto varchar(25) not null,
cliente varchar(25) not null,
constraint cliente foreign key(cliente) references tb_cliente (id_cliente)
);

insert into tb_pedido(id_pedido, data, produto, cliente)
values(1, '2023-10-23', 'shampoo', 1);

create table tb_estoque(
id_estoque int primary key not null auto_increment

)

