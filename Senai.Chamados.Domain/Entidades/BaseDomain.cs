using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Chamados.Domain.Entidades
{
    /// <summary>
    /// Dominio base do sistema 
    /// </summary>
    public class BaseDomain
    {
       public Guid Id { get; set; }
       public DateTime DataCriacao { get; set;}
       public DateTime DataAlteracao { get; set;}
    }
}
