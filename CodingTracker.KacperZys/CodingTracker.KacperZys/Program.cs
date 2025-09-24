using CodingTracker.KacperZys.Model;
using Dapper;
using static CodingTracker.KacperZys.View.MainMenu;

namespace CodingTracker.KacperZys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connection = DatabaseConnection.DbConnect();
            string query = "CREATE TABLE IF NOT EXISTS CodingSessions (Id INTEGER PRIMARY KEY AUTOINCREMENT, StartTime TEXT, EndTime TEXT, Duration TEXT)";
            connection.Execute(query);
            query = "CREATE TABLE IF NOT EXISTS CodingGoals (Id INTEGER PRIMARY KEY AUTOINCREMENT, StartTime TEXT, EndTime TEXT, GoalTime TEXT, HowFarToReach TEXT, HoursPerDay TEXT)";
            connection.Execute(query);
            Display();
        }
    }
}
