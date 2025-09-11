using CodingTracker.KacperZys.Model;
using Spectre.Console;

namespace CodingTracker.KacperZys.Controllers;
internal class MainMenuController
{
    MainMenuModel mainMenuModel = new MainMenuModel();
    public void ViewAll()
    {
        List<CodingSession> sessions = mainMenuModel.ViewAll();

        foreach (var session in sessions)
        {
            AnsiConsole.MarkupLine($"[yellow]ID: {session.Id}, Start Time: {session.StartTime}, End Time: {session.EndTime}, Duration: {session.Duration}[/]");
        }
    }

    public void CreateSession()
    {
        mainMenuModel.Create(AskForSessionParams());
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[green]Session added successfully.[/]");
    }

    private CodingSession AskForSessionParams()
    {
        CodingSession newSession = new CodingSession();
        newSession.StartTime = DateTime.Parse(AnsiConsole.Ask<string>("Enter starting date: "));
        newSession.EndTime = DateTime.Parse(AnsiConsole.Ask<string>("Enter ending date: "));
        newSession.Duration = (newSession.EndTime - newSession.StartTime).ToString();

        return newSession;
    }

    public void Delete()
    {
        int id = AnsiConsole.Ask<int>("Enter the ID of the session to delete: ");
        bool deletionStatus = mainMenuModel.Delete(new SessionRequest { Id = id });
        AnsiConsole.Clear();

        if (deletionStatus)
        {
            AnsiConsole.MarkupLine("[green]Session deleted successfully.[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]No session found with the provided ID.[/]");
        }
    }

    public void Modify()
    {
        int id = AnsiConsole.Ask<int>("Enter the ID of the session to modify: ");

        if (mainMenuModel.Exists(new SessionRequest { Id = id }) == false)
        {
            AnsiConsole.MarkupLine("[red]No session found with the provided ID.[/]");
            return;
        }

        CodingSession updatedSession = AskForSessionParams();
        updatedSession.Id = id;

        bool ModifyStatus = mainMenuModel.Modify(updatedSession);
        AnsiConsole.Clear();

        if (ModifyStatus)
        {
            AnsiConsole.MarkupLine("[green]Session modified successfully.[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Something went wrong. Please try again.[/]");
        }
    }
}
