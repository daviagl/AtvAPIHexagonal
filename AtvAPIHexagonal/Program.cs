
using AtvAPIHexagonal.Application;
using AtvAPIHexagonal.Domain;
using AtvAPIHexagonal.Infrastructure;

namespace AtvAPIHexagonal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IAlunoRepository, AlunoRepositoryMemory>();
            builder.Services.AddScoped<AlunoService>();

            builder.Services.AddScoped<ICursoRepository, CursoRepositoryMemory>();
            builder.Services.AddScoped<CursoService>();

            builder.Services.AddScoped<ICursoRepository, CursoRepositoryMemory>();
            builder.Services.AddScoped<CursoService>();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
