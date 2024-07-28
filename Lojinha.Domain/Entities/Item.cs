namespace Lojinha.Domain.Entities
{
    public class Item : Entity
    {
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }

        // Propriedades de Navegação
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

        // Propriedades de Navegação
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        // Propriedades de Navegação
        public int CarrinhoId { get; set; }
        public virtual Carrinho Carrinho { get; set; }
    }
}