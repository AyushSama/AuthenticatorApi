use ttadb;

create table Activator_Menu_Master(
	MenuId int primary key,
	MenuName varchar(100) not null,
	ParentId int not null,
	MenuApiUrl varchar(100),
);


insert into Activator_Menu_Master 
values	(1,'New Requests',0,''),
		(2,'Premium Services',0,''),
		(3,'Delete',0,''),
		(4,'Reports',0,''),
		(5,'Manage Account Details',0,''),
		(6,'Login Page Text',0,''),
		(7,'Account Summary',4,''),
		(8,'Login Details',4,''),
		(9,'Special case participants list',4,''),
		(10,'Distribution Details',4,''),
		(11,'Client List',4,''),
		(12,'Time Zone Details',4,''),
		(13,'Get Survey Details',5,''),
		(14,'Edit Splash Screen',5,''),
		(15,'Edit Release Banner Text',5,''),
		(16,'Unlock Account',5,''),
		(17,'Empty Recycle Bin',5,''),
		(18,'Publish Custom Report',5,''),
		(19,'Domain level Opt-out',5,''),
		(20,'LDAP Accounts',5,''),
		(21,'LT Settings',5,''),
		(22,'Phishing Control',5,''),
		(23,'LT Department + User Management',21,''),
		(24,'LT Intital Setup',21,''),
		(25,'Activity Directory Setup',21,''),
		(26,'Go To Engage',21,'');


