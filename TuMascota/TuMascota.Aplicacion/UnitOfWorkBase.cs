using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuMascota.AccesoDatos;
using TuMascota.AccesoDatos.DataModels;

namespace TuMascota.Aplicacion
{
    public class UnitOfWorkBase : MascotaModelContainer, IUnitOfWork
    {
        public UnitOfWorkBase(string dbContext) : base(dbContext)
        {

        }
        public static UnitOfWorkBase Create(string dbContext)
        {
            return new UnitOfWorkBase(dbContext);
        }
    }
}
