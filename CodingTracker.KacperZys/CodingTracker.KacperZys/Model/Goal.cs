namespace CodingTracker.KacperZys.Model;
internal class Goal
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int GoalTime { get; set; }
    public string HowFarToReach { get; set; } = "";
    public double HoursPerDay { get; set; }
}
