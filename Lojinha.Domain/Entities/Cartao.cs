namespace Lojinha.Domain.Entities
{
    public class Cartao : Entity
    {
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Codigo { get; set; }
        public int MesVencimento { get; set; }
        public int AnoVencimento { get; set; }

        // Propriedades de Navegação
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}