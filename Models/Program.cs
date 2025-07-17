using MandrilAPI.Controllers;
using MandrilAPI.DatabaseContext;
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
            builder.Services.AddDbContext<MandrilDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
            
            builder.Services.AddControllers(options => 
            {
               options.Filters.Add<JsonFilterExeption>();})
                .ConfigureApiBehaviorOptions(options =>
            {
             options.SuppressModelStateInvalidFilter = false;
            });
            
         //   builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = false);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IMandrilAndSkillsReadRepository, MandrilSkillsReadRepository>();
            builder.Services.AddScoped<IMandrilAndSkillsWriteRepository, MandrilSkillsWriteRepository>();
           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            //app.UseMiddleware<ExepcionesJsonMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            app.MapControllers();
         
            app.Run();
            
            
            
            
            
        }
    }
}
