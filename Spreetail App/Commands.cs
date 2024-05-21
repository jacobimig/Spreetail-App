using Spreetail_App.Interfaces;
using System.Text;
using System;
using System.Linq;

namespace Spreetail_App
{
    public class Commands : ICommands
    {
        private readonly Dictionary<string, HashSet<string>> _mvDictionary;

        public Commands()
        {
            _mvDictionary = new Dictionary<string, HashSet<string>>();
        }

        private string RenderList(IEnumerable<string> items)
        {
            StringBuilder result = new StringBuilder(); // Allows us to modify variable without creating a new string object in memory
            int index = 1;

            foreach (string item in items)
            {
                result.AppendLine(index + ") " + item);
                index++;
            }
            return result.ToString().TrimEnd();
        }

        private string RenderMembers()
        {
            StringBuilder result = new StringBuilder();
            int index = 1;
            var allMembers = _mvDictionary.SelectMany(x => x.Value); // Get all members from the entire dictionary

            foreach (string member in allMembers)
            {
                result.AppendLine(index + ") " + member);
                index++;
            }
            return result.ToString().TrimEnd();
        }

        public string Add(string key, HashSet<string> members)
        {
            if (string.IsNullOrEmpty(key)) return Messages.ErrorNoKeyProvided;
            if (members.Count == 0) return Messages.ErrorNoMemberProvided;
            if (!_mvDictionary.ContainsKey(key))
            {
                _mvDictionary[key] = [.. members];
                return Messages.Added;
            }
            bool membersAreValid = members.All(member => !_mvDictionary[key].Contains(member));
            if (!membersAreValid) return Messages.ErrorMemberExists;
            _mvDictionary[key] = [.._mvDictionary[key], .. members];
            return Messages.Added;
        }

        public string Keys()
        {
            if (_mvDictionary.Count == 0) return Messages.EmptySet;
            return RenderList(_mvDictionary.Keys);
        }

        public string Members(string key)
        {
            if (string.IsNullOrEmpty(key)) return Messages.ErrorNoKeyProvided;
            if (!_mvDictionary.ContainsKey(key)) return Messages.ErrorNoKeyExists;
            List<string> members = [.. _mvDictionary[key]];
            return RenderList(members);
        }

        public string Remove(string key, HashSet<string> member)
        {
            if (string.IsNullOrEmpty(key)) return Messages.ErrorNoKeyProvided;
            if (member.Count == 0) return Messages.ErrorNoMemberProvided;
            if (!_mvDictionary.ContainsKey(key)) return Messages.ErrorNoKeyExists;
            if (member.Count > 1) return Messages.ErrorTooManyMembers;
            if (!_mvDictionary[key].Contains(string.Join(", ", member))) return Messages.ErrorNoMemberExists;
            if (_mvDictionary[key].Count == 1)
            {
                _mvDictionary.Remove(key);
                return Messages.Removed;
            }
            _mvDictionary[key].Remove(string.Join("", member));
            return Messages.Removed;
        }

        public string RemoveAll(string key)
        {
            if (string.IsNullOrEmpty(key)) return Messages.ErrorNoKeyProvided;
            if (!_mvDictionary.ContainsKey(key)) return Messages.ErrorNoKeyExists;
            _mvDictionary.Remove(key);
            return Messages.Removed;
        }

        public string Clear()
        {
            _mvDictionary.Clear();
            return Messages.Cleared;
        }

        public string KeyExists(string key)
        {
            if (string.IsNullOrEmpty(key)) return Messages.ErrorNoKeyProvided;
            if (!_mvDictionary.ContainsKey(key)) return Messages.False;
            return Messages.True;
        }

        public string MemberExists(string key, HashSet<string> member)
        {
            if (string.IsNullOrEmpty(key)) return Messages.ErrorNoKeyProvided;
            if (member.Count == 0) return Messages.ErrorNoMemberProvided;
            if (member.Count > 1) return Messages.ErrorTooManyMembers;
            if (_mvDictionary.ContainsKey(key) && _mvDictionary[key].Contains(string.Join("", member))) return Messages.True;
            return Messages.False;
            }

        public string AllMembers()
        {
            if (_mvDictionary.Count == 0) return Messages.EmptySet;
            return RenderMembers();
        }

        public string Items()
        {
            if (_mvDictionary.Count == 0) return Messages.EmptySet;
            StringBuilder result = new StringBuilder();
            int index = 1;
            foreach (var item in _mvDictionary)
            {
                foreach (string member in item.Value)
                {
                    result.AppendLine(index + ") " + item.Key + ": " + member);
                    index++;
                }
            }
            return result.ToString().TrimEnd();
        }
    }
}
