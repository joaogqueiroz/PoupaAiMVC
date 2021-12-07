using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoupaAiMVC.Data.Entities
{
    public class Alternativa
    {
        public int IdAlternativa { get; set; }
        public string alternativa { get; set; }
        public bool correta { get; set; }
        public int Id_Questao { get; set; }
        public string AlternativaEscolhida { get; set; }

    }
}
