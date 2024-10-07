use ttadb;

drop table ActivatorMenuMaster

create table ActivatorMenuMaster(
	MenuId int primary key,
	MenuName varchar(100) not null,
	ParentId int not null,
	MenuApiUrl varchar(100),
);

insert into ActivatorMenuMaster 
values	(1,'New Requests',0,'NewRequests'),
		(2,'Premium Services',0,'PremiumServices'),
		(3,'Delete',0,'Delete'),
		(4,'Reports',0,'Reports'),
		(5,'Manage Account Details',0,'ManageAccountDetails'),
		(6,'Login Page Text',0,'LoginPageText'),
		(7,'Account Summary',4,'Reports/AccountSummary'),
		(8,'Login Details',4,'Reports/LoginDetails'),
		(9,'Special Case Participants List',4,'Reports/SpecialCaseParticipantsList'),
		(10,'Distribution Details',4,'Reports/DistributionDetails'),
		(11,'Client List',4,'Reports/ClientList'),
		(12,'Time Zone Details',4,'Reports/TimeZoneDetails'),
		(13,'Get Survey Details',5,'ManageAccountDetails/GetSurveyDetails'),
		(14,'Edit Splash Screen',5,'ManageAccountDetails/EditSplashScreen'),
		(15,'Edit Release Banner Text',5,'ManageAccountDetails/EditReleaseBannerText'),
		(16,'Unlock Account',5,'ManageAccountDetails/UnlockAccount'),
		(17,'Empty Recycle Bin',5,'ManageAccountDetails/EmptyRecycleBin'),
		(18,'Publish Custom Report',5,'ManageAccountDetails/PublishCustomReport'),
		(19,'Domain Level Opt-out',5,'ManageAccountDetails/DomainLevelOptout'),
		(20,'LDAP Accounts',5,'ManageAccountDetails/LDAPAccounts'),
		(21,'LT Settings',5,'ManageAccountDetails/LTSettings'),
		(22,'Phishing Control',5,'ManageAccountDetails/PhishingControl'),
		(23,'LT Department + User Management',21,'LTSettings/LTDepartmentUserManagement'),
		(24,'LT Intital Setup',21,'LTSettings/LTIntitalSetup'),
		(25,'Activity Directory Setup',21,'LTSettings/ActivityDirectorySetup'),
		(26,'Go To Engage',21,'LTSettings/GoToEngage');



select * from ActivatorMenuMaster
