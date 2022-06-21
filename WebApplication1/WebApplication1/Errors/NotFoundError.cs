namespace WebApplication1.Errors;

public class NotFoundError : Exception
{
    public override string Message { get; }

    public NotFoundError(string message)
    {
        Message = message;
    }
}