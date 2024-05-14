using Sample.Data.Entities;
using Sample.Data;

namespace Sample.Api;

public static class DbInit
{
    public static async Task Seed(IServiceProvider serviceProvider)
    {
        await using AsyncServiceScope scope = serviceProvider.CreateAsyncScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await dbContext.Database.EnsureCreatedAsync();

        if (!dbContext.People.Any())
        {
            dbContext.People.AddRange(
                new Person
                {
                    FirstName = "John",
                    LastName = "Doe",
                },
                new Person
                {
                    FirstName = "Anne",
                    LastName = "Woo",
                },
                new Person
                {
                    FirstName = "Missy",
                    LastName = "Jones",
                }
            );

            await dbContext.SaveChangesAsync();
        }
    }
}
