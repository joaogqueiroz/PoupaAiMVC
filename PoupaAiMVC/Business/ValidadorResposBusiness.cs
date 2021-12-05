using PoupaAiMVC.Models.Questionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaAiMVC.Business
{
    public class ValidadorResposBusiness : IValidarRespostasBusiness
    {
        public Task<ValidaRespostasModel> ValidaRespostas(AvaliacaoModel model)
        {
            var response = new ValidaRespostasModel();

            if (validador(model))
            {

            }

            return null; 
        }
        private bool validador(AvaliacaoModel model)
        {
            foreach (var alternativa in model.Alternativas)
            {
                if (alternativa == null)
                {

                    return false;
                }
               
            }
            return true;
        }
    }
}
