using System;
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
            string[] inputArr = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);  // Returns all non-empty elements
            Command = inputArr[0];
            if (inputArr.Length > 1) Key = inputArr[1];
            if (inputArr.Length > 2) Members = [.. inputArr[2..]];  // Sets members to all elements from index 2 and beyond. 
        }
    }
}