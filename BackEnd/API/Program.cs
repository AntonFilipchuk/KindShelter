using System.Text.Json.Serialization;
using API.Mapper;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

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
        CreateDatabase(app);

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
            typeof(CityMapProfile),
            typeof(AdressMapProfile),
            typeof(BreedMapProfile),
            typeof(AnimalMapProfile)
        );
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        string? ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ShelterContext>(
            dbcontextOptions =>
                dbcontextOptions.UseSqlite(
                    ConnectionString,
                    b => b.MigrationsAssembly("Infrastructure")
                )
        );

        services.AddScoped<IShelterRepository, ShelterRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }

    private static void CreateDatabase(WebApplication app)
    {
        using (var scope = app.Services.CreateAsyncScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ShelterContext>();
            ShelterContextRandomSeed scr = new ShelterContextRandomSeed(context);
            scr.RandomSeed();
        }
    }
}
