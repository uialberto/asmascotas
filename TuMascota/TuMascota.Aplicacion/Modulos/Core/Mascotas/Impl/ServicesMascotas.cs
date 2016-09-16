using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuMascota.AccesoDatos.Modulos.Core.Mascotas;
using UIBASOFT.Base.Aplicacion.Aplication.Services;
using UIBASOFT.Base.Comunes.ResultOperation;

namespace TuMascota.Aplicacion.Modulos.Core.Mascotas.Impl
{
    public class ServicesMascotas : IServicesMascotas
    {
        protected readonly IRepoMascotas RepoMascotas;

        #region Constructor

        public ServicesMascotas(IRepoMascotas pRepoMascotas)
        {
            if (pRepoMascotas == null)
                throw new ArgumentNullException(nameof(pRepoMascotas));
            RepoMascotas = pRepoMascotas;
        }

        #endregion

        #region Metodos

        public ResultPrimitiveValue<int> TotalPendientesAdopcion()
        {
            var result = new ResultPrimitiveValue<int>();
            try
            {
                result = RepoMascotas.TotalPendientesAdopcion();
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                // ToDo Pendiente para controlar excepcion de dominio
                result.Errors.Add(mensaje);
            }
            return result;
        }

        public ResultPrimitiveValue<int> TotalAdoptadas()
        {
            var result = new ResultPrimitiveValue<int>();
            try
            {
                result = RepoMascotas.TotalAdoptadas();
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                // ToDo Pendiente para controlar excepcion de dominio
                result.Errors.Add(mensaje);
            }
            return result;
        }

        #endregion

        #region Dispose

        protected void Dispose(bool disposing)
        {
            if (!disposing) return;
            RepoMascotas.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
