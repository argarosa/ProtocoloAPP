using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Models;
using ProtocoloApp.Data;
using System.Threading.Tasks;

namespace ProtocoloManager.Controllers
{
    public class CreateProtocoloController : Controller
    {
        private readonly ProtocoloContext _context;

        public CreateProtocoloController(ProtocoloContext context)
        {
            _context = context;
        }

        // GET: Protocolo/Create
        public IActionResult Create()
        {
            ViewBag.Clientes = new SelectList(_context.Clientes.ToList(), "IdCliente", "Nome");
            ViewBag.StatusProtocolos = new SelectList(_context.StatusProtocolos.ToList(), "IdStatus", "NomeStatus");
            return View();
        }

        // POST: Protocolo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Protocolo protocolo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(protocolo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Se o modelo não for válido, recarregue os dados dos clientes e status
            ViewBag.Clientes = new SelectList(await _context.Clientes.ToListAsync(), "IdCliente", "Nome", protocolo.ClienteId);
            ViewBag.StatusProtocolos = new SelectList(await _context.StatusProtocolos.ToListAsync(), "IdStatus", "NomeStatus", protocolo.ProtocoloStatusId);
            return View(protocolo);
        }
    }
}