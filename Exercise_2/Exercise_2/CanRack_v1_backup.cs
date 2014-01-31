//Exercise 02
//Chris Barcroft

using System;
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
     class CanRack_v1_backup 
     { 
         private int _regularCans;
         private int _orangeCans;
         private int _lemonCans;

         private const int _binSize = 3;
 
         // Constructor for a can rack. The rack starts out full 
         public CanRack_v1_backup() 
         {
             Debug.WriteLine("Constructed new CanRack object.");
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

            switch (FlavorOfCanToBeAdded.ToLower())
            {
                case "regular":
                        _regularCans++;
                    break;
                case "orange":
                        _orangeCans++;
                    break;
                case "lemon":
                        _lemonCans++;
                    break;
                default:
                    Debug.WriteLine("Invalid flavor parameter supplied to AddACanOf().");
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

            switch (FlavorOfCanToBeRemoved.ToLower())
            {
                case "regular":
                    _regularCans--;
                    break;
                case "orange":
                    _orangeCans--;
                    break;
                case "lemon":
                    _lemonCans--;
                    break;
                default:
                    Debug.WriteLine("Invalid flavor parameter supplied to RemoveACanOf().");
                    return;
            }

            Console.WriteLine("{0} dispensed.", FlavorOfCanToBeRemoved);
         }
 
         // This method will fill the can rack. 
         public void FillTheCanRack() 
         {
             _regularCans = _orangeCans = _lemonCans = _binSize;
             Debug.WriteLine("All flavor bins have been filled. ({0} cans each)", _binSize);
         }
 
         // This public void will empty the rack of a given flavor. 
         public void EmptyCanRackOf(string FlavorOfBinToBeEmptied) 
         {
            Debug.WriteLine("Emptying the {0} bin.", FlavorOfBinToBeEmptied);
            switch (FlavorOfBinToBeEmptied.ToLower())
            {
                case "regular":
                    _regularCans = 0;
                    break;
                case "orange":
                    _orangeCans = 0;
                    break;
                case "lemon":
                    _lemonCans = 0;
                    break;
                default:
                    Debug.WriteLine("Invalid flavor parameter supplied to EmptyCanRackOf().");
                    break;
            }
         }
 
         // OPTIONAL – returns true if the rack is full of a specified flavor 
         // false otherwise 
         public Boolean IsFull(string FlavorOfBinToCheck)
         {
             Debug.WriteLine("Checking if the " + FlavorOfBinToCheck + " bin is full.");
             bool binFull = false;

            switch (FlavorOfBinToCheck.ToLower())
            {
                case "regular":
                    if(_regularCans >= _binSize)
                        binFull = true;
                    break;
                case "orange":
                    if(_orangeCans >= _binSize)
                        binFull = true;
                    break;
                case "lemon":
                    if(_lemonCans >= _binSize)
                        binFull = true;
                    break;
                default:
                    Debug.WriteLine("Invalid flavor parameter supplied to IsFull().");
                    break;
            }

             Debug.WriteLine("{0} bin full: {1}", FlavorOfBinToCheck, binFull);
             return binFull;
         }
 
         // OPTIONAL – return true if the rack is empty of a specified flavor 
         // false otherwise 
         public Boolean IsEmpty(string FlavorOfBinToCheck)
         {
             Debug.WriteLine("Checking if the" + FlavorOfBinToCheck + " bin is empty.");
             bool binEmpty = false;

             switch (FlavorOfBinToCheck.ToLower())
             {
                 case "regular":
                     if (_regularCans <= 0)
                         binEmpty = true;
                     break;
                 case "orange":
                     if (_orangeCans <= 0)
                         binEmpty = true;
                     break;
                 case "lemon":
                     if (_lemonCans <= 0)
                         binEmpty = true;
                     break;
                 default:
                     Debug.WriteLine("Invalid flavor parameter supplied to IsEmpty().");
                     break;
             }

             Debug.WriteLine("{0} bin empty: {1}", FlavorOfBinToCheck, binEmpty);
             return binEmpty;
         }
     } //end Can_Rack
}
