using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeMVC.Models.Conta
{
    public class LoginContaModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um email valido")]
        [Required(ErrorMessage = "Por favor, informe seu email")]
        public string Email { get; set; }


        [MaxLength(20, ErrorMessage = "Senha deve conter no máximo {1} caracteres.")]
        [MinLength(8, ErrorMessage = "Senha deve conter no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe sua senha")]
        public string Senha { get; set; }
    }
}
