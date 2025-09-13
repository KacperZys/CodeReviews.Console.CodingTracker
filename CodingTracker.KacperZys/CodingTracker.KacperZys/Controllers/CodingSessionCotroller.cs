using CodingTracker.KacperZys.Exceptions;
using CodingTracker.KacperZys.Model;
using Spectre.Console;

namespace CodingTracker.KacperZys.Controllers;
internal class CodingSessionCotroller
{
    public string CalculateDuration(CodingSession newSession)
    {
        TimeSpan duration = (newSession.EndTime - newSession.StartTime);
        string formattedDuration = String.Format("{0:D2}", (int)duration.TotalHours);

        return formattedDuration;
    }

    public CodingSession AskForSessionParams()
    {
        CodingSession newSession = new CodingSession();
        AnsiConsole.MarkupLine("[yellow]Only [[YYYY-MM-DD]] format will be accepted![/]");
        newSession.StartTime = Validation.DateValidation(AnsiConsole.Ask<string>("Enter starting date: "));
        AnsiConsole.MarkupLine("[yellow]Only [[YYYY-MM-DD]] format will be accepted![/]");
        newSession.EndTime = Validation.DateValidation(AnsiConsole.Ask<string>("Enter ending date: "));
        newSession.Duration = CalculateDuration(newSession);

        if (TimeSpan.Parse(newSession.Duration).TotalHours < 0)
        {
            AnsiConsole.MarkupLine("[red]Ending Date cannot be earlier than Starting Date.");
            throw new WrongDateException();
        }

        return newSession;
    }
}
