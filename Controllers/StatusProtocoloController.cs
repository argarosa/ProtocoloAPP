using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Models;
using ProtocoloApp.Data;
using System.Threading.Tasks;

public class StatusProtocoloController : Controller
{
    private readonly ProtocoloContext _context;

    public StatusProtocoloController(ProtocoloContext context)
    {
        _context = context;
    }

    // GET: StatusProtocolo
    public async Task<IActionResult> Index()
    {
        return View(await _context.StatusProtocolos.ToListAsync());
    }

    // GET: StatusPro tocolo/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: StatusProtocolo/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StatusProtocolo statusProtocolo)
    {
        if (ModelState.IsValid)
        {
            _context.Add(statusProtocolo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(statusProtocolo);
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
        _context.StatusProtocolos.Remove(statusProtocolo);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StatusProtocoloExists(int id)
    {
        return _context.StatusProtocolos.Any(e => e.IdStatus == id);
    }
}