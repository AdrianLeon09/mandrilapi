using MandrilAPI.Aplication.Interfaces;
using MandrilAPI.Infrastructure.DatabaseContext;
using MandrilAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MandrilDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
            
            builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = false);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IMandrilSkillsReadRepository, MandrilSkillsReadRepository>();
            builder.Services.AddScoped<IMandrilSkillsWriteRepository, MandrilSkillsWriteRepository>();
           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            app.MapControllers();
         
            app.Run();
            
            
            
            
            
        }
    }
}
