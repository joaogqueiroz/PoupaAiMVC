using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeMVC.Data.Entities
{
    public class TipoQuestao
    {
        public int IdTipo { get; set; }
        public string Descricao { get; set; }
        public int IdQuestao { get; set; }
    }
}
