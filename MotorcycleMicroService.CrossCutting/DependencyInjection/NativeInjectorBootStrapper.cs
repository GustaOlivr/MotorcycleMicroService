using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MotorcycleMicroService.Application.AutoMapping;
using MotorcycleMicroService.Application.Interfaces.UseCases.CustomerUseCases;
using MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases;
using MotorcycleMicroService.Application.Services;
using MotorcycleMicroService.Application.UseCases;
using MotorcycleMicroService.Application.UseCases.CustomerUseCases;
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
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Serviços
            services.AddScoped<IMotorcycleService, MotorcycleService>();
            services.AddScoped<ICustomerService, CustomerService>();


            // AutoMapper
            services.AddAutoMapper(typeof(MotorcycleMappingProfile));
            services.AddAutoMapper(typeof(CustomerMappingProfile));

            // Casos de Uso
            services.AddScoped<ICreateMotorcycleUseCase, CreateMotorcycleUseCase>();
            services.AddScoped<IGetMotorcycleByIdUseCase, GetMotorcycleByIdUseCase>();
            services.AddScoped<IUpdateMotorcycleUseCase, UpdateMotorcycleUseCase>();
            services.AddScoped<IDeleteMotorcycleUseCase, DeleteMotorcycleUseCase>();
            services.AddScoped<IGetAllMotorcyclesUseCase, GetAllMotorcyclesUseCase>();

            services.AddScoped<ICreateCustomerUseCase, CreateCustomerUseCase>();
            services.AddScoped<IGetCustomerByIdUseCase, GetCustomerByIdUseCase>();

        }
    }
}
