using CodingTracker.KacperZys.Exceptions;
using CodingTracker.KacperZys.Model;
using Spectre.Console;

namespace CodingTracker.KacperZys.Controllers;
internal class MainMenuController
{
    MainMenuModel mainMenuModel = new MainMenuModel();
    CodingSessionCotroller CodingSessionCotroller = new();
    public void ViewAll()
    {
        List<CodingSession> sessions = mainMenuModel.ViewAll();

        foreach (var session in sessions)
        {
            AnsiConsole.MarkupLine($"[yellow]ID: {session.Id}, Start Time: {session.StartTime.ToString("yyyy-MM-dd HH:mm")}, End Time: {session.EndTime.ToString("yyyy-MM-dd HH:mm")}" +
                $", Duration: {session.Duration} hours[/]");
        }
    }

    public void CreateSession()
    {
        while (true)
        {
            try
            {
                mainMenuModel.Create(CodingSessionCotroller.AskForSessionParams());
                break;
            }
            catch (WrongDateException ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
            }
        }


        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[green]Session added successfully.[/]");
    }

    public void Delete()
    {
        int id = AnsiConsole.Ask<int>("Enter the ID of the session to delete: ");

        if (mainMenuModel.Exists(new SessionRequest { Id = id }) == false)
        {
            AnsiConsole.MarkupLine("[red]No session found with the provided ID.[/]");
            return;
        }

        mainMenuModel.Delete(new SessionRequest { Id = id });
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[green]Session deleted successfully.[/]");
    }

    public void Modify()
    {
        int id = AnsiConsole.Ask<int>("Enter the ID of the session to modify: ");

        if (mainMenuModel.Exists(new SessionRequest { Id = id }) == false)
        {
            AnsiConsole.MarkupLine("[red]No session found with the provided ID.[/]");
            return;
        }

        CodingSession updatedSession = new();

        while (true)
        {
            try
            {
                updatedSession = CodingSessionCotroller.AskForSessionParams();
                break;
            }
            catch (WrongDateException ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
            }
        }


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
