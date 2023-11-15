USE [master]
GO

alter database [Neutrino_Building] set single_user with rollback immediate
DROP DATABASE IF EXISTS [Neutrino_Building];

CREATE DATABASE [Neutrino_Building]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Neutrino_Building__DATA', FILENAME = N'C:\_DB\Neutrino\Neutrino_Building__Data.mdf' , SIZE = 131072KB , FILEGROWTH = 131072KB )
 LOG ON 
( NAME = N'Neutrino_Building__LOG', FILENAME = N'C:\_DB\Neutrino\Neutrino_Building_LOG.ldf' , SIZE = 131072KB , FILEGROWTH = 131072KB )
GO
ALTER DATABASE [Neutrino_Building] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [Neutrino_Building] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Neutrino_Building] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Neutrino_Building] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Neutrino_Building] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Neutrino_Building] SET ARITHABORT OFF 
GO
ALTER DATABASE [Neutrino_Building] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Neutrino_Building] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Neutrino_Building] SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF)
GO
ALTER DATABASE [Neutrino_Building] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Neutrino_Building] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Neutrino_Building] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Neutrino_Building] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Neutrino_Building] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Neutrino_Building] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Neutrino_Building] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Neutrino_Building] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Neutrino_Building] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Neutrino_Building] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Neutrino_Building] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Neutrino_Building] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Neutrino_Building] SET  READ_WRITE 
GO
ALTER DATABASE [Neutrino_Building] SET RECOVERY FULL 
GO
ALTER DATABASE [Neutrino_Building] SET  MULTI_USER 
GO
ALTER DATABASE [Neutrino_Building] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Neutrino_Building] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Neutrino_Building] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Neutrino_Building]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = Off;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = Primary;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = On;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = Primary;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = Off;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = Primary;
GO


USE [Neutrino_Building]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [Neutrino_Building] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO

-- █████ 👤 Zorin Mykhailo ████████████████████████████████████████████████████████████████████████████████████████████

USE [Neutrino_Building]
go
create schema Zorin
go



create table [Zorin].[SupportTicket]
(
	Id int primary key,
	Title nvarchar(250),
	Actuality int,
	AuthorEmail nvarchar(250),
	Text nvarchar(max),
	State int,
)
go

create procedure Zorin.Create_SupportTicket
	@id int,
	@title nvarchar(250),
	@actuality int,
	@authorEmail nvarchar(250),
	@text nvarchar(max),
	@state int
as
	insert into [Zorin].[SupportTicket] (Id, Title, Actuality, AuthorEmail, Text, State)
	values
	(@id, @title, @actuality, @authorEmail, @text, @state)
go

create procedure Zorin.GetAllItems_SupportTicket
as
	select
		Id
		, Title
		, Actuality
		, AuthorEmail
		, Text
		, State
	from [Zorin].[SupportTicket]
go

create procedure Zorin.GetById_SupportTicket
	@id int
as
	select
		Id
		, Title
		, Actuality
		, AuthorEmail
		, Text
		, State
	from [Zorin].[SupportTicket]
	where id = @id
go

create procedure Zorin.UpdateById_SupportTicket
	@id int,
	@title nvarchar(250),
	@actuality int,
	@authorEmail nvarchar(250),
	@text nvarchar(max),
	@state int
as
	update [Zorin].[SupportTicket]
	set Title = @title, Actuality = @actuality, AuthorEmail = @authorEmail, [Text] = @text, [State] = @state
	where id = @id
go

create procedure Zorin.DeleteById_SupportTicket
	@id int
as
	delete from [Zorin].[SupportTicket]
	where id = @id
go

execute Zorin.Create_SupportTicket
	@id = 1,
	@title = N'Не працює мишка', 
	@actuality = 1, 
	@authorEmail = N'v.pupkin@mail.com', 
	@text = N'Перестала працювати мишка. Можливо ...', 
	@state = 0

execute Zorin.Create_SupportTicket
	@id = 2, 
	@title = N'Збій роботи програми MyApp', 
	@actuality = 1, 
	@authorEmail = N'm.romaskina@mail.com', 
	@text = N'Мій додаток перестав працювати в зв''язку із ...', 
	@state = 1

