using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuMascota.Aplicacion.Modulos.Core.Usuarios.Dtos;
using UIBASOFT.Base.Comunes.ResultOperation;
using UIBASOFT.Base.Infraestructura.Crosscuting.NetFramework.Security.IshtaranApiAuthentication.Dtos;

namespace TuMascota.Aplicacion.Modulos.Core.Usuarios
{
    public interface IServicesUsuarios : IDisposable
    {
        Task<ResultPrimitiveValue<int>> Registrar(UsuarioDto dto);

        ResultPrimitiveValue<bool> ValidarLogin(string usernameEmal, string password);

    }
}
