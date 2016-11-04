using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TuMascota.AccesoDatos.Test;
using UIBASOFT.Base.Comunes.Utils.Extensions.Reflection;
using UIBASOFT.Base.Infraestructura.Crosscuting.NetFramework.Operations.Adapter;
using UIBASOFT.Base.Infraestructura.Crosscuting.NetFramework.Operations.FileManagement;
using UIBASOFT.Base.Infraestructura.Crosscuting.NetFramework.Operations.Logging;
using UIBASOFT.Base.Infraestructura.Crosscuting.NetFramework.Operations.Password;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.Adapter;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.FileManagement;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.Logging;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.Password;

namespace TuMascota.Aplicacion.Test
{
    /// <summary>
    /// Summary description for AppServices
    /// </summary>
    [TestClass]
    public partial class AppServicesTest
    {
        [AssemblyInitialize]
        public static void TestAssemblyInitialize(TestContext context)
        {
            PasswordCipherFactory.SetCurrent(new Pbkdf2PasswordCipherFactory());
        }
        public void DetachObject(object obj)
        {
        }
        [TestInitialize]
        public void TestInitialize()
        {
            UnitOfWorkTestUtils.RestartUnitOfWork();
        }

    }
}
