using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMVC.Data;
using AspNetCoreMVC.Models;
using System;

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
            return View(await _context.Institucoes.OrderBy( i => i.IdInstituicao).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeInstituicao")] Instituicao instituicao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(instituicao);
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
            if(id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Institucoes.SingleOrDefaultAsync(m => m.IdInstituicao == id);

            if(instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IdInstituicao, NomeInstituicao, EndereçoInstituicao")] Instituicao instituicao)
        {
            if(id != instituicao.IdInstituicao)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicao);
                    await _context.SaveChangesAsync();
                } 
                catch(DbUpdateConcurrencyException) 
                {
                    if (!InstituicaoExists(instituicao.IdInstituicao))
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
            return _context.Institucoes.Any(i => i.IdInstituicao == id);
        }       

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Institucoes.SingleOrDefaultAsync(i => i.IdInstituicao == id);

            if(instituicao == null)
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

            var instituicao = await _context.Institucoes.SingleOrDefaultAsync( i => i.IdInstituicao == id);

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
            var instituicao = await _context.Institucoes.SingleOrDefaultAsync(i => i.IdInstituicao == id);
            _context.Institucoes.Remove(instituicao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}