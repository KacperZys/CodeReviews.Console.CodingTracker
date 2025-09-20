using CodingTracker.KacperZys.Model;
using Spectre.Console;

namespace CodingTracker.KacperZys.Controllers;
internal class AdvancedMenuController
{
    AdvancedMenuModel advancedMenuModel = new();

    private (string startingDate, string endingDate) GetDates()
    {
        string startingDate = AnsiConsole.Ask<string>("Provide starting date");
        AnsiConsole.MarkupLine("\n[yellow]Only [[HH:mm]] or [[YYYY-MM-DD HH:mm]] format will be accepted![/]");
        Validation.DateValidation(startingDate);

        string endingDate = AnsiConsole.Ask<string>("Provide ending date");
        AnsiConsole.MarkupLine("\n[yellow]Only [[HH:mm]] or [[YYYY-MM-DD HH:mm]] format will be accepted![/]");
        Validation.DateValidation(endingDate);

        return (startingDate, endingDate);
    }

    private string GetOrder()
    {
        string order = AnsiConsole.Ask<string>("Choose order: Ascending, Descending");

        return Validation.OrderValidation(order);
    }

    internal void FilterByDate()
    {
        (string startingDate, string endingDate) = GetDates();
        string order = GetOrder();
        var codingSessions = advancedMenuModel.FilterByDate(startingDate, endingDate, order);
        SharedMenuMethods.DisplayWithTable(codingSessions);
    }
}
