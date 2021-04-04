using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entity;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class ShopContextSeed
    {
        public static async Task SeedAsync(ShopContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.ServiceTypes.Any())
               {
                   var serviceTypesData = File.ReadAllText("../Infrastructure/Data/SeedData/serviceTypes.json");
                   var serviceTypes = JsonSerializer.Deserialize<List<ServiceType>>(serviceTypesData);

                   foreach(var item in serviceTypes)
                   {
                       context.ServiceTypes.Add(item);
                   }

                   await context.SaveChangesAsync();
               }

                if(!context.Services.Any())
               {
                   var serviceData = File.ReadAllText("../Infrastructure/Data/SeedData/service.json");
                   var services = JsonSerializer.Deserialize<List<Service>>(serviceData);

                   foreach(var item in services)
                   {
                       context.Services.Add(item);
                   }

                   await context.SaveChangesAsync();
               }

            }

            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ShopContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}