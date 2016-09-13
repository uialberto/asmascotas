using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuMascota.AccesoDatos.Modulos.Core.Usuarios
{
    public interface IRepoUsuarios : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
