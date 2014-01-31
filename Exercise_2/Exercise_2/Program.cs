//Exercise 02
//Chris Barcroft

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            PurchasePrice sodaPrice = new PurchasePrice(35);
            CanRack rack = new CanRack();

            Console.WriteLine("Welcome to the .NET C# Soda Vending Machine.");
            Console.Write("Please insert {0} cents: ", sodaPrice.Price);
            int moneyInserted = int.Parse(Console.ReadLine());
            Console.WriteLine("You have inserted {0} cents", moneyInserted);
            Console.WriteLine("Thanks.  Here is your soda.");

            //Set up flavor list
            ArrayList flavors = rack.Flavors;

            //Randomly choose flavor and notify user 
            Random rnd = new Random();
            string randomFlavor = (string)flavors[rnd.Next(flavors.Count)];
            Console.WriteLine("Fate has decreed that you shall receive: {0}", randomFlavor);

            //Dispense the can (if possible)
            rack.RemoveACanOf(randomFlavor);

            //OPTIONAL:  Adding code to attempt removing too many cans from machine.
            Console.WriteLine("JACKPOT! You win all the cans of {0}!", randomFlavor);

            rack.RemoveACanOf(randomFlavor);
            rack.RemoveACanOf(randomFlavor);
            rack.RemoveACanOf(randomFlavor);
        }
    }
}