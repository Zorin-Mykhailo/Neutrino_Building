using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeutrinoApp.Migrations;

[Migration(202311160006, "Create procedure Zorin.SupportTicket_Update")]
public class Migration_202311160006 : Migration
{
    public override void Up()
    {
        string sql = """
            drop procedure if exists Zorin.SupportTicket_Update
            go

            create procedure Zorin.SupportTicket_Update
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
            """;
        Execute.Sql(sql);
    }


    public override void Down()
    {
        string sql = """
            drop procedure if exists Zorin.SupportTicket_Update
            """;
        Execute.Sql(sql);
    }
}
