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
        private static Dictionary<Type, KeyValuePair<MethodInfo, MethodInfo>> _testReposTypes = new Dictionary<Type, KeyValuePair<MethodInfo, MethodInfo>>();
        private static Dictionary<Type, MethodInfo> _testAppServicesTypes = new Dictionary<Type, MethodInfo>();

        /// <summary>
        /// Obtiene o Establece al contesto de Pruebas
        ///</summary>
        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void TestAssemblyInitialize(TestContext context)
        {
            PasswordCipherFactory.SetCurrent(new Pbkdf2PasswordCipherFactory());

            _testReposTypes = typeof(RepositoriesTest).Assembly.DefinedTypes.Where(types => types.Name.EndsWith("UtilsTest"))
                    .ToDictionary(
                        d =>
                        {
                            var createMethod = d.GetMethods().FirstOrDefault(m => m.Name.StartsWith("Create") && m.Name.EndsWith("Repository"));
                            if (createMethod == null)
                            {
                                throw new Exception($"El Tipo {d} no tienen ningún metodo Create...");
                            }

                            return createMethod.ReturnType;
                        },
                        d => new KeyValuePair<MethodInfo, MethodInfo>(d.GetMethod("GetInstance"),
                                d.GetMethods().FirstOrDefault(m => m.Name.StartsWith("Create") && m.Name.EndsWith("Repository"))));

            _testAppServicesTypes =
                typeof(AppServicesTest).Assembly.DefinedTypes.Where(
                    t =>  t.Name.StartsWith("AppServices") && t.Name.EndsWith("Test")
                      && t.IsDerivedFromType(typeof(AppServicesTest))
                      && t != typeof(AppServicesTest)
                      && t.GetMethods().Any(m => m.Name.StartsWith("Create") && m.Name.EndsWith("ServicesApp")))
                    .ToDictionary(
                        d =>
                        {
                            var firstOrDefault = d.GetMethods().FirstOrDefault(m => m.Name.StartsWith("Create") && m.Name.EndsWith("ServicesApp"));
                            return firstOrDefault != null ? firstOrDefault.ReturnType : null;
                        },
                        d => d.GetMethods().FirstOrDefault(m => m.Name.StartsWith("Create") && m.Name.EndsWith("ServicesApp")));
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
