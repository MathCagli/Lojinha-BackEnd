using Lojinha.Domain.Enumeradores;

namespace Lojinha.Domain.Entities
{
    public class DadoBancario : Entity
    {
        public int Id { get; set; }
        public string CodigoBanco { get; set; }
        public string NumeroAgencia { get; set; }
        public string DigitoAgencia { get; set; }
        public string NumeroConta { get; set; }
        public string DigitoConta { get; set; }
        public string ChavePix { get; set; }
        public string TipoConta { get; set; }

        // Propriedades de Navegação
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}