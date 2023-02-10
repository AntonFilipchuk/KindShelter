using API.Errors;
using API.Mapper;
using API.Middleware;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        IServiceCollection services = builder.Services;

        ConfigureServices(ref services, in builder);

        var app = builder.Build();

        //Middleware for catching internal 500 errors
        app.UseMiddleware<ExceptionMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //Middleware for handling errors
        app.UseStatusCodePagesWithReExecute("/errors/{0}");

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
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // services
        //     .AddControllers()
        //     .AddJsonOptions(options =>
        //     {
        //         options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        //         options.JsonSerializerOptions.WriteIndented = true;
        //     });
        // ;

        services.AddAutoMapper(
            typeof(PetMapProfile),
            typeof(ProductMapProfile),
            typeof(BreedMapProfile),
            typeof(AnimalMapProfile)
        );

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        string? https_port = builder.Configuration.GetSection("https_port").Value;
        services.AddHttpsRedirection(options =>
        {
            options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
            options.HttpsPort = Int32.Parse(https_port!);
        });

        string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ShelterContext>(
            dbContextOptions =>
                dbContextOptions.UseSqlite(
                    connectionString,
                    b => b.MigrationsAssembly("Infrastructure")
                )
        );

        string? corsOrigin = builder.Configuration.GetSection("cors_Origin").Value;
        services.AddCors(
            options =>
                options.AddPolicy(
                    "CorsPolicy",
                    policy =>
                    {
                        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(corsOrigin!);
                    }
                )
        );

        services.AddScoped<IShelterRepository, ShelterRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        //Override behavior for handling 400 errors
        //api/products/f -> 400 error
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext.ModelState
                    .Where(errors => errors.Value!.Errors.Count > 0)
                    .SelectMany(x => x.Value!.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToArray();

                var errorResponse = new ApiValidationErrorResponse() { Errors = errors };
                return new BadRequestObjectResult(errorResponse);
            };
        });
    }
}
