using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Data;
using ProtocoloApp.Models;
using System.Threading.Tasks;

namespace ProtocoloApp.Pages.Clientes
{
    public class DeleteClienteModel : PageModel
    {
        private readonly ProtocoloContext _context;

        public DeleteClienteModel(ProtocoloContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; } // Modelo para o cliente a ser excluído

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente = await _context.Clientes.FindAsync(id); // Busca o cliente pelo ID

            if (Cliente == null)
            {
                return NotFound();
            }

            return Page(); // Retorna a página se o cliente for encontrado
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Cliente == null)
            {
                return NotFound();
            }

            // Busca o cliente no banco de dados
            var clienteToDelete = await _context.Clientes.FindAsync(Cliente.IdCliente);
            if (clienteToDelete != null)
            {
                _context.Clientes.Remove(clienteToDelete); // Remove o cliente
                await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
            }

            return RedirectToPage("./Index"); // Redireciona para a página de índice após a exclusão
        }
    }
}