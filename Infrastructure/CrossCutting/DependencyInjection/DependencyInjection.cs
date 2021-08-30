using Application;
using Application.Interface;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Infrastructure.CrossCutting.UnitOfWork.Interface;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.CrossCutting.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryVeiculo, RepositoryVeiculo>();
            services.AddScoped<IServiceVeiculo, ServiceVeiculo>();
            services.AddScoped<IAppServiceVeiculo, AppServiceVeiculo>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            return services;
        }
    }      
}
