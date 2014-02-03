using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinDevelopment
{
    class Coin 
    {
        public enum Denomination
        { SLUG = 0, NICKEL = 5, DIME = 10, QUARTER = 25, HALFDOLLAR = 50 } 

        private Denomination _denomination;
 
         // parameterless constructor – coin will be a slug 
         public Coin() 
         {
             _denomination = Denomination.SLUG;
         }
 
         // parametered constructor – coin will be of appropriate value 
         // if value passed is outside normal set (e.g. 5 cents = Nickel) 
         // coin is a slug // <--- I think this description might be for the overload that accepts a Decimal?
         public Coin(Denomination CoinEnumeral) 
         {
             _denomination = CoinEnumeral;
         }
 
         // This constructor will take a string and return the appropriate enumeral 
         public Coin(string CoinName)
         {
             if (!Enum.TryParse(CoinName, true, out _denomination))
             {
                 _denomination = Denomination.SLUG;
             }
         }
 
 
         // parametered constructor – coin will be of appropriate value 
         public Coin(decimal CoinValue) 
         {
             int coinCents = (int)Decimal.Multiply(CoinValue, 100m);

             if (Enum.IsDefined(typeof(Denomination), coinCents))
                 _denomination = (Denomination)coinCents;
             else
                 _denomination = Denomination.SLUG;
         }
 
         // This property will get the monetary value of the coin. 
         public decimal ValueOf
         {
             get
             {
                 return (decimal)_denomination / 100;
             }
         }
 
         // This property will get the coin name as an enumeral 
         public Denomination CoinEnumeral
         {
             get
             {
                 return (Denomination)_denomination;
             }
         }
 
 
         // use Enum.GetName() with a private Denomination instance variable 
         // to produce a string 
         public override string ToString()
         {
             return Enum.GetName(typeof(Denomination), _denomination);
         }
    } 
}
