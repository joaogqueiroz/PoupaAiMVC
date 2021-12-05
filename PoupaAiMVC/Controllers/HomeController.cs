using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoupaAiMVC.Data.Interfaces;
using PoupaAiMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaAiMVC.Controllers
{
    [Authorize] //Just allow authenticated users
    public class HomeController : Controller
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPontosRepository _pontosRepository;

        public HomeController(IUsuarioRepository usuarioRepository, IPontosRepository pontosRepository)
        {
            _usuarioRepository = usuarioRepository;
            _pontosRepository = pontosRepository;
        }

        public IActionResult Index()
        {
            try
            {
                var email = User.Identity.Name;

                var usuario = _usuarioRepository.Get(email);

                var Pontuacao = _pontosRepository.GetPontosByIDUsuario(usuario.IdUsuario);

                if (Pontuacao == null)
                {
                    TempData["Pontuacao"] = 0;

                }
                else
                {
                    TempData["Pontuacao"] = Pontuacao;


                }
                /*
                 var tasks = _pontosRepository.GetByUserAndPeriod(user.UserID, FirstDayOfCurrentMonth, LastDayOfCurrentMonth);

                TempData["LowPriorityAmount"] = tasks.Count(t => t.Priority.Equals("LOW"));
                TempData["MediumPriorityAmount"] = tasks.Count(t => t.Priority.Equals("MEDIUM"));
                TempData["HighPriorityAmount"] = tasks.Count(t => t.Priority.Equals("HIGH"));

                TempData["Tasks"] = tasks;
                */
            }
            catch (Exception e)
            {

                TempData["Message"] = e.Message;
            }
            return View();
        }
    }
}