execute Zorin.Create_SupportTicket
	@id = 3, 
	@title = N'Не коректна робота API', 
	@actuality = 0, 
	@authorEmail = N'r.ivanov@mail.com', 
	@text = N'Мій додаток перестав працювати в зв''язку із змінами у вашому API, що були...', 
	@state = 2
  
execute Zorin.UpdateById_SupportTicket
	@id = 1,
	@title = N'Не працює мишка', 
	@actuality = 1, 
	@authorEmail = N'v.pupkin@mail.com', 
	@text = N'Перестала працювати мишка. Можливо забігалась...', 
	@state = 0

execute Zorin.GetById_SupportTicket @id = 1
execute Zorin.DeleteById_SupportTicket @id = 1
execute Zorin.GetAllItems_SupportTicket

-- █████ 👤 Natalia Pyslyar ████████████████████████████████████████████████████████████████████████████████████████████

USE [Neutrino_Building]
go
create schema Pyslyar
go



create table [Pyslyar].[MasterTypes]
(
	Id int primary key,
	MasterTypeName nvarchar(50)
)
create table [Pyslyar].[Masters]
(
	Id int primary key,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Email nvarchar(50),
	PhoneNumber int,
	MasterTypeId int foreign key references [Pyslyar].[MasterTypes] 
)


insert into [Pyslyar].[MasterTypes] values
(1, 'Plumber'),
(2, 'Electrician'),
(3, 'Repairer'),
(4, 'Foreman'),
(5, 'Gardener'),
(6, 'Cleaner'),
(7, 'PoolMaster'),
(8, 'General')

insert into [Pyslyar].[Masters] (Id, FirstName, lastName, Email, PhoneNumber, MasterTypeId) values 
(1, 'Nataliia', 'Pyslar', 'popelyshkon25@gmail.com', '0999999999', 5);
go

create procedure Pyslyar.CreateMaster
	@FirstName nvarchar(40),
	@lastName nvarchar(40),
	@Email nvarchar(40),
	@PhoneNumber nvarchar(40),
	@MasterTypeId int
as
	insert into [Pyslyar].[Masters] (FirstName, lastName, Email, PhoneNumber, MasterTypeId)
	values
	(@FirstName, @lastName, @Email, @PhoneNumber, @MasterTypeId)
go

create procedure Pyslyar.GetAllMasters
as
	select
		Id, FirstName, lastName, Email, PhoneNumber, MasterTypeId
	from [Pyslyar].[Masters]
go

create procedure Pyslyar.GetMasterById
	@id int
as
	select
		Id, FirstName, lastName, Email, PhoneNumber, MasterTypeId
	from [Pyslyar].[Masters]
	where id = @id
go

create procedure Pyslyar.UpdateMasterById
	@id int,
	@FirstName nvarchar(40),
	@lastName nvarchar(40),
	@Email nvarchar(40),
	@PhoneNumber nvarchar(40),
	@MasterTypeId int
as
	update [Pyslyar].[Masters]
	set FirstName = @FirstName, lastName = @lastName, Email = @Email, PhoneNumber = @PhoneNumber, MasterTypeId = @MasterTypeId
	where id = @id
go

create procedure Pyslyar.DeleteMasterById
	@id int
as
	delete from [Pyslyar].[Masters]
	where id = @id
go

execute Pyslyar.CreateMaster
	@FirstName = 'Natalie', 
	@lastName = 'Portman',
	@Email = 'actress@gmail.com',
	@PhoneNumber = '+1359872049',
	@MasterTypeId = 3
  
execute Pyslyar.UpdateMasterById
	@id = 1,
	@FirstName = 'Blair', 
	@lastName = 'Wolderf',
	@Email = 'gossip@gmail.com',
	@PhoneNumber = '+1359879049',
	@MasterTypeId = 2

execute Pyslyar.GetMasterById @id = 1
execute Pyslyar.DeleteMasterById @id = 1
execute Pyslyar.GetAllMasters



