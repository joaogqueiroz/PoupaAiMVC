using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeMVC.Models.Conta
{
    public class CadastroContaModel
    {
        [MaxLength(150, ErrorMessage = "Digite no maximo  {1} caracteres.")]
        [MinLength(6, ErrorMessage = "Digite no minimo {1} caracteres.")]
        [Required(ErrorMessage = "Preencha o campo nome.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Preencha o campo email, com um email valido.")]
        [Required(ErrorMessage = "Preencha o campo email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe seu CPF.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe sua data de nascimento.")]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "Selecione o sexo.")]
        public SexoUsuario? Sexo { get; set; }

        [StrongPassWord(ErrorMessage = "Informe um caracter maiusculo, 1 minusculo, 1 numero e um caracter especial(! @ # $ % & ).")]
        [MaxLength(20, ErrorMessage = "Digite no maximo  {1} caracteres")]
        [MinLength(8, ErrorMessage = "Digite no minimo {1} caracteres")]
        [Required(ErrorMessage = "Informe sua senha.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas precisam ser iguais.")]
        [Required(ErrorMessage = "Preencha o campo de confirmação de senha.")]
        public string ConfirmacaoSenha { get; set; }

    }
    //Usar na MODEL
    public enum SexoUsuario
    {
        M,
        F
    }
    public enum TipoUsuario
    {
        ADM,
        USER
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
