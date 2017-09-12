using AutoMapper;
using Commercy.Infra.Data.Context;
using Commercy.Infra.Data.Repository;
using CommercyDomain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commercy.Infra.CrossCutting
{
    public class NativeInjectionBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // AutoMapper dependency
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // Infra - Data
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<CommercyContext>();
            
        }
    }
}
