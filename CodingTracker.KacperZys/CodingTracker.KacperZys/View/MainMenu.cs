using CodingTracker.KacperZys.Controllers;
using Spectre.Console;
using static CodingTracker.KacperZys.Enumerations;

namespace CodingTracker.KacperZys.View;
internal static class MainMenu
{
    public static void Display()
    {
        MainMenuController mainMenuController = new MainMenuController();

        var options = Enum.GetValues<MenuOptions>();

        while (true)
        {
            var selection = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOptions>()
            .Title("What would you like to do?")
            .AddChoices(options));

            switch (selection)
            {
                case MenuOptions.View:
                    mainMenuController.ViewAll();
                    break;
                case MenuOptions.Create:
                    mainMenuController.CreateSession();
                    break;
                case MenuOptions.Modify:
                    mainMenuController.Modify();
                    break;
                case MenuOptions.Delete:
                    mainMenuController.Delete();
                    break;
                case MenuOptions.Timer:
                    mainMenuController.Timer();
                    break;
                case MenuOptions.Exit:
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
