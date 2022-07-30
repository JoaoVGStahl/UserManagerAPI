using System.ComponentModel.DataAnnotations;

namespace AuthApi
{
    public class AdicionarUsuarioDTO
    {
        [Required(ErrorMessage ="Nome não pode ser vazio!")]
        [MaxLength(64, ErrorMessage ="Nome pode ter no máximo 64 caracteres!")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Email não pode ser vazio!")]
        [MaxLength (64, ErrorMessage ="Email pode ter no máximo 100 caracteres!")]
        public string Email { get; set; }
        [Required (ErrorMessage ="Senha não pode ser vazio!")]
        [MaxLength(32, ErrorMessage ="Senha pode ter no máximo 32 caracteres!")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Confirmar Senha não pode ser vazio!")]
        public string ConfirmarSenha { get; set; }
    }
}
