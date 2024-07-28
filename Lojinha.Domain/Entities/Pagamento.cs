namespace Lojinha.Domain.Entities
{
    public class Pagamento : Entity
    {
        public DateTime DataPagamento { get; set; }
        public decimal ValorTotal { get; set; }
        public int QuantidadeParcelas { get; set; }
        public decimal ValorParcelas { get; set; }
        public string Status { get; set; }

        // Propriedades de Navegação
        public int CartaoId { get; set; }
        public virtual Cartao Cartao { get; set; }

        // Propriedades de Navegação
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}