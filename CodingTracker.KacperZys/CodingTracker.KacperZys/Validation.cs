using Spectre.Console;
using System.Globalization;

namespace CodingTracker.KacperZys;
internal static class Validation
{
    public static DateTime DateValidation(string dateToValidate)
    {
        while (true)
        {
            if (DateTime.TryParseExact(dateToValidate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime correctDate))
            {
                return correctDate;
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Wrong date format! Try again.[/]");
                AnsiConsole.MarkupLine("[yellow]Only [[YYYY-MM-DD]] format will be accepted![/]");
                dateToValidate = AnsiConsole.Ask<string>("Enter date: ");
            }
        }
    }
}
