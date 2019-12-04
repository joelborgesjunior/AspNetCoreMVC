using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMVC.Models;


namespace AspNetCoreMVC.Controllers
{
    public class InstituicaoController : Controller
    {
        private static List<Instituicao> instituicoes = new List<Instituicao>()
        {
            new Instituicao()
            {
                IdInstituicao = 1,
                NomeInstituicao = "USP",
                EndereçoInstituicao = "São Paulo"
            },
            new Instituicao()
            {
                IdInstituicao = 2,
                NomeInstituicao = "UFRJ",
                EndereçoInstituicao = "Rio de Janeiro"
            },
            new Instituicao()
            {
                IdInstituicao = 3,
                NomeInstituicao = "UFMG",
                EndereçoInstituicao = "Minas Gerais"
            },
            new Instituicao()
            {
                IdInstituicao = 4,
                NomeInstituicao = "UFSC",
                EndereçoInstituicao = "Santa Catarina"
            },
            new Instituicao()
            {
                IdInstituicao = 5,
                NomeInstituicao = "Mackenzie",
                EndereçoInstituicao = "São Paulo"
            }
        };

        public IActionResult Index()
        {
            return View(instituicoes);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instituicao instituicao) 
        {
            instituicoes.Add(instituicao);
            instituicao.IdInstituicao = instituicoes.Select(i => i.IdInstituicao).Max() + 1;
            return RedirectToAction("Index");
        }
    }
}