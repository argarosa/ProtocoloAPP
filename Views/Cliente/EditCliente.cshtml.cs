using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProtocoloApp.Views.Cliente
{
    public class EditClienteModel : PageModel
    {
        [Required(ErrorMessage = "O ID do cliente � obrigat�rio.")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "O nome � obrigat�rio.")]
        [StringLength(100, ErrorMessage = "O nome n�o pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email � obrigat�rio.")]
        [EmailAddress(ErrorMessage = "O email n�o � v�lido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone � obrigat�rio.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O endere�o � obrigat�rio.")]
        public string Endereco { get; set; }
        public void OnGet()
        {
        }
    }
}
