namespace Lojinha.Domain.Entities
{
    public class Pedido : Entity
    {
        public DateTime DataPedido { get; set; }

        public virtual List<Item> ListaItem { get; set; }
        public virtual List<HistoricoPedido> ListaHistoricoPedido { get; set; }

        // Propriedades de Navegação
        public int PagamentoId { get; set; }
        public virtual Pagamento Pagamento { get; set; }
    }
}