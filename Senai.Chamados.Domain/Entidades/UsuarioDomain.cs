using Senai.Chamados.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Chamados.Domain.Entidades
{
    [Table("Ususarios")]
   public class UsuarioDomain : BaseDomain
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Nome {get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Email { get; set; }

        public string Telefone { get; set; }
        public string Cpf { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(8)]
        public string Senha { get; set; }

        public EnTipoUsuario TipoUsuario { get; set; }

        public EnSexo Sexo { get; set; }

        [MaxLength(8)]
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

    }
}
