using Microsoft.Extensions.DependencyInjection;
using PatientApp.Infrastructure.Authentication;
using PatientApp.Interface.Common;
using PatientApp.Interface.Persistence;
using PatientApp.Persistence.Contexts;
using PatientApp.Persistence.Repositories;

namespace PatientApp.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}
