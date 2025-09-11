using Microsoft.Data.Sqlite;
using System.Text.Json.Nodes;

namespace CodingTracker.KacperZys.Model;
internal static class DatabaseConnection
{
    public static SqliteConnection DbConnect()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "appsettings.json");
        string jsonText = File.ReadAllText(path);
        JsonNode node = JsonNode.Parse(jsonText)!;

        string connectionString = node["ConnectionStrings"]!["DefaultConnection"]!.ToString();

        return new SqliteConnection(connectionString);
    }
}
