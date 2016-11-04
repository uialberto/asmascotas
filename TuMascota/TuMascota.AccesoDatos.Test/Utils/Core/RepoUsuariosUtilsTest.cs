using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuMascota.AccesoDatos.DataModels;
using TuMascota.AccesoDatos.Modulos.Core.Usuarios;
using TuMascota.Aplicacion;
using TuMascota.Aplicacion.Modulos.Core.Usuarios.Repo;

namespace TuMascota.AccesoDatos.Test.Utils.Core
{
    public class RepoUsuariosUtilsTest
    {
        public static IRepoUsuarios CreateUsuariosRepository()
        {
            return new RepoUsuarios(UnitOfWorkTestUtils.GetUnitOfWork());
        }
        public static async Task<int> CreateUsuario()
        {
            var repo = CreateUsuariosRepository();
            var entity = GetUsuario();
            var rest = await repo.Crear(entity);
            return rest;
        }
        public static async Task<int> CreateUsuario(Usuario usuario)
        {
            var repo = CreateUsuariosRepository();
            var entity = usuario;
            var rest = await repo.Crear(entity);
            return rest;
        }
        public static Usuario GetUsuario()
        {
            var result = new Usuario()
            {
                Username = UtilitariosBase.NewGuid(),
                Password = UtilitariosBase.NewGuid(),
                Email = UtilitariosBase.NewGuid(),
                Nombres = UtilitariosBase.NewGuid()
            };
            return result;
        }
    }
}
