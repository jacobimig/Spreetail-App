using Spreetail_App;
using Spreetail_App.Interfaces;

namespace SpreetailApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommands mvCommands = new Commands();
            bool isPromptOpen = true;
            
            while (isPromptOpen)  // Keep prompt open to allow the user to type more than one command
            {
                Console.Write(Messages.Precursor);  // Prefix all commands with "> "

                string input = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) continue; // Keep running even if input is empty, null, or has whitespace
                UserInput usrInput = new(input);

                switch (usrInput.Command) // Run appropriate command based on user input
                {
                    case "ADD":
                        Console.WriteLine(mvCommands.Add(usrInput.Key ?? string.Empty, usrInput.Members ?? new HashSet<string>()));
                        break;
                    case "KEYS":
                        Console.WriteLine(mvCommands.Keys());
                        break;
                    case "MEMBERS":
                        Console.WriteLine(mvCommands.Members(usrInput.Key ?? string.Empty));
                        break;
                    case "REMOVE":
                        Console.WriteLine(mvCommands.Remove(usrInput.Key ?? string.Empty, usrInput.Members ?? new HashSet<string>()));
                        break;
                    case "REMOVEALL":
                        Console.WriteLine(mvCommands.RemoveAll(usrInput.Key ?? string.Empty));
                        break;
                    case "CLEAR":
                        Console.WriteLine(mvCommands.Clear());
                        break;
                    case "KEYEXISTS":
                        Console.WriteLine(mvCommands.KeyExists(usrInput.Key ?? string.Empty));
                        break;
                    case "MEMBEREXISTS":
                        Console.WriteLine(mvCommands.MemberExists(usrInput.Key ?? string.Empty, usrInput.Members ?? new HashSet<string>()));
                        break;
                    case "ALLMEMBERS":
                        Console.WriteLine(mvCommands.AllMembers());
                        break;
                    case "ITEMS":
                       Console.WriteLine(mvCommands.Items());
                        break;
                    case "EXIT":
                        isPromptOpen = false;
                        break;
                    default:
                        Console.WriteLine(Messages.ErrorNoValidCommand);
                        break;
                }
            }
        }
    }
}