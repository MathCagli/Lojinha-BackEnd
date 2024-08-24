namespace Lojinha.Domain.Entities;

public class Log : Entity
{
    public string? Evento { get; set; }
    public string? Tipo { get; set; }
    public int? Usuario { get; set; }
}
