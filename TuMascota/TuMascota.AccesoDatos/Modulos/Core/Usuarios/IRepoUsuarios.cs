using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuMascota.AccesoDatos.DataModels;

namespace TuMascota.AccesoDatos.Modulos.Core.Usuarios
{
    public interface IRepoUsuarios : IDisposable
    {
        Task<Usuario> Obtener(long id);
        Task<int> Crear(Usuario entity);
        Task<Usuario> Editar(Usuario dto);
        Task<int> Eliminar(long id);
        IUnitOfWork UnitOfWork { get; }
    }
}
