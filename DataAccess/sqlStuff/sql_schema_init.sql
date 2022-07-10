

create schema db_ExpenseReimbursement;

drop table db_ExpenseReimbursement.users;
drop table db_ExpenseReimbursement.tickets;

create table db_ExpenseReimbursement.users(
	ID int identity,
	Username varchar(50) unique not null,
	Password varchar(50) not null,
	User_Role varchar(50) not null,
	primary key(Username)
);


create table db_ExpenseReimbursement.tickets(
	ID int identity,
	Author varchar(50) foreign key references db_ExpenseReimbursement.users(username),
	Resolver varchar(50) foreign key references db_ExpenseReimbursement.users(username),
	Description varchar(256),
	Status varchar(8) not null,
	Amount decimal(38) not null,
	primary key(ID)
);

insert into db_ExpenseReimbursement.users (username,password,User_Role) values ('merple','passw3rd','Employee');
insert into db_ExpenseReimbursement.users (username,password,User_Role) values ('WillFar','passw3rd','Manager');