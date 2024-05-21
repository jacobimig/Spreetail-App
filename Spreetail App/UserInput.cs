using Spreetail_App.Interfaces;

namespace Spreetail_App
{
    public class UserInput : IUserInput
    {
        public string Command { get; private set; }
        public string? Key { get; private set; }
        public HashSet<string>? Members = new HashSet<string>();

        public UserInput(string input)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) throw new ArgumentNullException(Messages.ErrorNoInputProvided); // Thrown when input is null, empty, or is a whitespace character
            string[] inputArr = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);  // Returns all non-empty elements
            Command = inputArr[0];
            if (inputArr.Length > 1) Key = inputArr[1];
            if (inputArr.Length > 2)
            {
                foreach (var val in inputArr[2..]) // Add all other elements to members
                {
                    Members.Add(val);
                }
            }
        }
    }
}