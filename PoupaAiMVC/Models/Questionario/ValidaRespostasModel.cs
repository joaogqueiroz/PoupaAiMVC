using PoupaAiMVC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaAiMVC.Models.Questionario
{
    public class ValidaRespostasModel
    {
        public List<Questao> Questoes { get; set; }
        public List<Alternativa> Alternativas { get; set; }
        public List<string> AlternativaEscolhida { get; set; }
    }
}
