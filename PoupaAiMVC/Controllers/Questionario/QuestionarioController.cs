using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoupaAiMVC.Data.Entities;
using PoupaAiMVC.Data.Interfaces;
using PoupaAiMVC.Models.Questionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaAiMVC.Controllers.Questionario
{
    [Authorize]
    public class QuestionarioController : Controller
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPontosRepository _pontosRepository;
        private readonly IQuestoesRepository _questoesRepository;
        private readonly IAlternativaRepository _alternativaRepository;
        private readonly INivelRepository _nivelRepository;

        public QuestionarioController(IUsuarioRepository usuarioRepository, IPontosRepository pontosRepository, IQuestoesRepository questoesRepository, IAlternativaRepository alternativaRepository, INivelRepository nivelRepository)
        {
            _usuarioRepository = usuarioRepository;
            _pontosRepository = pontosRepository;
            _questoesRepository = questoesRepository;
            _alternativaRepository = alternativaRepository;
            _nivelRepository = nivelRepository;
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

                    ValidaRespostasModel model = new ValidaRespostasModel();
                    model.Alternativas = Alternativas;
                    model.Questoes = Questoes;

                    return View(model);
                }
                else if (id == 2)
                {
                    var Questoes = _questoesRepository.GetByMundo2();
                    var Alternativas = _alternativaRepository.Read();

                    ValidaRespostasModel model = new ValidaRespostasModel();
                    model.Alternativas = Alternativas;
                    model.Questoes = Questoes;

                    return View(model);
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
        public IActionResult Resultado(ValidaRespostasModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pontuacao = 0;
                    var Alternativas = _alternativaRepository.Read();

                    for (int i = 0; i < model.Questoes.Count(); i++)
                    {

                        if (model.Questoes.Count() == model.AlternativaEscolhida.Count())
                        {
                            for (int j = 0; j < Alternativas.Count(); j++)
                            {
                                var resposta = model.AlternativaEscolhida[i];
                                if (resposta == Alternativas[j].alternativa)
                                {
                                    if (Alternativas[j].correta == true)
                                    {
                                        pontuacao++;
                                    }
                                }

                            }

                        }
                    }
                    
                    var email = User.Identity.Name;
                    var usuario = _usuarioRepository.Get(email);
                    Pontos ponto = new Pontos();
                    Nivel nivel = new Nivel();
                    nivel = _nivelRepository.GetNivelByIDQuestaoFrist(model.Questoes[0].IdQuestao);
                    var notas = _pontosRepository.GetPontosByIDUsuario(usuario.IdUsuario);

                    ponto.IdUsuario = usuario.IdUsuario;
                    if ((nivel.Descricao == "Nivel1") && (notas.Nivel1 < pontuacao ))
                    {
                        ponto.Nivel1 = pontuacao;
                        ponto.Nivel2 = notas.Nivel2;
                        ponto.Nivel3 = notas.Nivel3;
                        ponto.IdPontos = notas.IdPontos;
                        _pontosRepository.Update(ponto);
                    }
                    else if ((nivel.Descricao == "Nivel2") && (notas.Nivel2 < pontuacao))
                    {
                        ponto.Nivel1 = notas.Nivel1;
                        ponto.Nivel2 = pontuacao;
                        ponto.Nivel3 = notas.Nivel3;
                        ponto.IdPontos = notas.IdPontos;
                        _pontosRepository.Update(ponto);
                    }

                    TempData["Resultado"] = pontuacao;
                    return View();
                }                
            }
            catch (Exception e)
            {

                TempData["Messege"] = "Error" + e.Message;
            }
            return View();
        }
    }
}
