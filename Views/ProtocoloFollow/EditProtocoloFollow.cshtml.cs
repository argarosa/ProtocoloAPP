using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Models;
using ProtocoloApp.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProtocoloApp.Controllers
{
    public class EditProtocoloFollowController : Controller
    {
        private readonly ProtocoloContext _context;

        public EditProtocoloFollowController(ProtocoloContext context)
        {
            _context = context;
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

            // Preencher o ViewBag com os protocolos disponíveis
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

            // Se o modelo não for válido, recarregue os dados dos protocolos
            ViewBag.Protocolos = new SelectList(await _context.Protocolos.ToListAsync(), "IdProtocolo", "Titulo", protocoloFollow.ProtocoloId);
            return View(protocoloFollow);
        }

        private bool ProtocoloFollowExists(int id)
        {
            return _context.ProtocoloFollows.Any(e => e.IdFollow == id);
        }
    }
}