﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviors;
using System.Reflection;

namespace SchoolProject.Core
{
    public static class ModuleCoreDependancies
    {
        public static IServiceCollection AddCoreDependancies(this IServiceCollection services)
        {
            // Configration of meditator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // Configration of AutoMapper 
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}