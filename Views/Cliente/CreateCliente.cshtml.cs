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
            return Page(); // Retorna a p�gina para o m�todo GET
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Retorna a p�gina se o modelo n�o for v�lido
            }

            var novoCliente = new Cliente
            {
                Nome = ClienteModel.Nome, // Acessa as propriedades do modelo renomeado
                Email = ClienteModel.Email,
                Telefone = ClienteModel.Telefone,
                Endereco = ClienteModel.Endereco
            };

            _context.Clientes.Add(novoCliente);
            await _context.SaveChangesAsync(); // Salva as altera��es no banco de dados

            return RedirectToPage("./Index"); // Redireciona para a p�gina de �ndice ap�s a cria��o
        }
    }
}