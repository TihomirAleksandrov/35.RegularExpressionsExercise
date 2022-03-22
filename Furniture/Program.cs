using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^\>{2}(?<furniture>[A-Z]\w*)\<{2}(?<price>\d+\.*\d*)\!(?<quantity>\d+)?";

            List<string> furnitureNames = new List<string>();
            decimal totalPrice = 0m;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string name = match.Groups["furniture"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    furnitureNames.Add(name);
                    totalPrice += price * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");

            foreach (string name in furnitureNames)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
