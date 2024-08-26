using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Application.Profiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureAppllicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            // : Specifically registers AutoMapper to use profiles found in the assembly where MappingProfile is located. 
            // It's a precise way to configure AutoMapper, especially useful when you want to control or limit the profile discovery to certain assemblies
            // services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Registers AutoMapper and automatically discovers all profiles in the currently executing assembly. 
            // This is more general and convenient if you want AutoMapper to find all profiles within the same assembly without specifying each profile explicitly.

            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
        
    }
}