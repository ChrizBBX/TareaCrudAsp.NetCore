using AutoMapper;
using EmpleadosCrud.BusinessLogic.Services;
using EmpleadosCrud.Entities.Entities;
using EmpleadosCrud.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadosCrud.WebUI.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public EmpleadoController(GeneralService generalService,IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }
        [HttpGet("/Empledos/Listado")]
        public IActionResult Index()
        {
            var listado = _generalService.ListadoEmpleados(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<EmpleadoViewModel>>(listado);

            if (string.IsNullOrEmpty(error))
                ModelState.AddModelError("", error);
            return View(listadoMapeado);
        }

        [HttpGet("/Empleados/AgregarEmpleado")]
        public IActionResult AgregarEmpleado()
        {
            return View();
        }
        [HttpPost("/Empleados/AgregarEmpleado")]
        public IActionResult AgregarEmpleado(EmpleadoViewModel empleadoViewModel)
        {
            var empleado = _mapper.Map<tbEmpleados>(empleadoViewModel);
            var result = _generalService.AgregarEmpleado(empleado);


            return RedirectToAction("Index");
        }

        //[HttpGet("/Empleados/EditarEmpleados")]
        [HttpGet("/Empleados/Editar")]
        public IActionResult Editar(int id)
        {
            try
            {
                var empleado = _generalService.ObtenerEmpleadoPorId(id);
                if (empleado != null)
                {
                    return View(empleado);
                }
                else
                {
                    ModelState.AddModelError("", "No se encontró el empleado especificado");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al obtener el empleado: " + ex.Message);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("/Empleados/Editar")]
        public IActionResult Editar(tbEmpleados empleado)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var empleadoExistente = _generalService.ObtenerEmpleadoPorId(empleado.empe_Id);
                    if (empleadoExistente != null)
                    {
                        empleadoExistente.empe_Nombres = empleado.empe_Nombres;
                        empleadoExistente.empe_Apellidos = empleado.empe_Apellidos;
                        empleadoExistente.empe_Sexo = empleado.empe_Sexo;
                        empleadoExistente.empe_Telefono = empleado.empe_Telefono;

                        var resultado = _generalService.EditarEmpleado(empleadoExistente, out string error);
                        if (resultado)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Ocurrió un error al actualizar el empleado");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "No se encontró el empleado especificado");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocurrió un error al actualizar el empleado: " + ex.Message);
                }
            }
            return View(empleado);
        }

        [HttpGet("/Empleados/Eliminar")]
        public IActionResult Eliminar(int id)
        {
            var borrarEmpleado = _generalService.ObtenerEmpleadoPorIdDelete(id);
            return RedirectToAction("Index");
        }

    }
}
