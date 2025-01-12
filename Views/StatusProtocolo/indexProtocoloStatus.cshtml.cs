using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Data;
using ProtocoloApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProtocoloManager.Controllers
{
    public class IndexStatusProtocoloController : Controller
    {
        private readonly ProtocoloContext _context;

        public IndexStatusProtocoloController(ProtocoloContext context)
        {
            _context = context;
        }

        // GET: StatusProtocolo
        public async Task<IActionResult> Index()
        {
            var statusProtocolos = await _context.StatusProtocolos.ToListAsync();
            return View(statusProtocolos);
        }
    }
}