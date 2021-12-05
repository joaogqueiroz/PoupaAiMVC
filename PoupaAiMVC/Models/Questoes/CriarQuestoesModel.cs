using PoupaAiMVC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaAiMVC.Models.Questoes
{
    public class CriarQuestoesModel
    {

        public int IdQuestao { get; set; }
        public string Enunciado { get; set; }
        public int Imagem { get; set; }
        public TipoQuestao TipoQuestao { get; set; }
        public Nivel Nivel { get; set; }
        public List<Alternativa> Alternativas { get; set; }
    }
}
