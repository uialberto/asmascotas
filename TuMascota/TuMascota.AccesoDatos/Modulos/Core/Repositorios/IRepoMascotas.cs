using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuMascota.AccesoDatos.Modulos.Core.Repositorios
{
    public interface IRepoMascotas : IRepository
    {        
        int CantidadMascotasOlvidadas();
        int CantidadMascotasSalvadas();
    }
}
