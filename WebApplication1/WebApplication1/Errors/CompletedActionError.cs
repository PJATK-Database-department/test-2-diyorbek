namespace WebApplication1.Errors;

public class CompletedActionError : Exception
{
    public CompletedActionError(int id)
    {
        Message = "Cannot delete Action(id=" + id + ") as it is completed!";
    }

    public override string Message { get; }
}