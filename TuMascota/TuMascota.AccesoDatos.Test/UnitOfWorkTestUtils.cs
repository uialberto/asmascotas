using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuMascota.Aplicacion;

namespace TuMascota.AccesoDatos.Test
{
    public static class UnitOfWorkTestUtils
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["MascotaModelContainer"].ConnectionString;
        private static UnitOfWorkBase _unitOfWork = null;
        public static UnitOfWorkBase GetUnitOfWork()
        {
            if (_unitOfWork != null) return _unitOfWork;
            _unitOfWork = new UnitOfWorkBase(ConnectionString);
            _unitOfWork.Configuration.ValidateOnSaveEnabled = false;
            return _unitOfWork;
        }
        public static void RestartUnitOfWork()
        {
            if (_unitOfWork != null)
                _unitOfWork.Dispose();
            _unitOfWork = new UnitOfWorkBase(ConnectionString);
        }
    }
}
