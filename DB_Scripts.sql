USE [master]

DROP DATABASE IF EXISTS [AdventureWorks2022];

-- Replace value of DISK to exact location of your file "AdventureWorks2022.bak"
RESTORE DATABASE [AdventureWorks2022] FROM  DISK = N'D:\.Projects\.2023\Neutrino_Building\AdventureWorks2022.bak' WITH  FILE = 1,  NOUNLOAD,  STATS = 5

GO

USE [AdventureWorks2022]
go
create schema Building
go

-- Zorin Mykhailo

create table [Building].[SupportTicket]
(
	Id int primary key,
	Actuality int,
	State int,
	Title nvarchar(250),
	AuthorEmail nvarchar(250),
	Text nvarchar(max),
)
go

insert into [Building].[SupportTicket] (Id, Title, Actuality, AuthorEmail, Text, State)
values
(1, N'�� ������ �����', 1, N'v.pupkin@mail.com', N'��������� ��������� �����. ������� ...', 0),
(2, N'��� ������ �������� MyApp', 1, N'm.romaskina@mail.com', N'̳� ������� �������� ��������� � ��''���� �� ...', 1),
(3, N'�� �������� ������ API', 0, N'r.ivanov@mail.com', N'̳� ������� �������� ��������� � ��''���� �� ������ � ������ API, �� ����...', 2)

Select * from [Building].[SupportTicket]

--
create table [Building].[Company]
(
  Id int primary key, 
  NameOfCompany nvarchar(50),
  Description nvarchar(250),
  Owner nvarchar(250),
)
go

insert into [Building].[Company] (Id, NameOfCompany, Description, Owner)
values
(1, 'OBID', 'We are grate small company :3', 'George'),
(2, 'ASD', 'Ass seak Destroyers', 'Obama'),
(3, 'Aler dance', 'Papaute ute ute', 'Bold guy')
-- Moroz Hordii