create schema agenda;

create table contatos(
  id int primary key not null auto_increment,
  nome varchar(45) not null,
  email varchar(45),
  fone varchar(14)
);

create table locais(
  id int primary key auto_increment,
  nome varchar(45) not null,
  rua varchar(45),
  numero int
);

create table compromissos(
   id int primary key auto_increment,
   descricao varchar(100) not null,
   data date not null,
   hora time not null,
   local int not null,
   constraint local foreign key(local) references locais(id)
);
alter table compromissos 
add column contatos int not null,
add constraint contatos
foreign key(contatos)
references contatos(id);

insert into locais(id,nome,rua,numero)
values(1,"restaurante", "dom pedro II", 43);

insert into locais(id,nome,rua,numero)
values(2,"hotel", "dom trusy", 983);

insert into contatos(id,nome,email,fone)
values(1,"Maria", "maria@hotmail.com", "47991234321");

insert into contatos(id,nome,email,fone)
values(2,"Kauna", "kau@hotmail.com", "47991234567");

insert into compromissos(id,descricao,data,hora,local,contatos) 
values(1,"almoço",'2020-10-10',12.30,1,1);

insert into compromissos(id,descricao,data,hora,local,contatos) 
values(2,"jantar",'2024-12-25',21.30,1,2);

insert into compromissos(id,descricao,data,hora,local,contatos) 
values(3,"cafe da manhã",'2024-12-25',10.10,2,1);

select * from contatos;

update contatos set
fone = '4799900099900',
nome = 'Mariana'
where id = 1;

select * from locais;

update locais set
nome = 'Restaurante',
rua = 'Dom Pedro II'
where id = 1;

update locais set
nome = 'Hotel',
rua = 'Dom Trusy'
where id = 2;


select * from compromissos;

select compromissos.id, descricao, data, hora, nome
from compromissos, contatos
where compromissos.id = contatos.id;

/*Usando o 'as'*/

select cmproms.id, descricao as Descrição, data, hora, nome as Contato
from compromissos cmproms, contatos cont
where cmproms.id = cont.id;

/*Usando o inner join*/

select cmproms.id, descricao as Descrição, data, hora, nome as Contato
from compromissos cmproms
inner join contatos ct on cmproms.id = ct.id
where cmproms.id = 1