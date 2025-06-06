
using MandrilAPI.Controllers;
using MandrilAPI.Models;
using MandrilAPI.Models.Service;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            MandrilContext contexto;
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //ASP.NET administra las instancias puestas en la inyeccion de dependencias es decir cada vez que quiera una instanica
            //Para usar el servicio solo necesito llamarlo desde el contructor de la clase.
            builder.Services.AddDbContext<MandrilContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
            
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            //Se inician todas las listas staticas que consumira la api
             Habilidad.IniciarListaHabilidades();
             MandrilDataStore.InicializarMandrilesData();

        
            
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            //la logica del programa funciona/ seguir viendo el video
            
            //bug no se esta mostrando las habilidades en el orden correcto parece ser que se esta duplicando bola de fuego
            //bug resuelto verificar comentarios en la clase Habilidades
            
                    //TESTES
                    
                    
           // var mandril = new MandrilDataStore();
           //var habilidad = new Habilidad();
           
                 // Console.WriteLine(mandril.UsarListaMandriles()[2].HabilidadMandril()[0].Nombre);
                // Console.WriteLine(Habilidad.SeleccionarHabilidad()[1].Nombre);
             
            

               
                
            app.Run();
            
            
            
            
            
        }
    }
}
