using EmpleadosCrud.BusinessLogic.Services;
using EmpleadosCrud.DataAccess;
using EmpleadosCrud.DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosCrud.BusinessLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection service, string connectionString)
        {
            service.AddScoped<EmpleadosRepository>();
            TareacrudEmpleadoContext.BuildConnectionString(connectionString);
        }

        public static void BusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<GeneralService>();
        }

    }
}
