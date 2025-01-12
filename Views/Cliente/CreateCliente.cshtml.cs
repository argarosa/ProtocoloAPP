using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtocoloApp.Data;
using ProtocoloApp.Models;
using System.Threading.Tasks;

namespace ProtocoloApp.Pages.Clientes
{
    public class CreateClienteModel : PageModel
    {
        private readonly ProtocoloContext _context;

        public CreateClienteModel(ProtocoloContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreateClienteModel ClienteModel { get; set; } // Modelo para o cliente a ser criado
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Endereco { get; private set; }

        public IActionResult OnGet()
        {
            return Page(); // Retorna a página para o método GET
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Retorna a página se o modelo não for válido
            }

            var novoCliente = new Cliente
            {
                Nome = ClienteModel.Nome, // Acessa as propriedades do modelo renomeado
                Email = ClienteModel.Email,
                Telefone = ClienteModel.Telefone,
                Endereco = ClienteModel.Endereco
            };

            _context.Clientes.Add(novoCliente);
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados

            return RedirectToPage("./Index"); // Redireciona para a página de índice após a criação
        }
    }
}