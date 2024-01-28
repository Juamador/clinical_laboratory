using CLINICAL.Application.Interface;
using CLINICAL.Persistence.Context;
using CLINICAL.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Persistence.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection service)
        {
            service.AddSingleton<ApplicationDbContext>();
            service.AddScoped<IAnalysisRepository, AnalysisRepository>();
            return service; 
        }
    }
}