-- █████ 👤 Pavlo Eksarov ████████████████████████████████████████████████████████████████████████████████████████████

USE [Neutrino_Building]
go
create schema Eksarov
go

create table [Eksarov].[PricesType]
(
Id int primary key,
PriceTypeName nvarchar(20)
)

create table [Eksarov].[Prices]
(
Id int primary key,
Name nvarchar(20),
ItemPrice Decimal,
AvailableDate Date,
PricesTypeId int foreign key references [Eksarov].[PricesType]
)

alter table [Eksarov].[PricesType] alter column [PriceTypeName] nvarchar(50)

insert into [Eksarov].[PricesType] values 
(1, 'Service'),
(2, 'Material'),
(3, 'Instrument')

alter table [Eksarov].[Prices] alter column [Name] nvarchar(50)

insert into [Eksarov].[Prices] (Id, Name, ItemPrice, AvailableDate, PricesTypeId) values
(1, 'Cement bag', 168.25, '2023-10-18',2),  
(2, 'Plaster bag', 126.0, '2023-10-18',2),
(3, 'Putty bag', 450.0, '2023-10-18',2),
(4, 'Laser level', 2250.0, '2023-10-18',3),
(5, 'Jack hammer', 3100.0, '2023-10-18',3),
(6, 'Pack of screwdrivers', 899.0, '2023-10-18',3),
(7, 'Roof fix', 880.0, '2023-10-18',1),
(8, 'Auto delivery', 1100.0, '2023-10-18',1),
(9, 'Electrician consultation', 500.0, '2023-10-18',1)


-- █████ 👤 Hordii Moroz ████████████████████████████████████████████████████████████████████████████████████████████
USE [Neutrino_Building]
go
create schema Moroz
go

create table [Moroz].[CompanyType]
(
	Id int primary key,
	CType nvarchar(50)
)
create table [Moroz].[Company]
(
	Id int primary key,
	NameOfCompany nvarchar(50),
	Description nvarchar(250),
	Owner nvarchar(250),
	CTypeId int foreign key references [Moroz].[CompanyType]
)
go
create procedure Moroz.Create_Company
	@id int,
	@nameOfCompany nvarchar(50),
	@description nvarchar(250),
	@owner nvarchar(250)
as
	insert into [Moroz].[Company] (Id, NameOfCompany, Description, Owner)
	values
	(@id, @nameOfCompany, @description, @owner)
go

create procedure Moroz.GetAllItems_Company
as
	select
		Id, NameOfCompany, Description, Owner
	from [Moroz].[Company]
go

create procedure Moroz.GetById_Company
	@id int
as
	select
		Id, NameOfCompany, Description, Owner
	from [Moroz].[Company]
	where id = @id
go

create procedure Moroz.UpdateById_Company
	@id int,
	@nameOfCompany nvarchar(50),
	@description nvarchar(250),
	@owner nvarchar(250)
as
	update [Moroz].[Company]
	set NameOfCompany = @nameOfCompany, Description = @description, Owner = @owner
	where id = @id
go

create procedure Moroz.DeleteById_Company
	@id int
as
	delete from [Moroz].[Company]
	where id = @id
go

execute Moroz.Create_Company
	@id = 1,
	@nameOfCompany = 'OBID',
	@description = 'We are grate small company :3',
	@owner = 'George'

execute Moroz.Create_Company
	@id = 2,
	@nameOfCompany = 'ASD',
	@description = 'Ass seak Destroyers',
	@owner = 'Obama'

execute Moroz.Create_Company
	@id = 3,
	@nameOfCompany = 'Aler dance',
	@description = 'Papaute ute ute',
	@owner = 'Bold guy'

execute Moroz.GetAllItems_Company

execute Moroz.UpdateById_Company
	@id = 3,
	@nameOfCompany = 'Aler dance taram pam param pam',
	@description = 'UTEEE Papaute ute ute papa ute',
	@owner = 'Very cool YEAH'

execute Moroz.GetById_Company @id = 1
execute Moroz.DeleteById_Company @id = 2
execute Moroz.GetAllItems_Company
