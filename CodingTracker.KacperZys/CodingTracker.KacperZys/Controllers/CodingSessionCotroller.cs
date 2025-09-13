using CodingTracker.KacperZys.Exceptions;
using CodingTracker.KacperZys.Model;
using Spectre.Console;

namespace CodingTracker.KacperZys.Controllers;
internal class CodingSessionCotroller
{
    public string CalculateDuration(CodingSession newSession)
    {
        TimeSpan duration = newSession.EndTime - newSession.StartTime;
        string formattedDuration = duration.ToString(@"hh\:mm");

        if (duration.TotalHours >= 24)
        {
            int totalHours = (int)duration.TotalHours;
            formattedDuration = $"{totalHours:D2}:{duration.Minutes:D2}";
        }

        return formattedDuration;
    }

    public CodingSession AskForSessionParams()
    {
        CodingSession newSession = new CodingSession();
        AnsiConsole.MarkupLine("[yellow]Only [[HH:mm]] or [[YYYY-MM-DD HH:mm]] format will be accepted![/]");
        newSession.StartTime = Validation.DateValidation(AnsiConsole.Ask<string>("Enter starting date: "));
        AnsiConsole.MarkupLine("[yellow]Only [[HH:mm]] or [[YYYY-MM-DD HH:mm]] format will be accepted![/]");
        newSession.EndTime = Validation.DateValidation(AnsiConsole.Ask<string>("Enter ending date: "));

        TimeSpan duration = newSession.EndTime - newSession.StartTime;

        if (duration.TotalMinutes < 0)
        {
            throw new WrongDateException();
        }

        newSession.Duration = CalculateDuration(newSession);

        return newSession;
    }
}
