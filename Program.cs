using Microsoft.EntityFrameworkCore;
using mooexpress.Data;
using mooexpress.Interfaces;
using mooexpress.Repository;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Register repositories with scoped lifetime
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        builder.Services.AddScoped<IVendaRepository, VendaRepository>();
        builder.Services.AddScoped<IGadoRepository, GadoRepository>();
        builder.Services.AddScoped<IEndereco_entregaRepository, Endereco_entregaRepository>();
        builder.Services.AddScoped<IAvaliacoesRepository, AvaliacoesRepository>();
        builder.Services.AddScoped<IAnuncioRepository, AnuncioRepository>();

        // Configure DbContext with SQL Server
        builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Add IConfiguration as a singleton
        builder.Services.AddSingleton(builder.Configuration);

        // Configure CORS to allow any origin, method, and header
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.WithOrigins("http://localhost:5174") // Substitua pelo endereço do seu frontend
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            // Optionally, you can enable the Developer Exception Page
            // app.UseDeveloperExceptionPage();
        }

        // Apply the CORS policy
        app.UseCors("AllowSpecificOrigin");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        // Map controllers to endpoints
        app.MapControllers();

        app.Run();
    }
}
