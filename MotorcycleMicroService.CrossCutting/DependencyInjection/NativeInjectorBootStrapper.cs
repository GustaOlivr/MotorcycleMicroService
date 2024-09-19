using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MotorcycleMicroService.Application.AutoMapping;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Application.Services;
using MotorcycleMicroService.Application.UseCases;
using MotorcycleMicroService.Domain.Interfaces.Repositories;
using MotorcycleMicroService.Domain.Interfaces.Services;
using MotorcycleMicroService.Persistense.Context;
using MotorcycleMicroService.Persistense.Repositories;

namespace MotorcycleMicroService.CrossCutting.DependencyInjection
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services, string connectionString)
        {
            // Contexto do EF Core
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            // Repositórios
            services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();

            // Serviços
            services.AddScoped<IMotorcycleService, MotorcycleService>();

            // AutoMapper
            services.AddAutoMapper(typeof(MotorcycleMappingProfile));

            // Casos de Uso
            services.AddScoped<ICreateMotorcycleUseCase, CreateMotorcycleUseCase>();
            services.AddScoped<IGetMotorcycleByIdUseCase, GetMotorcycleByIdUseCase>();
            services.AddScoped<IUpdateMotorcycleUseCase, UpdateMotorcycleUseCase>();
            services.AddScoped<IDeleteMotorcycleUseCase, DeleteMotorcycleUseCase>();
            services.AddScoped<IGetAllMotorcyclesUseCase, GetAllMotorcyclesUseCase>();
        }
    }
}
