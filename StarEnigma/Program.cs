using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\@{1}(?<name>[A-Za-z]+)[^\@\-\!\:\>]*?\:(?<population>\d+)[^\@\-\!\:\>]*?\!(?<attack>[A|D])\![^\@\-\!\:\>]*?\-\>(?<soldiers>\d+)";

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            int inputNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputNum; i++)
            {
                string message = Console.ReadLine();

                string code = DecryptMessage(message);

                Match match = Regex.Match(code, pattern);

                if (match.Success)
                {
                    if (match.Groups["attack"].Value == "A")
                    {
                        attackedPlanets.Add(match.Groups["name"].Value);
                    }
                    else
                    {
                        destroyedPlanets.Add(match.Groups["name"].Value);
                    }
                }
            }

            attackedPlanets.Sort();
            destroyedPlanets.Sort();


            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            
            foreach (string name in attackedPlanets)
            {
                Console.WriteLine($"-> {name}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (string name in destroyedPlanets)
            {
                Console.WriteLine($"-> {name}");
            }
        }

        static string DecryptMessage(string message)
        {
            int counter = 0;
            char[] chars = message.ToCharArray();

            foreach (char c in chars)
            {
                switch (c)
                {
                    case 'S':
                    case 's':
                    case 'T':
                    case 't':
                    case 'A':
                    case 'a':
                    case 'R':
                    case 'r':
                        counter++;
                        break;
                }
            }

            StringBuilder code = new StringBuilder();

            for (int i = 0; i < chars.Length; i++)
            {
                int charCode = Convert.ToInt32(chars[i]);
                char newChar =(char)(charCode - counter);

                code.Append(newChar);
            }

            return code.ToString();
        }
    }
}
