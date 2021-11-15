using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeMVC.Models.Conta
{
    public class RecuperarSenhaContaModel
    {
        [EmailAddress(ErrorMessage = "Preencha o campo email, com um email valido.")]
        [Required(ErrorMessage = "Preencha o campo email.")]
        public string Email { get; set; }
    }
}
