using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml;

class Program
{
    static void Main()
    {
        // User Product list
        List<string> products = new List<string>();
        string? userInput;

        while (true)
        {
            Console.WriteLine("Enter a Productname in the format NAME-NNN (N=Integer 200-500), to quit type exit: ");
            userInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(userInput))
            {
                System.Console.WriteLine("The Field cant be left blank, to quit enter 'exit'");
                continue;
            }

            if (string.Equals(userInput, "exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            var match = Regex.Match(userInput, @"^([A-Z\ -])+(\d+)$", RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                System.Console.WriteLine("Error: Wrong format, try LETTERS-HYPHEN-NUMBER, Ex: CEE-400");
                continue;            
            }

            string letters = match.Groups[1].Value;
            string nums = match.Groups[2].Value;

            if (!int.TryParse(nums, out int number))
            {
             System.Console.WriteLine("Error: The number you entered is not an integer, Please enter a integer from 200-500");  
             continue; 
                
            }

            if (number < 200 || number > 500)
            {
                System.Console.WriteLine("Error: Enter a number in range 300-500, try again");
                continue;
            }
            products.Add(userInput);
            System.Console.WriteLine("Product added to list!");
        }

        products.Sort(StringComparer.OrdinalIgnoreCase);

        Console.WriteLine("Your sorted productlist:");
        products.ForEach(Console.WriteLine);
        // foreach (string product in products)
        // {
        //     Console.WriteLine(product);
        // }
    }
}