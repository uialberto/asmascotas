using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIBASOFT.Base.Comunes.ResultOperation;

namespace TuMascota.AccesoDatos.Modulos.Core.Mascotas
{
    public interface IRepoMascotas : IDisposable
    {
        ResultPrimitiveValue<int> TotalPendientesAdopcion();
        ResultPrimitiveValue<int> TotalAdoptadas();
        IUnitOfWork UnitOfWork { get; }
    }
}
