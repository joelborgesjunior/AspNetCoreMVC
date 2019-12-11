using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMVC.Data;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMVC.Models;

namespace AspNetCoreMVC.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IESContext _context;
        
        public DepartamentoController(IESContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Departamentos.OrderBy(c => c.DepartamentoId).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome")] Departamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(departamento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            } 
            
            catch
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }

            return View(departamento);
        }


    }
}