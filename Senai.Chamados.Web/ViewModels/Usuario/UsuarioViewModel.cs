using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Senai.Chamados.Web.ViewModels.Usuario
{
    public class UsuarioViewModel : BaseViewModel
    {
        [Display(Name = "Informe o nome")]
        [Required(ErrorMessage = "Informe o campo nome")]
        public string Nome { get; set; }

        [Display(Name = "Informe o Email")]
        [Required(ErrorMessage = "Informe o campo email")]
        [EmailAddress(ErrorMessage = "O Email é Inválido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Informe o Telefone")]
        [Required(ErrorMessage = "Informe o campo Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o cpf")]
        [MaxLength(14, ErrorMessage = "Cpf deve possuir no máximo 14 Caracteres")]
        public string Cpf { get; set; }

        [Display(Name = "Informe a Senha")]
        [Required(ErrorMessage = "Informe a senha Senha")]
        [DataType(DataType.Password)]
        [MaxLength(8, ErrorMessage = "Nuúmero máximo de Caracteres é 8")]
        [MinLength(4, ErrorMessage = "Número minimo de Caracteres é 4")]
        public string Senha { get; set; }

        public SelectList Sexo { get; set; }
        [Required(ErrorMessage = "Informe o sexo")]
        public string SexoId { get; set; }

        [MaxLength(9, ErrorMessage = "Cep deve possuir no máximo 9 Caracteres")]
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}