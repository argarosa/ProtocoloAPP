using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Data;
using ProtocoloApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProtocoloApp.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly ProtocoloContext _context;

        public IndexModel(ProtocoloContext context)
        {
            _context = context;
        }

        public IList<Cliente> Clientes { get; set; } // Lista de clientes a ser exibida na View

        public async Task OnGetAsync()
        {
            Clientes = await _context.Clientes.ToListAsync(); // Busca todos os clientes do banco de dados
        }
    }
}