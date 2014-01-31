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
    // This class will represent a can storage rack of the vending machine. 
    // A can of soda will simply be represented as a number  
    class CanRack
    {
        private Dictionary<Flavor, int> _flavorBin = new Dictionary<Flavor, int>();
        private const int _binSize = 3;

        // Constructor for a can rack. The rack starts out full 
        public CanRack()
        {
            Debug.WriteLine("Constructing new CanRack object.");
            FillTheCanRack();
        }

        // This method adds a can of the specified flavor to the rack. 
        public void AddACanOf(Flavor FlavorOfCanToBeAdded)
        {
            Debug.WriteLine("Adding can of " + FlavorOfCanToBeAdded);

            if (IsFull(FlavorOfCanToBeAdded))
            {
                Console.WriteLine("{0} is full! Cannot add can.", FlavorOfCanToBeAdded);
                return;
            }

            if (_flavorBin.ContainsKey(FlavorOfCanToBeAdded))
            {
                _flavorBin[FlavorOfCanToBeAdded]++;
            }
            else
            {
                Debug.WriteLine("Invalid flavor parameter supplied to RemoveACanOf().");
                return;
            }

            Console.WriteLine("{0} added.", FlavorOfCanToBeAdded);
        }

        // This method will remove a can of the specified flavor from the rack. 
        public void RemoveACanOf(Flavor FlavorOfCanToBeRemoved)
        {
            Debug.WriteLine("Removing can of " + FlavorOfCanToBeRemoved);

            if (IsEmpty(FlavorOfCanToBeRemoved))
            {
                Console.WriteLine("{0} is empty! Cannot dispense.", FlavorOfCanToBeRemoved);
                return;
            }

            if (_flavorBin.ContainsKey(FlavorOfCanToBeRemoved))
            {
                _flavorBin[FlavorOfCanToBeRemoved]--;
            }
            else
            {
                Debug.WriteLine("Invalid flavor parameter supplied to RemoveACanOf().");
                return;
            }

            Console.WriteLine("{0} dispensed.", FlavorOfCanToBeRemoved);
        }

        // This method will fill the can rack. 
        public void FillTheCanRack()
        {
            foreach (Flavor flavor in (Flavor[])Enum.GetValues(typeof(Flavor)))
            {
                _flavorBin[flavor] = _binSize;
            }

            Debug.WriteLine("All flavor bins have been filled. ({0} cans each)", _binSize);
        }

        // This public void will empty the rack of a given flavor. 
        public void EmptyCanRackOf(Flavor FlavorOfBinToBeEmptied)
        {
            Debug.WriteLine("Emptying the {0} bin.", FlavorOfBinToBeEmptied);

            if (_flavorBin.ContainsKey(FlavorOfBinToBeEmptied))
            {
                _flavorBin[FlavorOfBinToBeEmptied] = 0;
            }
            else
            {
                Debug.WriteLine("Invalid flavor parameter supplied to EmptyCanRackOf().");
            }
        }

        // Return TRUE if the specified bin is full.
        public Boolean IsFull(Flavor FlavorOfBinToCheck)
        {
            Debug.WriteLine("Checking if the " + FlavorOfBinToCheck + " bin is full.");
            bool binFull = false;
            int binCount;

            if (_flavorBin.TryGetValue(FlavorOfBinToCheck, out binCount))
            {
                if (binCount >= _binSize)
                    binFull = true;
            }
            else
            {
                Debug.WriteLine("Invalid flavor parameter supplied to IsFull().");
            }

            Debug.WriteLine("{0} bin full: {1}", FlavorOfBinToCheck, binFull);
            return binFull;
        }

        // Return TRUE if the specified bin is empty.
        public Boolean IsEmpty(Flavor FlavorOfBinToCheck)
        {
            Debug.WriteLine("Checking if the " + FlavorOfBinToCheck + " bin is empty.");
            bool binEmpty = false;
            int binCount;

            if (_flavorBin.TryGetValue(FlavorOfBinToCheck, out binCount))
            {
                if (binCount <= 0)
                    binEmpty = true;
            }
            else
            {
                Debug.WriteLine("Invalid flavor parameter supplied to IsEmpty().");
            }

            Debug.WriteLine("{0} bin empty: {1}", FlavorOfBinToCheck, binEmpty);
            return binEmpty;
        }
    } //end Can_Rack
}
