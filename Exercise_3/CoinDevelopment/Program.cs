using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinDevelopment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test exercises for COIN class.");

            Coin coin_noParams = new Coin();
            testCoin(coin_noParams, "Parameterless constructor");

            Coin coin_Enumeral = new Coin(Coin.Denomination.DIME);
            testCoin(coin_Enumeral, "Denomation constructor - Dime");

            Coin coin_String = new Coin("Dime");
            testCoin(coin_String, "String constructor - Dime");

            Coin coin_Value10 = new Coin(.10m);
            testCoin(coin_Value10, "Value constructor - .10m");

            Coin coin_Value50 = new Coin(.50m);
            testCoin(coin_Value50, "Value constructor - .50m");

            Coin coin_badValue = new Coin(.12m);
            testCoin(coin_badValue, "Invalid Value constructor - .12m");

            Console.WriteLine("ADDITION: Dime + Half Dollar = {0:C}", coin_Value10.ValueOf + coin_Value50.ValueOf);
            Console.WriteLine("ADDITION: Value-constructed Dime + String-constructed Dime = {0:C}", coin_String.ValueOf + coin_Value10.ValueOf);
            Console.WriteLine("ADDITION: Denomination-constructed Dime + String-constructed Dime = {0:C}", coin_Enumeral.ValueOf + coin_Value10.ValueOf);
            Console.WriteLine("ADDITION: Denomination-constructed Dime + Slug = {0:C}", coin_Enumeral.ValueOf + coin_noParams.ValueOf);
        }

        public static void testCoin(Coin coin, string constructorType) 
        {
            Console.WriteLine("Results for: {0}", constructorType);
            Console.WriteLine("Value of CoinEnumeral: {0}", coin.CoinEnumeral);
            Console.WriteLine("Value of ValueOf: {0}", coin.ValueOf);
            Console.WriteLine("Value of ToString(): {0}", coin.ToString());
            Console.WriteLine();
        }
    }
}
