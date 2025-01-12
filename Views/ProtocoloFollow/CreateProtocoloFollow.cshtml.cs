using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Models;
using ProtocoloApp.Data;
using System.Threading.Tasks;

namespace ProtocoloApp.Controllers
{
    public class ProtocoloFollowController : Controller
    {
        private readonly ProtocoloContext _context;

        public ProtocoloFollowController(ProtocoloContext context)
        {
            _context = context;
        }

        // GET: ProtocoloFollow/Create
        public IActionResult Create()
        {
            // Preencher o ViewBag com os protocolos disponíveis
            ViewBag.Protocolos = new SelectList(_context.Protocolos.ToList(), "IdProtocolo", "Titulo");
            return View();
        }

        // POST: ProtocoloFollow/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProtocoloFollow protocoloFollow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(protocoloFollow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Se o modelo não for válido, recarregue os dados dos protocolos
            ViewBag.Protocolos = new SelectList(await _context.Protocolos.ToListAsync(), "IdProtocolo", "Titulo", protocoloFollow.ProtocoloId);
            return View(protocoloFollow);
        }
    }
}