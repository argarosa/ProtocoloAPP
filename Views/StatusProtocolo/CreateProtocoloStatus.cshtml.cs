using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProtocoloApp.Models;
using ProtocoloApp.Data;
using System.Threading.Tasks;

namespace ProtocoloManager.Controllers
{
    public class CreateStatusProtocoloController : Controller
    {
        private readonly ProtocoloContext _context;

        public CreateStatusProtocoloController(ProtocoloContext context)
        {
            _context = context;
        }

        // GET: StatusProtocolo/Create
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
                return RedirectToAction(nameof(Index)); // Redireciona para a lista de StatusProtocolo
            }
            return View(statusProtocolo); // Retorna a view com o modelo se houver erros de validação
        }
    }
}