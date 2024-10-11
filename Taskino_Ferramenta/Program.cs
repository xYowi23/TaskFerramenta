
using Microsoft.EntityFrameworkCore;
using Taskino_Ferramenta.Models;
using Taskino_Ferramenta.Repos;
using Taskino_Ferramenta.Services;

namespace Taskino_Ferramenta
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ParadisoGiovanninoContex>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseTest")));
            builder.Services.AddScoped<RepartoRepo>();
            builder.Services.AddScoped<ProdottoRepo>();
            builder.Services.AddScoped<RepartoService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
