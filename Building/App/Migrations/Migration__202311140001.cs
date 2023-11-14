using FluentMigrator;

namespace Building.App.Migrations;


[Migration(202311140001)]
public class Migration__202311140001 : Migration
{
    /// <summary> Create empty database </summary>
    public override void Up()
    {
        string sql001_CreateEmptyDB = """
            USE [master]
            GO

            IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'Neutrino_Building')
            begin
            	alter database [Neutrino_Building] set single_user with rollback immediate
            	DROP DATABASE IF EXISTS [Neutrino_Building];
            end

            CREATE DATABASE [Neutrino_Building]
                CONTAINMENT = NONE
                ON  PRIMARY 
            ( NAME = N'Neutrino_Building__DATA', FILENAME = N'C:\_ DB\Neutrino\Neutrino_Building__Data.mdf' , SIZE = 131072KB , FILEGROWTH = 131072KB )
                LOG ON 
            ( NAME = N'Neutrino_Building__LOG', FILENAME = N'C:\_ DB\Neutrino\Neutrino_Building__LOG.ldf' , SIZE = 131072KB , FILEGROWTH = 131072KB )

            ALTER DATABASE [Neutrino_Building] SET COMPATIBILITY_LEVEL = 150
            ALTER DATABASE [Neutrino_Building] SET ANSI_NULL_DEFAULT OFF 
            ALTER DATABASE [Neutrino_Building] SET ANSI_NULLS OFF 
            ALTER DATABASE [Neutrino_Building] SET ANSI_PADDING OFF 
            ALTER DATABASE [Neutrino_Building] SET ANSI_WARNINGS OFF 
            ALTER DATABASE [Neutrino_Building] SET ARITHABORT OFF 
            ALTER DATABASE [Neutrino_Building] SET AUTO_CLOSE OFF 
            ALTER DATABASE [Neutrino_Building] SET AUTO_SHRINK OFF 
            ALTER DATABASE [Neutrino_Building] SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF)
            ALTER DATABASE [Neutrino_Building] SET AUTO_UPDATE_STATISTICS ON 
            ALTER DATABASE [Neutrino_Building] SET CURSOR_CLOSE_ON_COMMIT OFF 
            ALTER DATABASE [Neutrino_Building] SET CURSOR_DEFAULT  GLOBAL 
            ALTER DATABASE [Neutrino_Building] SET CONCAT_NULL_YIELDS_NULL OFF 
            ALTER DATABASE [Neutrino_Building] SET NUMERIC_ROUNDABORT OFF 
            ALTER DATABASE [Neutrino_Building] SET QUOTED_IDENTIFIER OFF 
            ALTER DATABASE [Neutrino_Building] SET RECURSIVE_TRIGGERS OFF 
            ALTER DATABASE [Neutrino_Building] SET DISABLE_BROKER 
            ALTER DATABASE [Neutrino_Building] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
            ALTER DATABASE [Neutrino_Building] SET DATE_CORRELATION_OPTIMIZATION OFF 
            ALTER DATABASE [Neutrino_Building] SET PARAMETERIZATION SIMPLE 
            ALTER DATABASE [Neutrino_Building] SET READ_COMMITTED_SNAPSHOT OFF 
            ALTER DATABASE [Neutrino_Building] SET READ_WRITE 
            ALTER DATABASE [Neutrino_Building] SET RECOVERY FULL 
            ALTER DATABASE [Neutrino_Building] SET MULTI_USER 
            ALTER DATABASE [Neutrino_Building] SET PAGE_VERIFY CHECKSUM  
            ALTER DATABASE [Neutrino_Building] SET TARGET_RECOVERY_TIME = 60 SECONDS 
            ALTER DATABASE [Neutrino_Building] SET DELAYED_DURABILITY = DISABLED 
            GO

            USE [Neutrino_Building]
            GO

            ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = Off;
            ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = Primary;
            ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
            ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
            ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = On;
            ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = Primary;
            ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = Off;
            ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = Primary;
            GO

            USE [Neutrino_Building]
            GO

            IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [Neutrino_Building] MODIFY FILEGROUP [PRIMARY] DEFAULT
            GO
            """;

        Execute.Sql(sql001_CreateEmptyDB);
    }

    /// <summary> Remove database </summary>
    public override void Down()
    {
        string db001_DropDatabase = """
            USE [master]
            GO

            IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'Neutrino_Building')
            begin
            	alter database [Neutrino_Building] set single_user with rollback immediate
            	DROP DATABASE IF EXISTS [Neutrino_Building];
            end
            """;
        Execute.Sql(db001_DropDatabase);
    }
}
