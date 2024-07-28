namespace Lojinha.Application.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        public string Token { get; set; }
        public DateTime? DataToken { get; set; }
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        public string? Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Status { get; set; }
        public string? TipoUsuario { get; set; }

        //public virtual List<Cartao> ListaCartao { get; set; }
        //public virtual List<DadoBancario> ListaDadoBancario { get; set; }
        //public virtual List<Endereco> ListaEndereco { get; set; }
        //public virtual List<Produto> ListaProduto { get; set; }
    }
}