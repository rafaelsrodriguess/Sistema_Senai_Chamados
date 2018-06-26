using Senai.Chamados.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Chamados.Data.Contexto
{
    public class SenaiChamadosDbContext : DbContext
    {

        public SenaiChamadosDbContext() : base(@"Data Source=.\SqlExpress; Initial Catalog=SenaiChamadosDb; 
                                                                            user id = sa;
        password=senai@123;")
        {

        }

        public DbSet<UsuarioDomain> Usuarios { get; set; }
    }
}
