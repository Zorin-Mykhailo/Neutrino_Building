using System.ComponentModel.DataAnnotations.Schema;

namespace Neutrino.Data;


[Table("Zorin.SupportTicket")]
public class SupportTicket
{
    public int Id { get; set; }

    public string Title { get; set; }

    public Actuality Actuality { get; set; }

    public string AuthorEmail { get; set; }

    public string Text { get; set; }

    public SupportTicketState State { get; set; }

    public override string ToString()
    {
        return $" {Id,5} | {Title, 20} | {Actuality,10} | {AuthorEmail,15} | {State,10} | {Text}";
    }
}