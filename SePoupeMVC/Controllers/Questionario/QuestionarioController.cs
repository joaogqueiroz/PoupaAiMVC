using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SePoupeMVC.Data.Interfaces;
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

        public QuestionarioController(IUsuarioRepository usuarioRepository, IQuestoesRepository questoesRepository)
        {
            _usuarioRepository = usuarioRepository;
            _questoesRepository = questoesRepository;
        }

        public IActionResult Avaliacao()
        {
            try
            {

                var email = User.Identity.Name;

                var usuario = _usuarioRepository.Get(email);
                var pontuacao = _usuarioRepository.GetPontuacao(usuario.IdUsuario);

                if (pontuacao >= 7)
                {
                    var Questoes = _questoesRepository.GetByMundo2();
                    TempData["Questoes"] = Questoes;
                }
                else if (true)
                {

                }
                else
                {

                }

               
            }
            catch (Exception e)
            {

                TempData["Message"] = e.Message;
            }
            return View();
        }

        public IActionResult Consulta()
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
