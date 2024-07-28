using System.ComponentModel.DataAnnotations;

namespace Lojinha.Application.DTO
{
    public class CadastroDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string SenhaTxt { get; set; }

    }

    public class LoginDTO
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}