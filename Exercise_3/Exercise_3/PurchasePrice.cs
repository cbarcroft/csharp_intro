//Exercise 03
//Chris Barcroft

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    // This class represents the purchase price of something. 
    // In our software project, we will use it to represent the price of 
    // one can of soda. 
    class PurchasePrice 
    {
        private decimal _price;

         // This constructor sets the purchase price to zero 
        public PurchasePrice() 
        {
            _price = 0.00m;
        }
 
        // This constructor allows a new purchase price to be set by the user 
        public PurchasePrice(int initialPrice)
        {
            _price = (decimal)initialPrice;
        }

        // This constructor allows a new purchase price to be set by the user (accepting decimal instead)
        public PurchasePrice(decimal initialPrice)
        {
            _price = initialPrice;
        }
 
        // This property gets the value the purchase price as decimal only. 
        public decimal Price
        {
            get
            {
                return _price;
            }
        }

        //Two overloads for SetPrice to accept either an int or a decimal.
        public void setPrice(int value)
        {
            _price = (decimal)value;
        }

        public void setPrice(decimal value)
        {
            _price = value;
        }

 
    } //end PurchasePrice 

}
