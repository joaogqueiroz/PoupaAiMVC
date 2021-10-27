using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeMVC.Models.Conta
{
    public class CadastroContaModel
    {
        [MaxLength(150, ErrorMessage = "Type a maximum of {1} characters")]
        [MinLength(6, ErrorMessage = "Type a minimum of {1} characters")]
        [Required(ErrorMessage = "Inform your name.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Inform a valid email.")]
        [Required(ErrorMessage = "Inform your email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe seu CPF.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe sua data de nascimento.")]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "Selecione o sexo.")]
        public Sexo? Sexo { get; set; }

        [StrongPassWord(ErrorMessage = "Inform a uppercase letter 1, 1 lowercase letter, 1 number and 1 special character(! @ # $ % & ).")]
        [MaxLength(20, ErrorMessage = "Type a maximum of {1} characters")]
        [MinLength(8, ErrorMessage = "Type a minimum of {1} characters")]
        [Required(ErrorMessage = "Inform your password.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "The passwords don't are equals")]
        [Required(ErrorMessage = "Confirm your password")]
        public string ConfirmacaoSenha { get; set; }

    }
    public enum Sexo
    {
        M,
        F
    }
    public class StrongPassWord : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var password = value.ToString();

                return password.Any(char.IsUpper)
                    && password.Any(char.IsLower)
                    && password.Any(char.IsDigit)
                    && (password.Contains("!")
                       || password.Contains("@")
                       || password.Contains("#")
                       || password.Contains("$")
                       || password.Contains("%")
                       || password.Contains("&"));
            };
            return false;

        }
    }
}
