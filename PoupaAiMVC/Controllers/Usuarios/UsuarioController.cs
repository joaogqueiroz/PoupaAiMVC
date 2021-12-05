using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoupaAiMVC.Data.Interfaces;
using PoupaAiMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaAiMVC.Controllers.Usuarios
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Informacao()
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = _usuarioRepository.Get(email);
                TempData["ID"] = usuario.IdUsuario;
                TempData["Nome"] = usuario.Nome;
                TempData["Email"] = usuario.Email;
                TempData["DataNascimento"] = usuario.Nascimento.ToString("dd/MM/yyyy");
            }
            catch (Exception e)
            {

                TempData["Messege"] = e.Message;
            }
            return View();
        }

        public IActionResult AlterarSenha()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AlterarSenha(AlterarSenhaUsuarioModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var email = User.Identity.Name;
                    var usuario = _usuarioRepository.Get(email);
                    //Validate if email and password is the same in database
                    if (_usuarioRepository.Get(email, model.SenhaAtual) != null)
                    {
                        //try to update the password only.
                        _usuarioRepository.Update(usuario.IdUsuario, model.NovaSenha);
                        TempData["Message"] = "Nova senha atualizada com sucesso, utilize a nova senha no seu proximo login.";
                    }
                    else
                    {
                        TempData["Message"] = "Senha atual esta incorreta, tente novamente";
                    }

                }
                catch (Exception e)
                {

                    TempData["Messege"] = e.Message;
                }
            }
            return View();
        }
    }
}
