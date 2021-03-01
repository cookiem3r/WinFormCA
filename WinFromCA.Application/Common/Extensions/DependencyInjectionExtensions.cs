

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WinFromCA.Application.Common.Extensions
{
   
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationInjections(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
    
}
