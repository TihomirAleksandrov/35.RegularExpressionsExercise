using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=\s|^)[\dA-Za-z]{1}[\w\.\-]*?[\dA-Za-z]\@[\dA-Za-z]+\-*[A-Za-z]+(\.{1}[A-Za-z]+\-*[A-Za-z]+)+";

            string input = Console.ReadLine();

            MatchCollection emails = Regex.Matches(input, pattern);

            foreach (Match match in emails)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
