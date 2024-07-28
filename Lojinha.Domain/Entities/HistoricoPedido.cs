namespace Lojinha.Domain.Entities
{
    public class HistoricoPedido : Entity
    {
        public DateTime DataEvento { get; set; }
        public string DescricaoEvento { get; set; }
        public string DetalhesEvento { get; set; }

        // Propriedades de Navegação
        public virtual Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
    }
}
