namespace Spreetail_App.Interfaces
{
    public interface ICommands
    {
        string Add(string key, HashSet<string> members);
        string Keys();
        string Members(string key);
        string Remove(string key, HashSet<string> member);
        string RemoveAll(string key);
        string Clear();
        string KeyExists(string key);
        string MemberExists(string key, HashSet<string> member);
        string AllMembers();
        string Items();
    }
}
