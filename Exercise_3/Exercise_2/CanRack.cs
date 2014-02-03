//Exercise 03
//Chris Barcroft

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

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
                Console.WriteLine("{0} added.", FlavorOfCanToBeAdded);
            }
            else
            {
                Debug.WriteLine("Invalid flavor parameter supplied to RemoveACanOf().");
            }
        }

        public void AddACanOf(String FlavorOfCanToBeAdded)
        {
            if (Enum.IsDefined(typeof(Flavor), FlavorOfCanToBeAdded))
            {
                Flavor flavor = (Flavor)System.Enum.Parse(typeof(Flavor), FlavorOfCanToBeAdded, true);
                RemoveACanOf(flavor);
            }
            else
            {
                Debug.WriteLine("Flavor '{0}' not found in FLAVOR enum.  Cannot convert to Flavor object.", FlavorOfCanToBeAdded, null);
            }
        }

        // This method will remove a can of the specified flavor from the rack. 
        public void RemoveACanOf(Flavor FlavorOfCanToBeRemoved)
        {
            Debug.WriteLine("Removing can of {0}", FlavorOfCanToBeRemoved, null);

            if (IsEmpty(FlavorOfCanToBeRemoved))
            {
                Console.WriteLine("{0} is empty! Cannot dispense.", FlavorOfCanToBeRemoved);
                return;
            }

            if (_flavorBin.ContainsKey(FlavorOfCanToBeRemoved))
            {
                _flavorBin[FlavorOfCanToBeRemoved]--;
                Console.WriteLine("{0} dispensed.", FlavorOfCanToBeRemoved);
            }
            else
            {
                Debug.WriteLine("Invalid flavor parameter supplied to RemoveACanOf().");
            }
        }

        public void RemoveACanOf(String FlavorOfCanToBeRemoved)
        {
            CallFlavorMethodWithStringArgument(FlavorOfCanToBeRemoved, "RemoveACanOf");
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

        public void EmptyCanRackOf(String FlavorOfBinToBeEmptied)
        {
            CallFlavorMethodWithStringArgument(FlavorOfBinToBeEmptied, "EmptyCanRackOf");
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

        public void IsFull(String FlavorOfBinToCheck)
        {
            CallFlavorMethodWithStringArgument(FlavorOfBinToCheck, "IsFull");
        }

        // Return TRUE if the specified bin is empty.
        public Boolean IsEmpty(Flavor FlavorOfBinToCheck)
        {
            Debug.WriteLine("Checking if the {0} bin is empty.", FlavorOfBinToCheck, null);
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

        public void IsEmpty(String FlavorOfBinToCheck)
        {
            CallFlavorMethodWithStringArgument(FlavorOfBinToCheck, "IsEmpty");
        }

        // Private helper method to maintain support for methods that previously took a String argument for the flavor, but now take a Flavor type.
        // Provide the flavor string, and the name of the method to call
        private void CallFlavorMethodWithStringArgument(string FlavorString, string MethodName)
        {
            Debug.WriteLine("Attempting to convert String argument '{0}' to Flavor, and invoke {1}(Flavor) ", FlavorString, MethodName);
            Flavor flavor;

            //Attempt to parse FlavorString into Flavor
            if (Enum.TryParse(FlavorString, true, out flavor))
            {
                //Call the specified method via reflection, passing in the converted Flavor object
                object[] arguments = new object[] { flavor };
                this.GetType().GetMethod(MethodName, new Type[] { typeof(Flavor) }).Invoke(this, arguments);
            }
            else
            {
                Debug.WriteLine("Flavor '{0}' not found in FLAVOR enum.  Cannot convert to Flavor object.", FlavorString, null);
            }
        }
    } //end Can_Rack
}
