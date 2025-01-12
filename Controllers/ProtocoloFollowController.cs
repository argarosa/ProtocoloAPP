using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Models;
using ProtocoloApp.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProtocoloManager.Controllers
{
    public class ProtocoloFollowController : Controller
    {
        private readonly ProtocoloContext _context;

        public ProtocoloFollowController(ProtocoloContext context)
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

        // GET: ProtocoloFollow/Create
        public IActionResult Create()
        {
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
            ViewBag.Protocolos = new SelectList(await _context.Protocolos.ToListAsync(), "IdProtocolo", "Titulo", protocoloFollow.ProtocoloId);
            return View(protocoloFollow);
        }

        // GET: ProtocoloFollow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocoloFollow = await _context.ProtocoloFollows.FindAsync(id);
            if (protocoloFollow == null)
            {
                return NotFound();
            }
            ViewBag.Protocolos = new SelectList(await _context.Protocolos.ToListAsync(), "IdProtocolo", "Titulo", protocoloFollow.ProtocoloId);
            return View(protocoloFollow);
        }

        // POST: ProtocoloFollow/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProtocoloFollow protocoloFollow)
        {
            if (id != protocoloFollow.IdFollow)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(protocoloFollow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProtocoloFollowExists(protocoloFollow.IdFollow))
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
            ViewBag.Protocolos = new SelectList(await _context.Protocolos.ToListAsync(), "IdProtocolo", "Titulo", protocoloFollow.ProtocoloId);
            return View(protocoloFollow);
        }

        // GET: ProtocoloFollow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocoloFollow = await _context.ProtocoloFollows
                .Include(p => p.Protocolo)
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

        private bool ProtocoloFollowExists(int id)
        {
            return _context.ProtocoloFollows.Any(e => e.IdFollow == id);
        }
    }
}