using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Senai.Chamados.Web.ViewModels
{
    public class CadastrarUsuarioViewModel
    {
        [Display(Name = "Informe o nome")]
        [Required(ErrorMessage ="Informe o campo nome")]
        public string Nome {get; set; }

        [Display(Name = "Informe o Email")]
        [Required(ErrorMessage = "Informe o campo email")]
        [EmailAddress(ErrorMessage = "O Email é Inválido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Informe o Telefone")]
        [Required(ErrorMessage = "Informe o campo Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Display(Name = "Informe a Senha")]
        [Required(ErrorMessage = "Informe a senha Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        
        public SelectList Sexo { get; set; }
        [Required(ErrorMessage = "Informe o sexo")]
        public string SexoId { get; set; }
    }
}