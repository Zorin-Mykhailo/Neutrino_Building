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

-- Other team members

-- insert your code here