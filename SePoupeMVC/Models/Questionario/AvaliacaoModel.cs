using SePoupeMVC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeMVC.Models.Questionario
{
    public class AvaliacaoModel
    {
        public List<Questao> Questoes { get; set; }
        public List<Alternativa> Alternativas { get; set; }

    }
}
