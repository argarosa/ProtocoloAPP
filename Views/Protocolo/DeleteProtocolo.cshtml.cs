using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Data;
using ProtocoloApp.Models;
using System.Threading.Tasks;

namespace ProtocoloManager.Controllers
{
    public class DeleteProtocoloController : Controller
    {
        private readonly ProtocoloContext _context;

        public DeleteProtocoloController(ProtocoloContext context)
        {
            _context = context;
        }

        // GET: Protocolo/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

            return View(protocolo);
        }

        // POST: Protocolo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var protocolo = await _context.Protocolos.FindAsync(id);
            if (protocolo != null)
            {
                _context.Protocolos.Remove(protocolo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}