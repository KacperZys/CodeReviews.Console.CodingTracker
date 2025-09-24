using Dapper;

namespace CodingTracker.KacperZys.Model;
internal class AdvancedMenuModel
{
    internal List<CodingSession> FilterByDate(string startingDate, string endingDate, string order)
    {
        var connection = DatabaseConnection.DbConnect();
        string query = $"SELECT * FROM CodingSessions WHERE StartTime >= @StartTime AND EndTime <= @EndTime ORDER BY StartTime {order}";
        CodingSession session = new();
        session.StartTime = DateTime.Parse(startingDate);
        session.EndTime = DateTime.Parse(endingDate);
        var codingSessions = connection.Query<CodingSession>(query, session);

        return codingSessions.ToList();
    }
}
