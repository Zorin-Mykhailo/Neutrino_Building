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

execute Zorin.GetAllItems_SupportTicket

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
(1, 'Nataliia', 'Pyslar', 'popelyshkon25@gmail.com', '0999999999', 5)





-- █████ 👤 Pavlo Eksarov ████████████████████████████████████████████████████████████████████████████████████████████

USE [Neutrino_Building]
go
create schema Eksarov
go

create table [Eksarov].[PricesType]
(
Id int primary key,
PriceTypeName nvarchar(50)
)
go

create table [Eksarov].[Prices]
(
Id int primary key,
Name nvarchar(50),
ItemPrice Decimal,
AvailableDate Date,
PricesTypeId int foreign key references [Eksarov].[PricesType]
)
go

insert into [Eksarov].[PricesType] values 
(1, 'Service'),
(2, 'Material'),
(3, 'Instrument')
go


create procedure Eksarov.Create_Price
	@id int,
	@name nvarchar(50),
	@itemprice decimal,
	@availabledate Date,
	@pricestypeid int
as
	insert into [Eksarov].[Prices] (Id, Name, ItemPrice, AvailableDate, PricesTypeId)
	values
	(@id, @name, @itemprice, @availabledate, @pricestypeid)
go

create procedure Eksarov.Prices_FilterByType
	@pricestypeid int
as
	select
		Id
		, Name
		, ItemPrice
		, AvailableDate
		, PricesTypeId
	from [Eksarov].[Prices]
	where PricesTypeId = @pricestypeid
	order by Id
go

create procedure Eksarov.GetById_Prices
	@id int
as
	select
		Id
		, Name
		, ItemPrice
		, AvailableDate
		, PricesTypeId
	from [Eksarov].[Prices]
	where id = @id
go

create procedure Eksarov.ExtendedPrices_FilterByPriceKind
    @id int
as
	select
		_prices.Id as price_id
		, _prices.Name as item_name
		, _prices.ItemPrice as item_price
		, _prices.AvailableDate as item_available_date
		, _prices.PricesTypeId as prices_kind_id
		, _pricesType.PriceTypeName as prices_kind_name
	from [Eksarov].[Prices] as _prices join [Eksarov].[PricesType] as _pricesType on _pricesType.Id = _prices.PricesTypeId
	where _prices.PricesTypeId = @id 
go

create procedure Eksarov.UpdateById_Prices
	@id int,
	@name nvarchar(50),
	@itemprice decimal,
	@availabledate Date,
	@pricestypeid int
as
	update [Eksarov].[Prices]
	set Name = @name, ItemPrice = @itemprice, AvailableDate = @availabledate, PricesTypeId = @pricestypeid
	where id = @id
go

create procedure Eksarov.DeleteById_Prices
	@id int
as
	delete from [Eksarov].[Prices]
	where id = @id
go

create nonclustered index IX_Prices_Id 
       on [Eksarov].[Prices] (Id)

execute Eksarov.Create_Price
	@id = 1,
	@name = N'Cement bag', 
	@itemprice = 168.25, 
	@availabledate = '2023-10-18', 
	@pricestypeid = 2

execute Eksarov.Create_Price
	@id = 2,
	@name = N'Plaster bag', 
	@itemprice = 126.0, 
	@availabledate = '2023-10-18', 
	@pricestypeid = 2

execute Eksarov.Create_Price
	@id = 3,
	@name = N'Laser level', 
	@itemprice = 2250.0, 
	@availabledate = '2023-10-18', 
	@pricestypeid = 3

execute Eksarov.Create_Price
	@id = 4,
	@name = N'Auto delivery', 
	@itemprice = 1100.0, 
	@availabledate = '2023-10-18', 
	@pricestypeid = 1

execute Eksarov.Prices_FilterByType @pricestypeid = 2

execute Eksarov.ExtendedPrices_FilterByPriceKind @id = 2

execute Eksarov.GetById_Prices @id = 2

execute Eksarov.UpdateById_Prices
	@id = 4,
	@name = N'Auto delivery (for 1 ton)', 
	@itemprice = 1200.0, 
	@availabledate = '2023-10-20', 
	@pricestypeid = 1

execute Eksarov.DeleteById_Prices @id = 2
