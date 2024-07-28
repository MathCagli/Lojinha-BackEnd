namespace Lojinha.Domain.Entities
{
    public class Carrinho : Entity
    {
        public DateTime DataCriacao { get; set; }

        public virtual List<Item> ListaItem { get; set; }
    }
}