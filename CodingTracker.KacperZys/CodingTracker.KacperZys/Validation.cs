using Spectre.Console;
using System.Globalization;

namespace CodingTracker.KacperZys;
internal static class Validation
{
    public static DateTime DateValidation(string dateToValidate)
    {
        string[] formats = ["yyyy-MM-dd HH:mm", "HH:mm"];

        while (true)
        {
            if (DateTime.TryParseExact(dateToValidate, formats, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime correctDate))
            {
                return correctDate;
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Wrong date format! Try again.[/]");
                AnsiConsole.MarkupLine("\n[yellow]Only [[HH:mm]] or [[YYYY-MM-DD HH:mm]] format will be accepted![/]");
                dateToValidate = AnsiConsole.Ask<string>("Enter date: ");
            }
        }
    }
}
