using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeutrinoApp.Migrations;

[Migration(202311160007, "Create procedure Zorin.SupportTicket_Delete")]
public class Migration_202311160007 : Migration
{
    public override void Up()
    {
        string sql = """
            drop procedure if exists Zorin.SupportTicket_Delete
            go

            create procedure Zorin.SupportTicket_Delete
            	@id int
            as
            	delete from [Zorin].[SupportTicket]
            	where id = @id
            go
            """;
        Execute.Sql(sql);        
    }


    public override void Down()
    {
        string sql = """
            drop procedure if exists Zorin.SupportTicket_Delete
            """;
        Execute.Sql(sql);
    }
}
