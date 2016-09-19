using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TuMascota.AccesoDatos.Test;
using TuMascota.AccesoDatos.Test.Utils.Core;
using TuMascota.Aplicacion.Modulos.Core.Usuarios;
using TuMascota.Aplicacion.Modulos.Core.Usuarios.Dtos;
using TuMascota.Aplicacion.Modulos.Core.Usuarios.Impl;
using UIBASOFT.Base.Comunes.ResultOperation;
using UIBASOFT.Base.Infraestructura.Crosscuting.Security;

namespace TuMascota.Aplicacion.Test.Test.Core
{
    /// <summary>
    /// Summary description for AppServicesUsuariosTest
    /// </summary>
    [TestClass]
    public class AppServicesUsuariosTest : AppServicesTest
    {
        private static IServicesUsuarios CreateUsuariosServicesApp()
        {
            var mockSecurityService = new Mock<ISecurityService>();
            mockSecurityService.Setup(c => c.Login("uialberto", "12345")).Returns(new ResultOperation());
            var appservice = new ServicesUsuarios(RepoUsuariosUtilsTest.CreateUsuariosRepository())
            {
                SecurityService = mockSecurityService.Object
            };
            return appservice;
        }
        [TestMethod]
        public async Task RegistrarTest()
        {
            #region Arrange

            var user = new UsuarioDto()
            {
                Nombres = UtilitariosBase.NewGuid().Substring(1, 10),
                Apellidos = UtilitariosBase.NewGuid().Substring(1, 10),
                Username = UtilitariosBase.NewGuid().Substring(1, 10),
                Password = UtilitariosBase.NewGuid().Substring(1, 8),
                Email = UtilitariosBase.NewGuid().Substring(1, 10),

            };

            #endregion

            #region Act

            var target = CreateUsuariosServicesApp();
            var res = await target.Registrar(user);

            #endregion

            #region Assert

            Assert.IsTrue(!res.HasErrors);

            #endregion


        }
    }
}
