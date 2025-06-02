
using MandrilAPI.Models;
using MandrilAPI.Models.Service;

namespace MandrilAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

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
                        ContextDB contextDb = new ContextDB();
                        
            
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
