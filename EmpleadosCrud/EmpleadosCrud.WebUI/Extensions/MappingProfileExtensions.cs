using AutoMapper;
using EmpleadosCrud.Entities.Entities;
using EmpleadosCrud.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadosCrud.WebUI.Extensions
{
    public class MappingProfileExtensions: Profile
    {
        public MappingProfileExtensions()
        {
            CreateMap<EmpleadoViewModel, tbEmpleados>().ReverseMap();
        }
    }
}
