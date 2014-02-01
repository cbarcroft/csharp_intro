//Exercise 03
//Chris Barcroft

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            PurchasePrice sodaPrice = new PurchasePrice(0.35m);
            CanRack rack = new CanRack();

            Console.WriteLine("Welcome to the .NET C# Soda Vending Machine.");
            Console.Write("Please insert {0:C}: ", sodaPrice.Price);

            //Accept user input
            decimal moneyInserted = decimal.Parse(Console.ReadLine());
            Console.WriteLine("You have inserted {0:C}", moneyInserted);
            if (moneyInserted >= sodaPrice.Price)
            {
                Console.WriteLine("Thanks.  Here is your soda.");

                Array flavors = Flavor.GetValues(typeof(Flavor));
                Random random = new Random();
                Flavor flavor = (Flavor)flavors.GetValue(random.Next(flavors.Length));

                Console.WriteLine("Fate has decreed that you shall receive: {0}", flavor);

                //Dispense the can (if possible)
                rack.RemoveACanOf(flavor);

            }
            else
            {
                Console.WriteLine("Insufficient funds!");
            }
        }
    }
}