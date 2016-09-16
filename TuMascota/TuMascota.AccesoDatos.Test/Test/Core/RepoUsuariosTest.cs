using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TuMascota.AccesoDatos.DataModels;
using TuMascota.AccesoDatos.Test.Utils.Core;

namespace TuMascota.AccesoDatos.Test.Test.Core
{
    /// <summary>
    /// Summary description for RepoUsuariosTest
    /// </summary>
    [TestClass]
    public class RepoUsuariosTest : RepositoriesTest
    {
        [TestMethod]
        public async Task CrearUsuario()
        {
            #region Arrange


            var user = new Usuario()
            {
                Username = UtilitariosBase.NewGuid(),
                Password = UtilitariosBase.NewGuid(),
                Email = UtilitariosBase.NewGuid(),
                Nombres = UtilitariosBase.NewGuid()
            };
            var res = await RepoUsuariosUtilsTest.CreateUsuario(user);

            #endregion

            #region Act

            var target = RepoUsuariosUtilsTest.CreateUsuariosRepository();
            var entityAdd = target.Obtener(user.IdUsuario);

            #endregion

            #region Assert

            Assert.IsNotNull(entityAdd);

            #endregion

        }

    }
}
