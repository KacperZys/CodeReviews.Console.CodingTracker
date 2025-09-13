namespace CodingTracker.KacperZys.Exceptions;
public class WrongDateException : Exception
{
    public WrongDateException()
        : base("Ending Date cannot be earlier than Starting Date")
    { }

    public WrongDateException(string message)
        : base(message)
    { }

    public WrongDateException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
