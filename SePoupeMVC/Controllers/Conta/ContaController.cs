using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SePoupeMVC.Data.Entities;
using SePoupeMVC.Data.Interfaces;
using SePoupeMVC.Messages;
using SePoupeMVC.Models.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SePoupeMVC.Controllers.Conta
{
    public class ContaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPontosRepository _pontosRepository;

        public ContaController(IUsuarioRepository usuarioRepository, IPontosRepository pontosRepository)
        {
            _usuarioRepository = usuarioRepository;
            _pontosRepository = pontosRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginContaModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_usuarioRepository.Get(model.Email, model.Senha) != null)
                    {
                        //User Auth
                        var auth = new ClaimsIdentity(
                            new[] { new Claim(ClaimTypes.Name, model.Email) },
                            CookieAuthenticationDefaults.AuthenticationScheme);

                        //Creating cookie
                        var claim = new ClaimsPrincipal(auth);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claim);

                        //redirect to /Home/Index
                        //VIEW  CONTROLLER
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["Message"] = $"Invalid usuario or password";
                    }
                }
                catch (Exception e)
                {

                    TempData["Message"] = "Erro: " + e.Message;
                }
            }
            return View();
        }
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(CadastroContaModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = new Usuario();
                    usuario.Nome = model.Nome;
                    usuario.Email = model.Email;
                    usuario.Senha = model.Senha;
                    usuario.CPF = model.CPF;
                    usuario.Tipo = 1;
                    usuario.Nascimento = model.Nascimento;
                    usuario.Sexo = model.Sexo.ToString();
                    


                    //email verification
                    if (_usuarioRepository.Get(usuario.Email) != null)
                    {
                        TempData["Message"] = $"Email {usuario.Email} already exists";
                    }
                    else
                    {
                        //creating
                        _usuarioRepository.Create(usuario);
                        var user =_usuarioRepository.Get(usuario.Email);
                        if (true)
                        {
                            Pontos pontos = new Pontos();
                            pontos.IdUsuario = user.IdUsuario;
                            pontos.Nivel1 = 0;
                            pontos.Nivel2 = 0;
                            pontos.Nivel3 = 0;
                            _pontosRepository.Create(pontos);

                            TempData["Message"] = $"Uusario {usuario.Nome} cadastrado com com sucesso";
                            ModelState.Clear();

                        }
                        else {
                            TempData["Message"] = $"Erro interno.";
                        }
                    }


                }
                catch (Exception e)
                {

                    TempData["Message"] = "Erro: " + e.Message;
                }


            }
            return View();
        }
        public IActionResult Logout()
        {
            //Delete usuario cookie
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Conta");
        }
        public IActionResult RecuperarSenha()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RecuperarSenha(RecuperarSenhaContaModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = _usuarioRepository.Get(model.Email);
                    if (usuario != null)
                    {
                        var novaSenha = new Random().Next(99999999, 999999999).ToString();
                        _usuarioRepository.Update(usuario.IdUsuario, novaSenha);
                        //send email

                        var to = usuario.Email;
                        var subject = "New password - Task Control System";
                        var body = $@"
                        <div style='text-align: center; margin:40px; padding: 60px; borde: 2px solid #ccc; font-size: 16pt;'>
                         <br/>
                        Hello <strong>{usuario.Nome}</strong>,
                         <br/>
                         System generats a new password for you access your account.
                         <br/>
                         Please use this password: <strong>{novaSenha}</strong>
                         <br/>
                         After to login you could to change this password for one that you prefer.
                         <br/>
                         Best Regards.
                        </div>
                        ";

                        var message = new EmailServiceMessage();
                        message.SendEmail(to, subject, body);
                        TempData["Message"] = $"New password are generated com sucesso and sent to your email'{usuario.Email}' .";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["Message"] = "The email doesn't exists in this system.";
                    }
                }
                catch (Exception e)
                {

                    TempData["Message"] = "Erro: " + e.Message;
                }

            }
            return View();
        }
    }
}
