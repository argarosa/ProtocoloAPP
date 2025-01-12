using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Models;
using ProtocoloApp.Data;
using System.Threading.Tasks;

public class ProtocoloAppController : Controller
{
    private readonly ProtocoloContext _context;

    public ProtocoloAppController(ProtocoloContext context)
    {
        _context = context;
    }

    // GET: ProtocoloApp
    public async Task<IActionResult> Index()
    {
        var protocolos = await _context.Protocolos.Include(p => p.Cliente).Include(p => p.StatusProtocolo).ToListAsync();
        return View(protocolos);
    }

    // GET: ProtocoloApp/Create
    public IActionResult Create()
    {
        ViewBag.Clientes = _context.Clientes.ToList();
        ViewBag.StatusProtocolos = _context.StatusProtocolos.ToList();
        return View();
    }

    // POST: ProtocoloApp/Create
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
        ViewBag.Clientes = _context.Clientes.ToList();
        ViewBag.StatusProtocolos = _context.StatusProtocolos.ToList();
        return View(protocolo);
    }

    // GET: ProtocoloApp/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var protocolo = await _context.Protocolos.FindAsync(id);
        if (protocolo == null)
        {
            return NotFound();
        }
        ViewBag.Clientes = _context.Clientes.ToList();
        ViewBag.StatusProtocolos = _context.StatusProtocolos.ToList();
        return View(protocolo);
    }

    // POST: ProtocoloApp/Edit/5
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
        ViewBag.Clientes = _context.Clientes.ToList();
        ViewBag.StatusProtocolos = _context.StatusProtocolos.ToList();
        return View(protocolo);
    }

    // GET: ProtocoloApp/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var protocolo = await _context.Protocolos
            .Include(p => p.Cliente)
            .Include(p => p.StatusProtocolo)
            .FirstOrDefaultAsync(m => m.IdProtocolo == id);
        if (protocolo == null)
        {
            return NotFound();
        }

        return View(protocolo);
    }

    // POST: ProtocoloApp/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var protocolo = await _context.Protocolos.FindAsync(id);
        _context.Protocolos.Remove(protocolo);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProtocoloExists(int id)
    {
        return _context.Protocolos.Any(e => e.IdProtocolo == id);
    }
}