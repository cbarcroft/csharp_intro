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
    // This class will represent a can storage rack of the vending machine. 
    // A can of soda will simply be represented as a number 
    // (e.g., orangeCans = 1 means there is one can of orange soda in the rack). 
    class CanRack
    {
        private Dictionary<string, int> _flavorBin = new Dictionary<string, int>();
        public ArrayList _flavors = new ArrayList();
        private const int _binSize = 3;

        public ArrayList Flavors
        {
            get
            {
                return _flavors;
            }
        }

        // Constructor for a can rack. The rack starts out full 
        public CanRack()
        {
            Debug.WriteLine("Constructing new CanRack object.");
            _flavors.Add("regular");
            _flavors.Add("lemon");
            _flavors.Add("orange");
            FillTheCanRack();
        }

        // This method adds a can of the specified flavor to the rack. 
        public void AddACanOf(string FlavorOfCanToBeAdded)
        {
            Debug.WriteLine("Adding can of " + FlavorOfCanToBeAdded);

            if (IsFull(FlavorOfCanToBeAdded))
            {
                Console.WriteLine("{0} is full! Cannot add can.", FlavorOfCanToBeAdded);
                return;
            }

            if (_flavorBin.ContainsKey(FlavorOfCanToBeAdded.ToLower()))
            {
                _flavorBin[FlavorOfCanToBeAdded.ToLower()]++;
            }
            else
            {
                Debug.WriteLine("Invalid flavor parameter supplied to RemoveACanOf().");
                return;
            }

            Console.WriteLine("{0} added.", FlavorOfCanToBeAdded);
        }

        // This method will remove a can of the specified flavor from the rack. 
        public void RemoveACanOf(string FlavorOfCanToBeRemoved)
        {
            Debug.WriteLine("Removing can of " + FlavorOfCanToBeRemoved);

            if (IsEmpty(FlavorOfCanToBeRemoved))
            {
                Console.WriteLine("{0} is empty! Cannot dispense.", FlavorOfCanToBeRemoved);
                return;
            }

            if (_flavorBin.ContainsKey(FlavorOfCanToBeRemoved.ToLower()))
            {
                _flavorBin[FlavorOfCanToBeRemoved.ToLower()]--;
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
            foreach (string flavor in _flavors)
                _flavorBin[flavor] = _binSize;

            Debug.WriteLine("All flavor bins have been filled. ({0} cans each)", _binSize);
        }

        // This public void will empty the rack of a given flavor. 
        public void EmptyCanRackOf(string FlavorOfBinToBeEmptied)
        {
            Debug.WriteLine("Emptying the {0} bin.", FlavorOfBinToBeEmptied);

            if (_flavorBin.ContainsKey(FlavorOfBinToBeEmptied.ToLower()))
            {
                _flavorBin[FlavorOfBinToBeEmptied.ToLower()] = 0;
            }
            else
            {
                Debug.WriteLine("Invalid flavor parameter supplied to EmptyCanRackOf().");
            }
        }

        // OPTIONAL – returns true if the rack is full of a specified flavor 
        // false otherwise 
        public Boolean IsFull(string FlavorOfBinToCheck)
        {
            Debug.WriteLine("Checking if the " + FlavorOfBinToCheck + " bin is full.");
            bool binFull = false;
            int binCount;

            if (_flavorBin.TryGetValue(FlavorOfBinToCheck.ToLower(), out binCount))
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

        // OPTIONAL – return true if the rack is empty of a specified flavor 
        // false otherwise 
        public Boolean IsEmpty(string FlavorOfBinToCheck)
        {
            Debug.WriteLine("Checking if the " + FlavorOfBinToCheck + " bin is empty.");
            bool binEmpty = false;
            int binCount;

            if (_flavorBin.TryGetValue(FlavorOfBinToCheck.ToLower(), out binCount))
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
