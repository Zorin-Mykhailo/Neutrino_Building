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
(1, N'Не працює мишка', 1, N'v.pupkin@mail.com', N'Перестала працювати мишка. Можливо ...', 0),
(2, N'Збій роботи програми MyApp', 1, N'm.romaskina@mail.com', N'Мій додаток перестав працювати в зв''язку із ...', 1),
(3, N'Не коректна робота API', 0, N'r.ivanov@mail.com', N'Мій додаток перестав працювати в зв''язку із змінами у вашому API, що були...', 2)

Select * from [Zorin].[SupportTicket]

-- insert your tables here -----------------------------------------------------------------------------------