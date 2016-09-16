using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using UIBASOFT.Base.Core.Security;
using UIBASOFT.Base.Infraestructura.Crosscuting.Email;
using UIBASOFT.Base.Infraestructura.Crosscuting.NetFramework.Operations.Adapter;
using UIBASOFT.Base.Infraestructura.Crosscuting.NetFramework.Operations.Email;
using UIBASOFT.Base.Infraestructura.Crosscuting.NetFramework.Operations.FileManagement;
using UIBASOFT.Base.Infraestructura.Crosscuting.NetFramework.Operations.Logging;
using UIBASOFT.Base.Infraestructura.Crosscuting.NetFramework.Operations.Password;
using UIBASOFT.Base.Infraestructura.Crosscuting.NetFramework.Security;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.Adapter;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.Email;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.FileManagement;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.FileManagement.Configuration.Sections;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.Password;
using UIBASOFT.Base.Infraestructura.Crosscuting.Security;
using UIBASOFT.Base.Infraestructura.Crosscuting.Security.Configuration.Sections;
using UIBASOFT.Base.Infraestructura.Transversales.IoContainer.Dependency.Unity;

namespace TuMascota.Aplicacion.Helpers
{
    public class IoCUnity : IocUnityManager
    {
        public IoCUnity()
        {

        }
        public IoCUnity(string nameDefaulIoContainerConfiguration, bool configureContainer)
            : base(nameDefaulIoContainerConfiguration, configureContainer)
        {

        }
        protected override void ConfigureRootContainer(IUnityContainer unityContainer)
        {

            base.ConfigureRootContainer(unityContainer);

            #region Componentes Transversales 

            unityContainer.RegisterType<IPasswordCipher, Pbkdf2PasswordCipher>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IPasswordCipherFactory, Pbkdf2PasswordCipherFactory>(new ContainerControlledLifetimeManager());

            #endregion

        }
    }
}
