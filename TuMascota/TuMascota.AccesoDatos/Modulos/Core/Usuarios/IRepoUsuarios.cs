using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuMascota.AccesoDatos.DataModels;
using UIBASOFT.Base.Comunes.ResultOperation;

namespace TuMascota.AccesoDatos.Modulos.Core.Usuarios
{
    public interface IRepoUsuarios : IDisposable
    {
        Task<Usuario> Obtener(int id);
        Task<int> Crear(Usuario entity);
        Task<Usuario> Editar(Usuario dto);
        Task<int> Eliminar(int id);
        IUnitOfWork UnitOfWork { get; }
    }
}
