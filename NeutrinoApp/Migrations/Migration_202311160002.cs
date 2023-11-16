using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeutrinoApp.Migrations;

[Migration(202311160002, "Create table [Zorin].[SupportTicket]")]
public class Migration_202311160002 : Migration
{
    public override void Up()
    {
        string sql = """
            drop table if exists [Zorin].[SupportTicket];
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
            """;
        Execute.Sql(sql);
    }


    public override void Down()
    {
        string sql = """
            drop table if exists [Zorin].[SupportTicket];
            """;
        Execute.Sql(sql);
    }
}
