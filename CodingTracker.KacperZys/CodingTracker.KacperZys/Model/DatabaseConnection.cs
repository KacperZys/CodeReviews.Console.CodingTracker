using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace CodingTracker.KacperZys.Model;
internal static class DatabaseConnection
{
    public static SqliteConnection DbConnect()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        string connectionString = config.GetConnectionString("DefaultConnection")!;

        return new SqliteConnection(connectionString);
    }
}
