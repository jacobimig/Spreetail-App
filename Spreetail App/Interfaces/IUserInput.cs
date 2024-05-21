namespace Spreetail_App.Interfaces
{
    public class IUserInput
    {
        string Command { get; }
        string? Key { get; }
        HashSet<string>? Members { get; }
    }
}
