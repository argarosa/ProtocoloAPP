using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Models;
using ProtocoloApp.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProtocoloApp.Controllers
{
    public class EditStatusProtocoloController : Controller
    {
        private readonly ProtocoloContext _context;

        public EditStatusProtocoloController(ProtocoloContext context)
        {
            _context = context;
        }

        // GET: StatusProtocolo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusProtocolo = await _context.StatusProtocolos.FindAsync(id);
            if (statusProtocolo == null)
            {
                return NotFound();
            }

            return View(statusProtocolo);
        }

        // POST: StatusProtocolo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StatusProtocolo statusProtocolo)
        {
            if (id != statusProtocolo.IdStatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusProtocolo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusProtocoloExists(statusProtocolo.IdStatus))
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
            return View(statusProtocolo);
        }

        private bool StatusProtocoloExists(int id)
        {
            return _context.StatusProtocolos.Any(e => e.IdStatus == id);
        }
    }
}