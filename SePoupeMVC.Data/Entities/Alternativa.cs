using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeMVC.Data.Entities
{
    public class Alternativa
    {
        public int IdAlternativa { get; set; }
        public string alternativa { get; set; }
        public string correta { get; set; }
        public int Id_Questao { get; set; }
        public bool AlternativaEscolhida { get; set; }

    }
}
