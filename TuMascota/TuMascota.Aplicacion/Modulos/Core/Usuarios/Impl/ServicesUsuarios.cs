using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TuMascota.AccesoDatos.DataModels;
using TuMascota.AccesoDatos.Modulos.Core.Usuarios;
using TuMascota.Aplicacion.CultureResources;
using TuMascota.Aplicacion.Modulos.Core.Usuarios.Dtos;
using UIBASOFT.Base.Aplicacion.Aplication.Services;
using UIBASOFT.Base.Comunes.ResultOperation;
using UIBASOFT.Base.Infraestructura.Crosscuting.Operations.Password;

namespace TuMascota.Aplicacion.Modulos.Core.Usuarios.Impl
{
    public class ServicesUsuarios : ApplicationService, IServicesUsuarios
    {
        protected readonly IRepoUsuarios ReposUsuarios;

        #region Constructor

        public ServicesUsuarios(IRepoUsuarios pReposUsuarios)
        {
            if (pReposUsuarios == null)
                throw new ArgumentNullException(nameof(pReposUsuarios));
            ReposUsuarios = pReposUsuarios;
        }

        #endregion

        #region Metodos

        public async Task<ResultPrimitiveValue<int>> Registrar(UsuarioDto dto)
        {
            var result = new ResultPrimitiveValue<int>();
            try
            {
                #region Validaciones

                if (string.IsNullOrWhiteSpace(dto.Nombres))
                {
                    result.Errors.Add(ServicesUsuariosResources.NombresRequerido);
                    return result;
                }
                if (string.IsNullOrWhiteSpace(dto.Apellidos))
                {
                    result.Errors.Add(ServicesUsuariosResources.ApellidosRequerido);
                    return result;
                }
                if (string.IsNullOrWhiteSpace(dto.Email))
                {
                    result.Errors.Add(ServicesUsuariosResources.EmailRequerido);
                    return result;
                }
                if (string.IsNullOrWhiteSpace(dto.Username))
                {
                    result.Errors.Add(ServicesUsuariosResources.UsernameRequerido);
                    return result;
                }
                if (string.IsNullOrWhiteSpace(dto.Password))
                {
                    result.Errors.Add(ServicesUsuariosResources.PasswordRequerido);
                    return result;
                }

                var uoW = ReposUsuarios.UnitOfWork as UnitOfWorkBase;

                var existeUsuario = uoW?.Usuarios.Any(ele => ele.Username.ToLower() == dto.Username.ToLower());
                var existeEmail = uoW?.Usuarios.Any(ele => ele.Email.ToLower() == dto.Email.ToLower());

                if (existeUsuario.HasValue && existeUsuario.Value)
                {
                    result.Errors.Add(ServicesUsuariosResources.UsuarioExiste);
                    return result;
                }

                if (existeEmail.HasValue && existeEmail.Value)
                {
                    result.Errors.Add(ServicesUsuariosResources.EmailExiste);
                    return result;
                }


                #endregion

                #region Proceso


                var cipher = PasswordCipherFactory.Create();

                if (cipher == null)
                    throw new Exception(nameof(cipher));


                var encryptPass = cipher.Encrypt(dto.Password);
                var usuario = new Usuario
                {
                    Nombres = dto.Nombres,
                    Apellidos = dto.Apellidos,
                    Email = dto.Email,
                    Password = encryptPass,
                    Username = dto.Username
                };
                result.Valor = await ReposUsuarios.Crear(usuario);

                #endregion

            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                // ToDo Pendiente para controlar excepcion de dominio
                result.Errors.Add(mensaje);
            }
            return result;
        }

        public ResultPrimitiveValue<bool> ValidarLogin(string usernameEmail, string password)
        {
            var result = new ResultPrimitiveValue<bool>();
            try
            {
                #region Validaciones

                if (string.IsNullOrWhiteSpace(usernameEmail))
                {
                    result.Errors.Add(ServicesUsuariosResources.UsernameEmailRequerido);
                    return result;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    result.Errors.Add(ServicesUsuariosResources.PasswordRequerido);
                    return result;
                }

                #endregion

                #region Proceso

                var uoW = ReposUsuarios.UnitOfWork as UnitOfWorkBase;

                var user = uoW?.Usuarios.FirstOrDefault(ele => ele.Username.ToLower() == usernameEmail.ToLower() ||
                                                               ele.Email.ToLower() == usernameEmail.ToLower());


                if (user == null)
                {
                    result.Errors.Add(ServicesUsuariosResources.UsuarioNoRegistrado);
                    return result;
                }

                password = password.Trim();
                var cipher = PasswordCipherFactory.Create();

                if (cipher == null)
                    throw new Exception(nameof(cipher));

                if (!cipher.ValidatePassword(password, user.Password))
                {
                    result.Errors.Add(ServicesUsuariosResources.UsuarioNoValido);
                    return result;
                }
                result.Valor = true;


                #endregion

            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                // ToDo Pendiente para controlar excepcion de dominio
                result.Errors.Add(mensaje);
            }
            return result;

        }

        #endregion

        #region Dispose

        protected void Dispose(bool disposing)
        {
            if (!disposing) return;
            ReposUsuarios.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion

    }
}
