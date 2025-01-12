using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Models;
using ProtocoloApp.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProtocoloManager.Controllers
{
    public class EditProtocoloController : Controller
    {
        private readonly ProtocoloContext _context;

        public EditProtocoloController(ProtocoloContext context)
        {
            _context = context;
        }

        // GET: Protocolo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolos
                .Include(p => p.Cliente) // Inclui os dados do cliente
                .Include(p => p.StatusProtocolo) // Inclui os dados do status do protocolo
                .FirstOrDefaultAsync(m => m.IdProtocolo == id);

            if (protocolo == null)
            {
                return NotFound();
            }

            ViewBag.Clientes = new SelectList(await _context.Clientes.ToListAsync(), "IdCliente", "Nome", protocolo.ClienteId);
            ViewBag.StatusProtocolos = new SelectList(await _context.StatusProtocolos.ToListAsync(), "IdStatus", "NomeStatus", protocolo.ProtocoloStatusId);

            return View(protocolo);
        }

        // POST: Protocolo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Protocolo protocolo)
        {
            if (id != protocolo.IdProtocolo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(protocolo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProtocoloExists(protocolo.IdProtocolo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clientes = new SelectList(await _context.Clientes.ToListAsync(), "IdCliente", "Nome", protocolo.ClienteId);
            ViewBag.StatusProtocolos = new SelectList(await _context.StatusProtocolos.ToListAsync(), "IdStatus", "NomeStatus", protocolo.ProtocoloStatusId);
            return View(protocolo);
        }

        private bool ProtocoloExists(int id)
        {
            return _context.Protocolos.Any(e => e.IdProtocolo == id);
        }
    }
}