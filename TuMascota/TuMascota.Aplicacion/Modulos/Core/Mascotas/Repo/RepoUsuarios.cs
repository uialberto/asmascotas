using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuMascota.AccesoDatos;
using TuMascota.AccesoDatos.Modulos.Core.Repositorios;

namespace TuMascota.Aplicacion.Modulos.Core.Mascotas.Repo
{
    public class RepoUsuarios : IRepoUsuarios
    {
        public RepoUsuarios()
        {

        }
        public RepoUsuarios(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
        }
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
