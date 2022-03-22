using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants = new Dictionary<string, int>();

            string[] names = Console.ReadLine().Split(", ").ToArray();

            foreach (string name in names)
            {
                participants.Add(name, 0);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of race")
            {
                string name = GetName(input);
                int distance = GetDistance(input);

                if (participants.ContainsKey(name))
                {
                    participants[name] += distance;
                }
            }

            string[] ranking = participants
                .OrderByDescending(x => x.Value)
                .Take(3)
                .Select(x => x.Key)
                .ToArray();

            Console.WriteLine($"1st place: {ranking[0]}\n2nd place: {ranking[1]}\n3rd place: {ranking[2]}");
        }

        static string GetName(string input)
        {
            string pattern = @"[A-Za-z]+";
            MatchCollection matches = Regex.Matches(input, pattern);

            StringBuilder name = new StringBuilder();

            foreach (Match match in matches)
            {
                name.Append(match.Value);
            }

            return name.ToString();
        }

        static int GetDistance(string input)
        {
            string pattern = @"\d";
            MatchCollection matches = Regex.Matches(input, pattern);

            int distance = 0;

            foreach (Match match in matches)
            {
                distance += int.Parse(match.Value);
            }

            return distance;
        }
    }
}
