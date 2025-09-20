using CodingTracker.KacperZys.Controllers;
using Spectre.Console;
using static CodingTracker.KacperZys.Enumerations;

namespace CodingTracker.KacperZys.View;
internal class AdvancedMenu
{
    internal void Advanced()
    {
        AdvancedMenuController advancedMenuController = new();
        var advancedOptions = Enum.GetValues<AdvancedOptions>();

        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<AdvancedOptions>()
            .Title("Select an action:")
            .AddChoices(advancedOptions));

        switch (selection)
        {
            case AdvancedOptions.FilterByDate:
                advancedMenuController.FilterByDate();
                break;
        }

    }
}
