using PoupaAiMVC.Models.Questionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaAiMVC.Business
{
    public interface IValidarRespostasBusiness
    {
        Task<ValidaRespostasModel> ValidaRespostas(AvaliacaoModel model);
    }
}
