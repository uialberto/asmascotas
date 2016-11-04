using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuMascota.AccesoDatos;
using TuMascota.AccesoDatos.DataModels.Entities;
using TuMascota.AccesoDatos.Modulos.Core.Mascotas;
using UIBASOFT.Base.Comunes.ResultOperation;

namespace TuMascota.Aplicacion.Modulos.Core.Mascotas.Repo
{
    public class RepoMascotas : IRepoMascotas
    {
        #region Atributos

        private readonly UnitOfWorkBase _unitOfWorkSimple;

        #endregion

        #region Constructor

        public RepoMascotas(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            _unitOfWorkSimple = unitOfWork as UnitOfWorkBase;
        }

        #endregion

        #region Metodos

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWorkSimple;
            }
        }

        public ResultPrimitiveValue<int> TotalAdoptadas()
        {
            var result = new ResultPrimitiveValue<int>();
            try
            {
                var entidad = _unitOfWorkSimple.Mascotas.Count(ele => ele.Estado.ToUpper() == Mascota.KeyCodeEstadoAdoptado);
                result.Valor = entidad;
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                // ToDo Pendiente para controlar excepcion de dominio
                result.Errors.Add(mensaje);
            }
            return result;
        }

        public ResultPrimitiveValue<int> TotalPendientesAdopcion()
        {
            var result = new ResultPrimitiveValue<int>();
            try
            {
                var entidad = _unitOfWorkSimple.Mascotas.Count(ele => ele.Estado.ToUpper() == Mascota.KeyCodeEstadoPendiente);
                result.Valor = entidad;
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
            if (_unitOfWorkSimple == null) return;
            _unitOfWorkSimple.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion      

    }
}
