using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^\%(?<name>[A-Z][a-z]+)\%[^\|\%\.\$]*?\<(?<product>\w+)\>[^\|\%\.\$]*?\|(?<quantity>\d+)\|[^|%.$]*?(?<price>\d+(\.\d+)?)\$";

            decimal income = 0m;
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    decimal totalPrice = price * quantity;
                    income += totalPrice;
                    
                    Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
                }
            }

            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
