using MandrilAPI.Controllers;
using MandrilAPI.DbContext;
using MandrilAPI.Interfaces;
using MandrilAPI.JsonFiltroExepcion;
using MandrilAPI.Middleware;
using MandrilAPI.Service;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //ASP.NET administra las instancias puestas en la inyeccion de dependencias es decir cada vez que quiera una instanica
            //Para usar el servicio solo necesito llamarlo desde el contructor de la clase.
            builder.Services.AddDbContext<MandrilDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

            builder.Services.AddControllers(options => 
            {
               options.Filters.Add<JsonExcepcionFilter>();})
                .ConfigureApiBehaviorOptions(options =>
            {
             options.SuppressModelStateInvalidFilter = true;
            });
            
         //   builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = false);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IMandrilAndSkillsReadRepository, MandrilSkillsReadRepository>();
            //builder.Services.AddTransient<ExepcionesJsonMiddleware>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        //    app.UseMiddleware<ExepcionesJsonMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            

            app.MapControllers();

            //la logica del programa funciona/ seguir viendo el video
            
            //bug no se esta mostrando las habilidades en el orden correcto parece ser que se esta duplicando bola de fuego
            //bug resuelto verificar comentarios en la clase Habilidades
         
            app.Run();
            
            
            
            
            
        }
    }
}
