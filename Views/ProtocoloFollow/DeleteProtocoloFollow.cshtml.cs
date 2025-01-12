using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Data;
using ProtocoloApp.Models;
using System.Threading.Tasks;

namespace ProtocoloApp.Controllers
{
    public class DeleteProtocoloFollowController : Controller
    {
        private readonly ProtocoloContext _context;

        public DeleteProtocoloFollowController(ProtocoloContext context)
        {
            _context = context;
        }

        // GET: ProtocoloFollow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocoloFollow = await _context.ProtocoloFollows
                .Include(p => p.Protocolo) // Inclui os dados do protocolo
                .FirstOrDefaultAsync(m => m.IdFollow == id);
            if (protocoloFollow == null)
            {
                return NotFound();
            }

            return View(protocoloFollow);
        }

        // POST: ProtocoloFollow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var protocoloFollow = await _context.ProtocoloFollows.FindAsync(id);
            if (protocoloFollow != null)
            {
                _context.ProtocoloFollows.Remove(protocoloFollow);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}