using CodingTracker.KacperZys.Model;
using Spectre.Console;

namespace CodingTracker.KacperZys.Controllers;
internal static class SharedMenuMethods
{
    public static void DisplayWithTable(List<CodingSession> sessions)
    {
        var table = new Table();
        table.AddColumns("ID", "Start Time", "End Time", "Duration");

        foreach (var session in sessions)
        {
            table.AddRow(session.Id.ToString(), session.StartTime.ToString("yyyy-MM-dd HH:mm"), session.EndTime.ToString("yyyy-MM-dd HH:mm"), session.Duration);
        }

        table.Centered();
        AnsiConsole.Write(table);
    }

    public static void DisplayTotalAndAvg(List<CodingSession> sessions)
    {
        var table = new Table();
        table.AddColumns("Total Sessions", "Average Duration\n  Per Session");

        string avg = SharedMenuMethodsModel.GetAvg(sessions);
        string sum = SharedMenuMethodsModel.GetSum(sessions);

        table.AddRow(sum, avg);
        table.Centered();
        AnsiConsole.Write(table);
    }
}
