using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayerLogic.Interface;
using BusinessLayerLogic.Mappings;
using BusinessLayerLogic.Services;
using Microsoft.Extensions.DependencyInjection;


namespace BusinessLayerLogic.Extensions
{
    public static class BLLServiceExtensions
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IPredmetService, PredmetService>();
            services.AddScoped<IStudentPredmetService, StudentPredmetService>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
