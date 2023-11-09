DROP DATABASE IF EXISTS [Neutrino_Building];

CREATE DATABASE [Neutrino_Building]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Neutrino_Building', FILENAME = N'C:\_DB\Data\Neutrino_Building.mdf' , SIZE = 131072KB , FILEGROWTH = 131072KB )
 LOG ON 
( NAME = N'Neutrino_Building_log', FILENAME = N'C:\_DB\Data\Neutrino_Building_log.ldf' , SIZE = 131072KB , FILEGROWTH = 131072KB )
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

-- Zorin Mykhailo ----------------------------------------------------------------------------------------------

USE [Neutrino_Building]
go
create schema Zorin
go



create table [Zorin].[SupportTicket]
(
	Id int primary key,
	Actuality int,
	State int,
	Title nvarchar(250),
	AuthorEmail nvarchar(250),
	Text nvarchar(max),
)
go

insert into [Zorin].[SupportTicket] (Id, Title, Actuality, AuthorEmail, Text, State)
values
(1, N'�� ������ �����', 1, N'v.pupkin@mail.com', N'��������� ��������� �����. ������� ...', 0),
(2, N'��� ������ �������� MyApp', 1, N'm.romaskina@mail.com', N'̳� ������� �������� ��������� � ��''���� �� ...', 1),
(3, N'�� �������� ������ API', 0, N'r.ivanov@mail.com', N'̳� ������� �������� ��������� � ��''���� �� ������ � ������ API, �� ����...', 2)

Select * from [Zorin].[SupportTicket]

create table [Zorin].[MasterTypes]
(
	Id int primary key,
	MasterTypeName nvarchar(50)
)
create table [Zorin].[Masters]
(
	Id int primary key,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Email nvarchar(50),
	PhoneNumber int,
	MasterTypeId int foreign key references [Zorin].[MasterTypes] 
)


insert into [Zorin].[MasterTypes] values
(1, 'Plumber'),
(2, 'Electrician'),
(3, 'Repairer'),
(4, 'Foreman'),
(5, 'Gardener'),
(6, 'Cleaner'),
(7, 'PoolMaster'),
(8, 'General')

insert into [Zorin].[Masters] (Id, FirstName, lastName, Email, PhoneNumber, MasterTypeId) values 
(1, 'Nataliia', 'Pyslar', 'popelyshkon25@gmail.com', '0999999999', 5)


create table [Zorin].[PricesType]
(
Id int primary key,
PriceTypeName nvarchar(20)
)



create table [Zorin].[Prices]
(
Id int primary key,
Name nvarchar(20),
ItemPrice Decimal,
AvailableDate Date,
PricesTypeId int foreign key references [Zorin].[PricesType]
)

alter table [Zorin].[PricetType] alter column [PriceTypeName] nvarchar(50)

insert into [Zorin].[PricesType] values 
(1, 'Service'),
(2, 'Material'),
(3, 'Instrument')

alter table [Zorin].[Prices] alter column [Name] nvarchar(50)

insert into [Zorin].[Prices] (Id, Name, ItemPrice, AvailableDate, PricesTypeId) values
(1, 'Cement bag', 168.25, '2023-10-18',2),  
(2, 'Plaster bag', 126.0, '2023-10-18',2),
(3, 'Putty bag', 450.0, '2023-10-18',2),
(4, 'Laser level', 2250.0, '2023-10-18',3),
(5, 'Jack hammer', 3100.0, '2023-10-18',3),
(6, 'Pack of screwdrivers', 899.0, '2023-10-18',3),
(7, 'Roof fix', 880.0, '2023-10-18',1),
(8, 'Auto delivery', 1100.0, '2023-10-18',1),
(9, 'Electrician consultation', 500.0, '2023-10-18',1)