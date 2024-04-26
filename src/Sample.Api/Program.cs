using JsonApiDotNetCore.Configuration;
using Microsoft.EntityFrameworkCore;
using Sample.Data;

namespace Sample.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        builder.Services
            .AddDbContext<AppDbContext>(options =>
            {
                string connectionString = "TODO: GetConnectionString()";

                options.UseInMemoryDatabase(connectionString);
            });

        builder.Services
            .AddJsonApi<AppDbContext>(options =>
            {
                options.IncludeExceptionStackTraceInErrors = true;
                options.IncludeRequestBodyInErrors = true;
                options.SerializerOptions.WriteIndented = true;
            });

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

        DbSeed.SeedDatabase(app.Services).Wait();

        app.Run();
    }
}
