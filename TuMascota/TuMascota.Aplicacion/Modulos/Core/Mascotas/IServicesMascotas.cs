using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIBASOFT.Base.Comunes.ResultOperation;

namespace TuMascota.Aplicacion.Modulos.Core.Mascotas
{
    public interface IServicesMascotas : IDisposable
    {
        ResultPrimitiveValue<int> TotalPendientesAdopcion();
        ResultPrimitiveValue<int> TotalAdoptadas();
    }
}
