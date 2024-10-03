
drop table ButtonBasedOnUserRole;
drop table ButtonTable;

create table ButtonBasedOnUserRole(
	userRole varchar(20),
	navButton varchar(30),
);
INSERT INTO ButtonBasedOnUserRole (userRole, navButton)

VALUES 

    ('admin', 'New Requests'),

    ('admin', 'Premium Services'),

    ('admin', 'Delete'),

    ('admin', 'Reports'),

    ('admin', 'Manage Account Details'),

    ('admin', 'Login Page Text');
 


create table ButtonTable(
	menuType varchar(50),
	isSetting int,
	ButtonName varchar(60),
);

insert into ButtonTable
values	('Reports',0,'Account Summary'),
		('Reports',0,'Login Details'),
		('Reports',0,'Special Case Participants List'),
		('Reports',0,'Distribution Details'),
		('Reports',0,'Client List'),
		('Reports',0,'Time Zone Details');
		
insert into ButtonTable
values	('Manage Account Details',0,'Get Survey Details'),
		('Manage Account Details',0,'Edit Splash Screen'),
		('Manage Account Details',0,'Edit Release Banner Text'),
		('Manage Account Details',0,'Unlock Account'),
		('Manage Account Details',0,'Empty Recycle Bin'),
		('Manage Account Details',0,'Publish Custom Report'),
		('Manage Account Details',0,'Domain Level Opt-out'),
		('Manage Account Details',0,'LDAP Accounts'),
		('Manage Account Details',1,'LT Settings'),
		('Manage Account Details',0,'Phishing Control');

insert into ButtonTable
values	('Manage Account Details',2,'LT Department + User Management'),
		('Manage Account Details',2,'LT Intital Setup'),
		('Manage Account Details',2,'Activity Directory Setup'),
		('Manage Account Details',3,'Go To Engage');


select * from ButtonBasedOnUserRole;
select * from ButtonTable

select * from LoginHistoryAuthenticator
