using PoupaAiMVC.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaAiMVC.Models.Questionario
{
    public class ValidaRespostasModel
    {
        [Required]
        public List<Questao> Questoes { get; set; }
        [Required]
        public List<Alternativa> Alternativas { get; set; }
        [Required]
        public List<string> AlternativaEscolhida { get; set; }
    }
}
