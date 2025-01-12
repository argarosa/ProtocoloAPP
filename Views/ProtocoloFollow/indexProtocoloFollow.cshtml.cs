using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Data;
using ProtocoloApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProtocoloApp.Controllers
{
    public class IndexProtocoloController : Controller
    {
        private readonly ProtocoloContext _context;

        public IndexProtocoloController(ProtocoloContext context)
        {
            _context = context;
        }

        // GET: Protocolo
        public async Task<IActionResult> Index()
        {
            var protocolos = await _context.Protocolos
                .Include(p => p.Cliente) // Inclui os dados do cliente
                .Include(p => p.StatusProtocolo) // Inclui os dados do status do protocolo
                .ToListAsync();

            return View(protocolos);
        }
    }
}