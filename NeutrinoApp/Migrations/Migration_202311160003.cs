using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeutrinoApp.Migrations;

[Migration(202311160003, "Create procedure Zorin.SupportTicket_Create")]
public class Migration_202311160003 : Migration
{
    public override void Up()
    {
        string sql = """
            drop procedure if exists Zorin.SupportTicket_Create
            go

            create procedure Zorin.SupportTicket_Create
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
            """;
        Execute.Sql(sql);
    }


    public override void Down()
    {
        string sql = """
            drop procedure if exists Zorin.SupportTicket_Create
            """;
        Execute.Sql(sql);
    }
}
