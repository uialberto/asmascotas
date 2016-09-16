using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using TuMascota.AccesoDatos;
using TuMascota.AccesoDatos.Modulos.Core.Mascotas;
using TuMascota.AccesoDatos.Modulos.Core.Usuarios;
using TuMascota.Aplicacion.Helpers;
using TuMascota.Aplicacion.Modulos.Core.Mascotas;
using TuMascota.Aplicacion.Modulos.Core.Mascotas.Impl;
using TuMascota.Aplicacion.Modulos.Core.Mascotas.Repo;
using TuMascota.Aplicacion.Modulos.Core.Usuarios;
using TuMascota.Aplicacion.Modulos.Core.Usuarios.Impl;
using TuMascota.Aplicacion.Modulos.Core.Usuarios.Repo;
using UIBASOFT.Base.Infraestructura.Transversales.IoContainer.Dependency;
using UIBASOFT.Base.Infraestructura.Transversales.IoContainer.Dependency.Unity;

namespace TuMascota.Aplicacion
{
    public class Bootstrapper
    {
        public static void Initialise()
        {
            InitialiseIoC();


            #region DataAccess


            #region UnitOfWork

            var connectionString = ConfigurationManager.ConnectionStrings["MascotaModelContainer"];
            if (connectionString == null || string.IsNullOrEmpty(connectionString.ConnectionString))
                throw new ConfigurationErrorsException("ConnectionString Key: MascotaModelContainer");

            var iocUnityManager = IoC.Container as IocUnityManager;
            if (iocUnityManager != null)
            {
                var rootUnityContainer = iocUnityManager.RootContainer;
                rootUnityContainer.RegisterType<IUnitOfWork, UnitOfWorkBase>(new TransientLifetimeManager(), new InjectionConstructor(connectionString.ConnectionString));
            }


            #endregion


            #region Repositorios           

            IoC.Container.RegisterType(typeof(IRepoMascotas), typeof(RepoMascotas));
            IoC.Container.RegisterType(typeof(IRepoUsuarios), typeof(RepoUsuarios));

            #endregion

            #endregion

            #region Aplicacion

            IoC.Container.RegisterType(typeof(IServicesUsuarios), typeof(ServicesUsuarios));
            IoC.Container.RegisterType(typeof(IServicesMascotas), typeof(ServicesMascotas));

            #endregion

        }
        private static void InitialiseIoC()
        {
            IoC.SetContainer(new IoCUnity());
        }
    }
}
