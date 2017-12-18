using System;
using AutoMapper;
using DFC.Application.Interfaces;
using DFC.Application.Services;
using DFC.Domain.Core.Events;
using DFC.Domain.Core.Handlers;
using DFC.Domain.Core.Interfaces;
using DFC.Domain.Interfaces;
using DFC.Infra.Data.Context;
using DFC.Infra.Data.Interface;
using DFC.Infra.Data.Repository;
using DFC.Infra.Data.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DFC.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IHandler<DomainNotification>, DomainNotificationHandler>();

            // Infra - Data
            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ApplicationContext>();

            //Application
            services.AddScoped<IBancoAppService, BancoAppService>();
            services.AddScoped<IContaAppService, ContaAppService>();
            services.AddScoped<IMovimentacaoAppService, MovimentacaoAppService>();

        }
    }
}
