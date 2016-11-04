using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.Adapter;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.Email;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.FileManagement;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.Logging;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.Password;
using UIBASOFT.Base.Infraestructura.Transversales.IoContainer.Dependency;
using UIBASOFT.Base.Infraestructura.Transversales.IoContainer.Dependency.Unity;

namespace TuMascota.Aplicacion.Helpers
{
    public class CrosscuttingHelper
    {
        public static void Initialise()
        {
            var iocUnityManager = IoC.Container as IocUnityManager;
            if (iocUnityManager != null)
            {
                var passwordCipherFactory = iocUnityManager.Resolver<IPasswordCipherFactory>();
                PasswordCipherFactory.SetCurrent(passwordCipherFactory);
            }
        }
    }
}
