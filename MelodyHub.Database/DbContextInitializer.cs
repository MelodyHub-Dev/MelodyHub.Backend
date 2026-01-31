namespace MelodyHub.Database;

public class DbContextInitializer
{
    public static void Initialize(MelodyHubDbContext context)
    {
        context.Database.EnsureCreated();
    }
}
