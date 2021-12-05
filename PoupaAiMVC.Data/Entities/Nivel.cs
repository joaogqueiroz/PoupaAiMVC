using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoupaAiMVC.Data.Entities
{
    public class Nivel
    {
        public int IdNivel { get; set; }
        public string Descricao { get; set; }
        public int Id_Questao { get; set; }
    }
}
