create table Mudancas(
	Id int not null auto_increment primary key,
    Usuario int not null,
    Data datetime not null,
    Produto int not null,
	QuantidadeAlt int not null,
    UnidadeMedida varchar(10) not null,
    foreign key (Usuairio) references Usuario(Id),
    foreign key (Produto) references Produto(Id)
);
create table Usuario(
	Id int not null auto_increment primary key,
    Nome varchar(50) not null,
    Email varchar(75) not null,
    Cargo varchar(15) not null
);
create table Produto(
	Id int not null primary key auto_increment,
	Descricao varchar(50) not null,
    valorUnitario decimal(5,2) not null,
    QuantidadeTotal int not null
);
update Produto set UnidadeMedida = ("Kg") where Id = 1;
select * from Produto;
/*alter table Produto
drop column UnidadeMedida;
alter table Produto
add column UnidadeMedida varchar(10) not null;
*/
/*create table itens(
 Id int not null,
 qtde int not null,
 idproduto int,
 foreign key(idproduto) references produto(id)
 )*/

delimiter //
CREATE TRIGGER atualiza_estoque
AFTER INSERT ON itens
FOR EACH ROW
BEGIN
    update produto set quantidadeTotal = quantidadeTotal - new.qtde
    where id = new.idproduto;
END //
delimiter ;
drop trigger  verifica_estoque
delimiter //
CREATE TRIGGER verifica_estoque
BEFORE INSERT ON itens
FOR EACH ROW
BEGIN
   Declare qtde_atual decimal(6,2);
   select QuantidadeTotal into qtde_atual 
   from produto 
   where id = new.idproduto; 
   
   if qtde_atual < new.qtde then
      SIGNAL SQLSTATE '45000'
      SET MESSAGE_TEXT = 'Estoque insuficinte';
   end if;
      
END //
delimiter ;

show triggers;