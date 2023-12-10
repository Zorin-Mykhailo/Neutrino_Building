using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeutrinoApp.Migrations;

[Migration(202311160004, "Create procedure Zorin.SupportTicket_GetAllIds")]
public class Migration_202311160004 : Migration
{
    public override void Up()
    {
        string sql = """
            drop procedure if exists Zorin.SupportTicket_GetAllIds
            go

            create procedure Zorin.SupportTicket_GetAllIds
            as
            	select
                    Id
            	from [Zorin].[SupportTicket]
            go
            """;
        Execute.Sql(sql);
    }


    public override void Down()
    {
        string sql = """
            drop procedure if exists Zorin.SupportTicket_GetAllIds
            """;
        Execute.Sql(sql);
    }
}
