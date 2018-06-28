using Senai.Chamados.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Chamados.Domain.Contratos
{
    public interface IUsusarioRepositorio : IDisposable, IRepositorioBase<UsuarioDomain>
    {
        UsuarioDomain Login(String email, string senha);
    }
}
