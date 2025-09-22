namespace CodingTracker.KacperZys.Model;
internal class SharedMenuMethodsModel
{
    internal static string GetAvg(List<CodingSession> sessions)
    {
        List<float> hours = new();

        foreach (var session in sessions)
        {
            string[] parts = session.Duration.Split(':');
            float hoursPart = float.Parse(parts[0]);
            int minutes = int.Parse(parts[1]);
            hoursPart += minutes / 60f;
            hours.Add(hoursPart);
        }

        float avgHours = hours.Average();

        return avgHours.ToString() + " h";
    }

    internal static string GetSum(List<CodingSession> sessions)
    {
        return sessions.Count.ToString();
    }
}
