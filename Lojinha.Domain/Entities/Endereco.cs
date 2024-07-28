namespace Lojinha.Domain.Entities
{
    public class Endereco : Entity
    {
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        // Propriedades de Navegação
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}