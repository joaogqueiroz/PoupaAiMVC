using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaAiMVC.Models.Questionario
{
    public class PreencheAvalicaoModel
    {
        public List<Data.Entities.Questao> Questoes { get; set; }
        public List<Data.Entities.Alternativa> Alternativas { get; set; }
        public bool AlternativaEscolhida { get; set; }
    }
}
