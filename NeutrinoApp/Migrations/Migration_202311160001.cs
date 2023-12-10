using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeutrinoApp.Migrations;

[Migration(202311160001, "Create schema [Zorin]")]
public class Migration_202311160001 : Migration
{
    public override void Up()
    {
        string sql = """
            drop schema if exists Zorin;
            go

            create schema Zorin
            go
            """;
        Execute.Sql(sql);
    }


    public override void Down()
    {
        string sql = """
            drop schema if exists Zorin
            """;
        Execute.Sql(sql);
    }
}
