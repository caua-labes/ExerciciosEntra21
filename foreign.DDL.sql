
create table compromisso(
ID_compromisso int primary key not null auto_increment,
descricao varchar (100) not null,
local varchar(75) not null,
data date not null,
hora time not null
);

create table contato(
ID_contato int primary key not null auto_increment,
nome varchar(50) not null,
fone varchar(14) not null,
email varchar(50) not null
);

insert into compromisso(ID_compromisso,descricao,local,data,hora)
values(2, 'restaurante', 'rua abc', '2023-12-12','23:00:00');

create table compromissos(
ID_contato int,
ID_compromisso int,
constraint fk_contatos foreign key(ID_contato) references contato(ID_contato),
constraint fk_compromisso foreign key(ID_compromisso) references compromisso(ID_compromisso)
);
