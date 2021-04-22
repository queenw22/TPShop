using System.Linq;
using API.Errors;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class AppServicesExt
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceRepo, ServiceRepo>();
            services.AddScoped(typeof(IGenericRepo<>), (typeof(GenericRepo<>)));
            services.Configure<ApiBehaviorOptions>(options => 
               {
                   options.InvalidModelStateResponseFactory = actionContext =>
                   {
                       var errors = actionContext.ModelState
                          .Where(e => e.Value.Errors.Count > 0)
                          .SelectMany(x => x.Value.Errors)
                          .Select(x => x.ErrorMessage).ToArray();

                        var errorResponse = new ApiValidationError
                        {
                            Errors = errors
                        };

                        return new BadRequestObjectResult(errorResponse);
                   };

            
               });

               return services;
            
        }
        
    }
}