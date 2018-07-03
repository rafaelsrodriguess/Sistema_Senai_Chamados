using Senai.Chamados.Data.Contexto;
using Senai.Chamados.Domain.Contratos;
using Senai.Chamados.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Chamados.Data.Repositorios
{
    public class UsuarioRepositorio : IUsusarioRepositorio
    {
        private readonly SenaiChamadosDbContext _contexto;

        public UsuarioRepositorio()
        {
            _contexto = new SenaiChamadosDbContext();
                
        }
        /// <summary>
        /// Altera um usuário no Banco
        /// </summary>
        /// <param name="domain"></param>
        /// <returns>Retorna true para usuario cadastrado e fala caso não seja cadastrado</returns>
        public bool Alterar(UsuarioDomain domain)
        {
            _contexto.Entry<UsuarioDomain>(domain).State = System.Data.Entity.EntityState.Modified;
            int linhasAlteradas = _contexto.SaveChanges();
            if (linhasAlteradas > 0) 
            return true;
            else
            return false;

        }
        /// <summary>
        /// Busca usuario pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public UsuarioDomain BuscarPorID(Guid id, string[] includes = null)
        {
            var query = _contexto.Usuarios.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.FirstOrDefault(x => x.Id == id);
        }
        /// <summary>
        /// Deleta um usuario no Banco
        /// </summary>
        /// <param name="domain"></param>
        /// <returns>Retorna true para usuario cadastrado e fala caso não seja cadastrado</returns>
        public bool Deletar(UsuarioDomain domain)
        {
            var usuario = _contexto.Usuarios.Single(o => o.Id == domain.Id);
            _contexto.Usuarios.Remove(usuario);
            int linhasExcluidas = _contexto.SaveChanges();

            if (linhasExcluidas > 0)
                return true;
            else
                return false;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        /// <summary>
        /// Insere um novo usuário no Banco
        /// </summary>
        /// <param name="domain"></param>
        /// <returns>Retorna true para usuario cadastrado e fala caso não seja cadastrado</returns>
        public bool Inserir(UsuarioDomain domain)
        {
            _contexto.Usuarios.Add(domain);
            int linhasIncluidas = _contexto.SaveChanges();

            if (linhasIncluidas > 0)
                return true;
            else
                return false;

        }

        /// <summary>
        /// Lista todos os usuarios do Banco
        /// </summary>
        /// <param name="includes"></param>
        /// <returns>Retorna uma lista de usuarios domain</returns>
        public List<UsuarioDomain> Listar(string[] includes = null)
        {
            var query = _contexto.Usuarios.AsQueryable();

            if(includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
               // query = includes.Aggregate(query, (current, include) => current.Include(include));
                
            }
             return query.ToList();
        }

        /// <summary>
        /// valida um usuario no Banco
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns>Retorna um Usuário caso o mesmo seja Válido</returns>
        public UsuarioDomain Login(string email, string senha)
        {
            UsuarioDomain UsuarioBanco = _contexto.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);

            if (UsuarioBanco == null)
                return null;
            else
                return UsuarioBanco;
        }
    }
}
