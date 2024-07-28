namespace Lojinha.Domain.Entities
{
    public class Produto : Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public string CodigoBarras { get; set; }
        public int QuantidadeEstoque { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public string Status { get; set; }

        // Propriedades de Navegação
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual List<Item> ListaItem { get; set; }
    }
}