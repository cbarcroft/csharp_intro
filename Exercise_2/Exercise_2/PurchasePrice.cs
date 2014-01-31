//Exercise 02
//Chris Barcroft

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    // This class represents the purchase price of something. 
    // In our software project, we will use it to represent the price of 
    // one can of soda. 
    class PurchasePrice 
    {
        private int _price;

         // This constructor sets the purchase price to zero 
        public PurchasePrice() 
        {
            _price = 0;
        }
 
        // This constructor allows a new purchase price to be set by the user 
        public PurchasePrice(int initialPrice)
        {
            _price = initialPrice;
        }
 
        // This property gets and sets the value the purchase price. 
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
 
    } //end PurchasePrice 

}
