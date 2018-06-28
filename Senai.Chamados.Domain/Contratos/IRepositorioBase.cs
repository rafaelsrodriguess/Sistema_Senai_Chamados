using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Chamados.Domain.Contratos
{
   public interface IRepositorioBase<TDomain> where TDomain : class
    {
        TDomain BuscarPorID(Guid id, string[] includes = null);
        List<TDomain> Listar(string[] includes = null);
        bool Inserir(TDomain domain);
        bool Alterar(TDomain domain);
        bool Deletar(TDomain domain);

    }
}
