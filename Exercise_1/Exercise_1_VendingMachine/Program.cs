using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1_VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            int sodaPriceCents = 35;

            Console.WriteLine("Welcome to the .NET C# Soda Vending Machine.");
            Console.Write("Please insert {0} cents: ", sodaPriceCents);
            string moneyInserted = Console.ReadLine();
            Console.WriteLine("You have inserted {0} cents", moneyInserted);
            Console.WriteLine("Thanks.  Here is your soda.");
        }
    }
}
