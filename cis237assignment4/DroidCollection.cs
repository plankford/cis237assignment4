using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //Class Droid Collection implements the IDroidCollection interface.
    //All methods declared in the Interface must be implemented in this class 
    class DroidCollection : IDroidCollection
    {
        //Private variable to hold the collection of droids
        private Droid[] droidCollection;
        //Private variable to hold the length of the Collection
        private int lengthOfCollection;

        private Droid[] Aux = new Droid[100];

        //Constructor that takes in the size of the collection.
        //It sets the size of the internal array that will be used.
        //It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            //Make new array for the collection
            droidCollection = new Droid[sizeOfCollection];
            //set length of collection to 0
            lengthOfCollection = 0;
        }

        //The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Model, string Color, int NumberOfLanguages)
        {
            //If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                //Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                //of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Model, Color, NumberOfLanguages);
                //Increase the length of the collection
                lengthOfCollection++;
                //return that it was successful
                return true;
            }
            //Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        //The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        //The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The last method that must be implemented due to implementing the interface.
        //This method iterates through the list of droids and creates a printable string that could
        //be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            //Declare the return string
            string returnString = "";

            //For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                //If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    //Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    //the program will automatically know which version of CalculateTotalCost it needs to call based
                    //on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    //Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            //return the completed string
            return returnString;
        }

        public void DroidsByType()
        {
            //Individual stacks for the droids by type
            GenericStack<Droid> Protocols = new GenericStack<Droid>();
            GenericStack<Droid> Astromechs = new GenericStack<Droid>();
            GenericStack<Droid> Janitors = new GenericStack<Droid>();
            GenericStack<Droid> Utilities = new GenericStack<Droid>();

            //One single queue that will hold the sorted droids. They will be inserted by type
            //after that have been soted into there respective stack
            GenericQueue<Droid> DroidQueue = new GenericQueue<Droid>();

            //Bubble sort for the droids by type
            for (int i = 0; i < lengthOfCollection; i++)
            {
                
                if (droidCollection[i].GetType() == typeof(ProtocolDroid))
                {
                    Protocols.AddToFront(droidCollection[i]);
                }
                if (droidCollection[i].GetType() == typeof(AstromechDroid))
                {
                    Astromechs.AddToFront(droidCollection[i]);
                }
                if (droidCollection[i].GetType() == typeof(JanitorDroid))
                {
                    Janitors.AddToFront(droidCollection[i]);
                }
                if (droidCollection[i].GetType() == typeof(UtilityDroid))
                {
                    Utilities.AddToFront(droidCollection[i]);
                }
           }

                //Add the droids to the queue for further sorting and allowing printing ong
                //only one array - this will empty the current collections and place them in
                //a new one
                while (Astromechs.Size > 0)
                {
                    DroidQueue.AddToBack(Astromechs.RemoveFromFront());
                }
                while (Janitors.Size > 0)
                {
                    DroidQueue.AddToBack(Janitors.RemoveFromFront());
                }
                while (Utilities.Size > 0)
                {
                    DroidQueue.AddToBack(Utilities.RemoveFromFront());
                }
                while (Protocols.Size > 0)
                {
                    DroidQueue.AddToBack(Protocols.RemoveFromFront());
                }

                //Reload the droid collection
                for (int r = 0; r < lengthOfCollection; r++)
                {
                    droidCollection[r] = DroidQueue.RemoveFromFront();
                }            
        }

        public void DroidsByCost()
        {
            SortDroidsByCost(droidCollection, 0, lengthOfCollection);
        }

        //Added to implement Icomparable
        private void SortDroidsByCost(Droid[] droidCollection, int v, int lengthOfCollection)
        {
            throw new NotImplementedException();
        }

        private void SortDroidsByCost(IComparable[] arr, int low, int high)
        {
            if(high <= low)
            {
                return;
            }
            int mid = low + (high - low) / 2;
            SortDroidsByCost(arr, low, mid);
            SortDroidsByCost(arr, mid + 1, high);
            MergeSortedDroids(arr, low, mid, high);
        }

        private void MergeSortedDroids(IComparable[] arr, int low, int mid, int high)
        {
            int k = 0;
            int l = low;
            int j = mid + 1;

            for (k = low; k <= high; k++)
            {
                Aux[k] = arr[k];
            }

            for(k = low; k <= high; k++)
            {
                if (l > mid)
                {
                    arr[k] = Aux[j++];
                }
                else if (j > high)
                {
                    arr[k] = Aux[j++];
                }
                else if (Aux[j] < Aux[j])
                {
                    arr[k] = Aux[j++];
                }
                else
                {
                    arr[k] = Aux[j++];
                }
            }
        }
    }
}
