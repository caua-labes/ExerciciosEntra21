create schema produto;

drop user abcedario@localhost;
create user caua@localhost;

grant proxy
on root to caua@localhost;

alter user caua@localhost identified by 'cabrazoera29';

create user testeRemove@localhost;
grant proxy on root to testeRemove@localhost;

select * from mysql.user;

revoke proxy
on root
from testeRemove@localhost;

drop user testeRemove@localhost;

grant proxy
on root to caua@localhost;

create user operador identified by '123';

drop user operador;

create table produto (
id int not null auto_increment primary key,
produto varchar(50) not null,
valor decimal(5.2) not null,
estoque int not null
);

create user operador@localhost identified by '123';

grant insert,alter,select on produto to operador@localhost;
