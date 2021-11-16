using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoupaAiMVC.Data.Entities;
using PoupaAiMVC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaAiMVC.Controllers.Questoes
{
    [Authorize]
    public class QuestoesController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IQuestoesRepository _questoesRepository;

        public QuestoesController(IUsuarioRepository usuarioRepository, IQuestoesRepository questoesRepository)
        {
            _usuarioRepository = usuarioRepository;
            _questoesRepository = questoesRepository;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Questao questoes)
        {
            return View();
        }


        public IActionResult Consultar()
        {
            return View();
        }
    }
}
