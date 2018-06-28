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


        public override int SaveChanges()
        {
            
                {
                try
                {

                    foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("DataCriacao") != null))
                    {
                        if (new Guid(entry.Property("Id").CurrentValue.ToString()) == Guid.Empty)
                        {
                            entry.Property("Id").CurrentValue = Guid.NewGuid();
                        }
                        if(entry.State == EntityState.Added)
                        {
                            entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                            entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                        }
                        if (entry.State == EntityState.Modified)
                        {
                            entry.Property("DataCriacao").IsModified = false;
                            entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                        }
                    }

                    return base.SaveChanges();

                }
                catch (SystemException ex)
                {

                    throw new System.Exception(ex.Message);
                }
            }
        }
    }
}
