using Sample.Data.Entities;
using Sample.Data;

namespace Sample.Api;

public static class DbSeed
{
    public static async Task SeedDatabase(IServiceProvider serviceProvider)
    {
        await using AsyncServiceScope scope = serviceProvider.CreateAsyncScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await dbContext.Database.EnsureCreatedAsync();

        if (!dbContext.People.Any())
        {
            dbContext.People.Add(
                new Person
                {
                    Name = "John Doe"
                });

            await dbContext.SaveChangesAsync();
        }
    }
}
