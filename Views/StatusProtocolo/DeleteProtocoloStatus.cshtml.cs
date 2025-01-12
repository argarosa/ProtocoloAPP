using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Data;
using ProtocoloApp.Models;
using System.Threading.Tasks;

namespace ProtocoloManager.Controllers
{
    public class DeleteStatusProtocoloController : Controller
    {
        private readonly ProtocoloContext _context;

        public DeleteStatusProtocoloController(ProtocoloContext context)
        {
            _context = context;
        }

        // GET: StatusProtocolo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusProtocolo = await _context.StatusProtocolos
                .FirstOrDefaultAsync(m => m.IdStatus == id);
            if (statusProtocolo == null)
            {
                return NotFound();
            }

            return View(statusProtocolo);
        }

        // POST: StatusProtocolo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusProtocolo = await _context.StatusProtocolos.FindAsync(id);
            if (statusProtocolo != null)
            {
                _context.StatusProtocolos.Remove(statusProtocolo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}