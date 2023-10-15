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
(1, N'Не працює мишка', 1, N'v.pupkin@mail.com', N'Перестала працювати мишка. Можливо ...', 0),
(2, N'Збій роботи програми MyApp', 1, N'm.romaskina@mail.com', N'Мій додаток перестав працювати в зв''язку із ...', 1),
(3, N'Не коректна робота API', 0, N'r.ivanov@mail.com', N'Мій додаток перестав працювати в зв''язку із змінами у вашому API, що були...', 2)

Select * from [Building].[SupportTicket]

-- Other team members

-- insert your code here