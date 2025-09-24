using Dapper;

namespace CodingTracker.KacperZys.Model;
internal class MainMenuModel
{
    public List<CodingSession> ViewAll()
    {
        var connection = DatabaseConnection.DbConnect();
        string query = "SELECT * FROM CodingSessions";
        var codingSession = connection.Query<CodingSession>(query);

        return codingSession.ToList();
    }

    public void Create(CodingSession codingSession)
    {
        var connection = DatabaseConnection.DbConnect();
        string query = "INSERT INTO CodingSessions (StartTime, EndTime, Duration) VALUES (@StartTime, @EndTime, @Duration)";
        connection.Execute(query, codingSession);
    }

    public void Delete(SessionRequest sessionRequest)
    {
        var connection = DatabaseConnection.DbConnect();
        string query = "DELETE FROM CodingSessions WHERE Id = @Id";
        connection.Execute(query, sessionRequest);
    }

    public bool Modify(CodingSession session)
    {
        var connection = DatabaseConnection.DbConnect();
        string query = "UPDATE CodingSessions SET StartTime = @StartTime, EndTime = @EndTime, Duration = @Duration WHERE Id = @Id";

        return Convert.ToBoolean(connection.Execute(query, session));
    }

    public bool Exists(SessionRequest sessionRequest)
    {
        var connection = DatabaseConnection.DbConnect();
        string query = "SELECT COUNT(1) FROM CodingSessions WHERE Id = @Id";
        int count = connection.ExecuteScalar<int>(query, sessionRequest);
        return count > 0;
    }

    internal static void SetAGoal(int goalTime, DateTime startTime, DateTime endTime, string howFarToReach, double hoursPerDay)
    {
        var connection = DatabaseConnection.DbConnect();
        Goal goal = new Goal() { GoalTime = goalTime, StartTime = startTime, EndTime = endTime, HowFarToReach = howFarToReach, HoursPerDay = hoursPerDay };
        string query = "INSERT INTO CodingGoals (StartTime, EndTime, GoalTime, HowFarToReach, HoursPerDay) VALUES (@StartTime, @EndTime, @GoalTime, @HowFarToReach, @HoursPerDay)";
        connection.Execute(query, goal);
    }

    internal static List<Goal> GetAllGoals()
    {
        var connection = DatabaseConnection.DbConnect();
        string query = "SELECT * FROM CodingGoals";
        var goals = connection.Query<Goal>(query);

        return goals.ToList();
    }
}
