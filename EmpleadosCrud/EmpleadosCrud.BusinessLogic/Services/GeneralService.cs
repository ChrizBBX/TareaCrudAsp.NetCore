using EmpleadosCrud.DataAccess.Repository;
using EmpleadosCrud.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosCrud.BusinessLogic.Services
{
    public class GeneralService
    {
        private readonly EmpleadosRepository _empleadosRepository;

        public GeneralService(EmpleadosRepository empleadosRepository)
        {
            _empleadosRepository = empleadosRepository;
        }

        #region Empleados
        public IEnumerable<tbEmpleados> ListadoEmpleados(out string error)
        {
            error = string.Empty;
            try
            {
                return _empleadosRepository.List();
            }
            catch (Exception e)
            {

                error = e.Message;
                return Enumerable.Empty<tbEmpleados>();
            }
        }

        public int AgregarEmpleado(tbEmpleados empleado)
        {
            try
             {
                return _empleadosRepository.Insert(empleado);
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public tbEmpleados ObtenerEmpleadoPorId(int id)
        {
           
            try
            {
                return _empleadosRepository.find(id);
            }
            catch (Exception e)
            {
               
                return null;
            }
        }
        public bool EditarEmpleado(tbEmpleados empleado, out string error)
        {
            error = string.Empty;
            try
            {
                var empleadoExistente = _empleadosRepository.find(empleado.empe_Id);
                if (empleadoExistente == null)
                {
                    error = "El empleado que desea editar no existe.";
                    return false;
                }

                empleadoExistente.empe_Nombres = empleado.empe_Nombres;
                empleadoExistente.empe_Apellidos = empleado.empe_Apellidos;
                empleadoExistente.empe_Sexo = empleado.empe_Sexo;
                empleadoExistente.empe_Telefono = empleado.empe_Telefono;

                _empleadosRepository.Update(empleadoExistente);

                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
        }

        public tbEmpleados ObtenerEmpleadoPorIdDelete(int id)
        {

            try
            {
                return _empleadosRepository.Delete(id);
            }
            catch (Exception e)
            {

                return null;
            }
        }
        #endregion
    }
}
