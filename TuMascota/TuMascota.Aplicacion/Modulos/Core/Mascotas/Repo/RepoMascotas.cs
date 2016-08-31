using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuMascota.AccesoDatos;
using TuMascota.AccesoDatos.Modulos.Core.Repositorios;

namespace TuMascota.Aplicacion.Modulos.Core.Mascotas.Repo
{
    public class RepoMascotas : IRepoMascotas
    {
        public RepoMascotas()
        {

        }
        public RepoMascotas(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IUnitOfWork UnitOfWork { get; }
        public int CantidadMascotasOlvidadas()
        {
            throw new NotImplementedException();
        }

        public int CantidadMascotasSalvadas()
        {
            throw new NotImplementedException();
        }
    }
}
