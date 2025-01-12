using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Data;
using ProtocoloApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProtocoloApp.Controllers
{
    public class IndexProtocoloFollowController : Controller
    {
        private readonly ProtocoloContext _context;

        public IndexProtocoloFollowController(ProtocoloContext context)
        {
            _context = context;
        }

        // GET: ProtocoloFollow
        public async Task<IActionResult> Index()
        {
            var protocoloFollows = await _context.ProtocoloFollows
                .Include(p => p.Protocolo) // Inclui os dados do protocolo
                .ToListAsync();
            return View(protocoloFollows);
        }
    }
}