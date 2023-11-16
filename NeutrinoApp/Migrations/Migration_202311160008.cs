using FluentMigrator;
using Microsoft.Data.SqlClient;
using Neutrino.Data;
using Z.Dapper.Plus;

namespace NeutrinoApp.Migrations;

[Migration(202311160008, "Insert data into SupportTicket")]
public class Migration_202311160008 : Migration
{
    public override void Up()
    {
        using SqlConnection connection = new (ConnectionString);
        _ = connection.BulkInsert(DbItems());
    }


    public override void Down()
    {
        using SqlConnection connection = new (ConnectionString);
        _ = connection.BulkDelete<SupportTicket>(DbItems());
    }

    
    private List<SupportTicket> DbItems()
    {
        List<SupportTicket> tickets = new()
        {
            new ()
            {
                Id = 1,
                Title = "Не працює мишка",
                Actuality = Actuality.Actual,
                AuthorEmail = "v.pupkin@mail.com",
                Text = "Перестала працювати мишка. Можливо ...",
                State = SupportTicketState.New
            },
            new ()
            {
                Id = 2,
                Title = "Збій роботи програми MyAp",
                Actuality = Actuality.Actual,
                AuthorEmail = "m.romaskina@mail.co",
                Text = "Мій додаток перестав працювати в зв''язку із ...",
                State = SupportTicketState.InProgres
            },
            new ()
            {
                Id = 3,
                Title = "Не коректна робота API",
                Actuality = Actuality.Obsolete,
                AuthorEmail = "r.ivanov@mail.com",
                Text = "Мій додаток перестав працювати в зв''язку із змінами у вашому API, що були...",
                State = SupportTicketState.Finished
            }
        };
        return tickets;
    }
}
