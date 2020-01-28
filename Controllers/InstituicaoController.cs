using AspNetCoreMVC.Data;
using AspNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVC.Controllers
{
    public class InstituicaoController : Controller
    {
        private readonly IESContext _context;

        public InstituicaoController(IESContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Instituicoes.OrderBy(i => i.Id).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id", "Nome", "Endereço")] Instituicao instituicao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(instituicao);
                    TempData["Message"] = "Instituição " + instituicao.Nome + " foi criada com sucesso.";
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }

            return View(instituicao);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(m => m.Id == id);

            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("Id, Nome, Endereço")] Instituicao instituicao)
        {
            if (id != instituicao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicao);
                    TempData["Message"] = "Instituição " + instituicao.Nome + " foi atualizada com sucesso.";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituicaoExists(instituicao.Id))
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
            return View(instituicao);
        }

        private bool InstituicaoExists(long? id)
        {
            return _context.Instituicoes.Any(i => i.Id == id);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes.Include(d => d.Departamentos).SingleOrDefaultAsync(i => i.Id == id);

            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);

        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.Id == id);
            _context.Departamentos.Where(i => instituicao.Id == i.InstituicaoId).Load();

            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.Id == id);
            _context.Instituicoes.Remove(instituicao);
            TempData["Message"] = "Instituição " + instituicao.Nome + " foi removida com sucesso.";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}