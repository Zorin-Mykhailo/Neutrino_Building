using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeutrinoApp.Migrations;

[Migration(202311160005, "Create procedure Zorin.SupportTicket_GetById")]
public class Migration_202311160005 : Migration
{
    public override void Up()
    {
        string sql = """
            drop procedure if exists Zorin.SupportTicket_GetById
            go

            create procedure Zorin.SupportTicket_GetById
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
            """;
        Execute.Sql(sql);
    }


    public override void Down()
    {
        string sql = """
            drop procedure if exists Zorin.SupportTicket_GetById
            """;
        Execute.Sql(sql);
    }
}
