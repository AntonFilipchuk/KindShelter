using API.Mapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        IServiceCollection services = builder.Services;

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        ConfigureServices(ref services, in builder);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        //To display images
        app.UseStaticFiles();
        app.UseCors("CorsPolicy");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    public static void ConfigureServices(
        ref IServiceCollection services,
        in WebApplicationBuilder builder
    )
    {
        services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });
        ;

        services.AddAutoMapper(
            typeof(PetMapProfile),
            typeof(ProductMapProfile),
            typeof(BreedMapProfile)
        );

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        string? ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ShelterContext>(
            dbContextOptions =>
                dbContextOptions.UseSqlite(
                    ConnectionString,
                    b => b.MigrationsAssembly("Infrastructure")
                )
        );

        services.AddScoped<IShelterRepository, ShelterRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}
