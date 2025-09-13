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
}
