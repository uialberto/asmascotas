using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TuMascota.AccesoDatos.Test
{
    [TestClass]
    public class RepositoriesTest
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            UnitOfWorkTestUtils.RestartUnitOfWork();
        }
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
        }
    }
}
