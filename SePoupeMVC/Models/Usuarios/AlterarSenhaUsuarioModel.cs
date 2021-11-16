using SePoupeMVC.Models.Conta;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeMVC.Models.Usuarios
{
    public class AlterarSenhaUsuarioModel
    {
        [Required(ErrorMessage = "Informe sua senha atual")]
        public string SenhaAtual { get; set; }

        [StrongPassWord(ErrorMessage = "Informe um caracter maiusculo, 1 minusculo, 1 numero e um caracter especial(! @ # $ % & ).")]
        [MaxLength(20, ErrorMessage = "Digite no maximo  {1} caracteres")]
        [MinLength(8, ErrorMessage = "Digite no minimo {1} caracteres")]
        [Required(ErrorMessage = "Digite sua nova senha.")]
        public string NovaSenha { get; set; }

        [Compare("NovaSenha", ErrorMessage = "As senhas precisam ser iguais.")]
        [Required(ErrorMessage = "Confirme sua nova senha.")]
        public string ConfirmacaoNovaSenha { get; set; }
    }
}
