using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Senai.Chamados.Web.ViewModels
{
    public class LoginViewModel
    {

        [Display(Name = "Informe o Email")]
        [Required(ErrorMessage = "Informe o campo email")]
        [EmailAddress(ErrorMessage = "O Email é Inválido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Informe a Senha")]
        [Required(ErrorMessage = "Informe a senha Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}