using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Extensions
{
    public static class Swagger
    {
        public static IServiceCollection AddSwag(this IServiceCollection services) //w extension methods zawsze pierwszym parametrem jest rozszerzany typ
        {                                                                          //ze słówkiem kluczowym "this"
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" }); //ctrl c/v z dokumentacji .net core, najbardziej podstawowa konfiguracja generatora dokumentacji
            });

            return services;
        }

        public static IApplicationBuilder UseSwag(this IApplicationBuilder app)
        {
            app.UseSwagger();       //tutaj dodajemy middleware, które zbierze informacje o API na potrzeby generowania dokumentacji
            app.UseSwaggerUI(c =>   //tutaj dodajemy middleware, które "postawi" endpoint z gotową dokumentacją (taką, jaką przeklikiwaliśmy na zajęciach)
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            return app;
        }
    }
}
