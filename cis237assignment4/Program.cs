using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new droid collection and set the size of it to 100.
            IDroidCollection droidCollection = new DroidCollection(100);

            //Add hard coded droids to the collection
            droidCollection.Add("Carbonite", "Protocol", "Bronze", 3);
            droidCollection.Add("Vanadium", "Astromech", "Gold", true, true, false);
            droidCollection.Add("Carbonite", "Janitorial", "Silver", true, true, true);
            droidCollection.Add("Quadramium", "Utility", "Bronze", true, false, true);
            droidCollection.Add("Carbonite", "Protocol", "Gold", 5);
            droidCollection.Add("Vanadium", "Astromech", "Silver", false, true, true);
            droidCollection.Add("Quadramium", "Janitorial", "Bronze", true, true, true, true, true);
            droidCollection.Add("Carbonite", "Utility", "Gold", 4);
            droidCollection.Add("Vanadium", "Protocol", "Silver", true, false, false);
            droidCollection.Add("Quadramium", "Astromech", "Bronze", 5);
            droidCollection.Add("Carbonite", "Janitorial", "Gold", true, false, true);
            droidCollection.Add("Quadramium", "Utility", "Silver", true, true, true);

            //Create a user interface and pass the droidCollection into it as a dependency
            UserInterface userInterface = new UserInterface(droidCollection);

            //Display the main greeting for the program
            userInterface.DisplayGreeting();

            //Display the main menu for the program
            userInterface.DisplayMainMenu();

            //Get the choice that the user makes
            int choice = userInterface.GetMenuChoice();

            //While the choice is not equal to 3, continue to do work with the program
            while (choice != 5)
            {
                //Test which choice was made
                switch (choice)
                {
                    //Choose to create a droid
                    case 1:
                        userInterface.CreateDroid();
                        break;

                    //Choose to Print the droid
                    case 2:
                        userInterface.PrintDroidList();
                        break;

                    //Sort the droids by type
                    case 3:
                        droidCollection.DroidsByType();
                        break;

                    //Sort the droids by cost --- Lowest to Highest
                    case 4:
                        droidCollection.DroidsByCost();
                        break;


                }
                //Re-display the menu, and re-prompt for the choice
                userInterface.DisplayMainMenu();
                choice = userInterface.GetMenuChoice();
            }


        }
    }
}
