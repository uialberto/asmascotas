using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuMascota.AccesoDatos;
using TuMascota.AccesoDatos.DataModels;
using TuMascota.AccesoDatos.Modulos.Core.Usuarios;
using UIBASOFT.Base.Comunes.ResultOperation;

namespace TuMascota.Aplicacion.Modulos.Core.Mascotas.Repo
{
    public class RepoUsuarios : IRepoUsuarios
    {
        #region Atributos

        private readonly UnitOfWorkBase _unitOfWorkSimple;

        #endregion

        #region Constructor

        public RepoUsuarios(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            _unitOfWorkSimple = unitOfWork as UnitOfWorkBase;
        }

        #endregion

        #region Metodos

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWorkSimple;
            }
        }


        public async Task<Usuario> Obtener(int id)
        {
            Usuario result = null;
            try
            {
                var entidad = await _unitOfWorkSimple.Usuarios.FindAsync(id);
                result = entidad;
                return result;
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                // ToDo Pendiente para controlar excepcion de dominio
            }
            return result;
        }

        public async Task<int> Crear(Usuario entity)
        {
            var result = -1;
            try
            {
                _unitOfWorkSimple.Usuarios.Add(entity);
                result = await _unitOfWorkSimple.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                // ToDo Pendiente para controlar excepcion de dominio
            }
            return result;
        }
        public async Task<Usuario> Editar(Usuario dto)
        {
            Usuario result = null;
            try
            {
                if (dto == null)
                    return result;
                var entity = await _unitOfWorkSimple.Usuarios.FindAsync(dto.IdUsuario);
                entity.Nombres = dto.Nombres;
                entity.Apellidos = dto.Apellidos;
                entity.Celular = dto.Celular;
                entity.Direccion = dto.Direccion;
                entity.Telefono = dto.Telefono;
                entity.Facebook = dto.Facebook;
                var rest = await _unitOfWorkSimple.SaveChangesAsync();
                result = entity;
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                // ToDo Pendiente para controlar excepcion de dominio
            }
            return result;
        }

        public async Task<int> Eliminar(int id)
        {
            var result = -1;
            try
            {
                var entity = await _unitOfWorkSimple.Usuarios.FindAsync(id);
                if (entity != null)
                {
                    _unitOfWorkSimple.Entry(entity).State = EntityState.Deleted;
                    result = await _unitOfWorkSimple.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                // ToDo Pendiente para controlar excepcion de dominio
            }
            return result;
        }

        #endregion

        #region Dispose

        protected void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_unitOfWorkSimple == null) return;
            _unitOfWorkSimple.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion

    }
}
