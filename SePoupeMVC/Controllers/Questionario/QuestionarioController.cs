using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SePoupeMVC.Data.Entities;
using SePoupeMVC.Data.Interfaces;
using SePoupeMVC.Models.Questionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeMVC.Controllers.Questionario
{
    [Authorize]
    public class QuestionarioController : Controller
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IQuestoesRepository _questoesRepository;
        private readonly IAlternativaRepository _alternativaRepository;

        public QuestionarioController(IUsuarioRepository usuarioRepository, IQuestoesRepository questoesRepository, IAlternativaRepository alternativaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _questoesRepository = questoesRepository;
            _alternativaRepository = alternativaRepository;
        }

        public IActionResult Avaliacao(int id)
        {
            try
            {

                var email = User.Identity.Name;

                var usuario = _usuarioRepository.Get(email);

                
                if (id == 1)
                {
                    var Questoes = _questoesRepository.GetByMundo1();
                    var Alternativas = _alternativaRepository.Read();


                    TempData["Questoes"] = Questoes;
                    TempData["Alternativas"] = Alternativas;
                }
                else if (id == 2)
                {

                    var Questoes = _questoesRepository.GetByMundo2();
                    TempData["Questoes"] = Questoes;
                }
                else
                {

                    var Questoes = _questoesRepository.GetByMundo3();
                    TempData["Questoes"] = Questoes;
                }

            }
            catch (Exception e)
            {

                TempData["Message"] = e.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Consulta(AvaliacaoModel model)
        {
            try
            {
                //getting user email
                var email = User.Identity.Name;

                //getting user informations using email
                //var user = _userRepository.Get(email);

                //getting user tasks
                //TempData["Tasks"] = _taskRepository.GetByUser(user.UserID);

            }
            catch (Exception e)
            {

                TempData["Messege"] = "Error" + e.Message;
            }
            return View();
        }
    }
}
