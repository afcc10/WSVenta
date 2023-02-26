using Business.Contract;
using Business.Implement;
using DataAccess.Core.Contract;
using DataAccess.Core.Implements;
using DataAccess.Models;
using DataAccess.Models.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRepository(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }

        public static IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddAutoMapper(typeof(ClienteProfileMap));

            return services;
        }

        public static IServiceCollection AddDbContext(IServiceCollection services, string DefaultConnection)
        {
            services.AddDbContext<VentaRealContext>(options => options.UseSqlServer(DefaultConnection, b => b.MigrationsAssembly("VentaReal")));
            return services;
        }
    }
}
