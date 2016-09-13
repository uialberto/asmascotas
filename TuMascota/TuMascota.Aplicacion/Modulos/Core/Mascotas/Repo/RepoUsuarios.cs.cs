using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuMascota.AccesoDatos;
using TuMascota.AccesoDatos.Modulos.Core.Usuarios;

namespace TuMascota.Aplicacion.Modulos.Core.Mascotas.Repo
{
    public class RepoUsuarios : IRepoUsuarios
    {
        public IUnitOfWork UnitOfWork
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
