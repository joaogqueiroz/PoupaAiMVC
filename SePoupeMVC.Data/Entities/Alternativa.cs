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
        public string alternativa_1 { get; set; }
        public string alternativa_2 { get; set; }
        public string alternativa_3 { get; set; }
        public string alternativa_4 { get; set; }
        public string alternativa_correta { get; set; }
        public int Id_Questao { get; set; }
    }
}
