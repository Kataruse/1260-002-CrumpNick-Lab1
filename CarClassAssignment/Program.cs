

using System.Transactions;
/**
*--------------------------------------------------------------------
* File name: CarClassAssignment
* Project name: CarClassAssignment
*--------------------------------------------------------------------
* Author’s name and email: Nick Crump, CRUMPNA@ETSU.ED
* Course-Section: CSCI 1260-002
* Creation Date: 1/23/2023
* -------------------------------------------------------------------
*/
namespace CarClassAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // below displays the default car class
            Console.WriteLine("--- This is the default Car Class ---");
            Car userCar = new Car();
            Console.WriteLine(userCar.ToString());
            Console.Write("Press Enter to Continue: ");
            Console.ReadLine();
            Console.Clear();
            
            // below prompts the user to create a car
            Console.WriteLine("Enter your car's make: ");
            userCar.setMake(Console.ReadLine());

            Console.WriteLine("Enter your car's model: ");
            userCar.setModel(Console.ReadLine());

            Console.WriteLine($"Enter your car's year (1900 - {DateTime.Now.Year+1}): ");
            try
            {
                userCar.setYear(Convert.ToInt32(Console.ReadLine()));
            }
            catch (Exception)
            {
                userCar.setYear(2018);
            }

            Console.WriteLine("Enter your car's tank size (in gallons): ");
            double tank = 23;
            try
            {
                tank = Convert.ToDouble(Console.ReadLine());
                userCar.setMaxTankLevel(tank);
                userCar.setCurrentTankLevel(tank);
            }
            catch (Exception)
            {
                userCar.setMaxTankLevel(tank);
                userCar.setCurrentTankLevel(tank);
            }

            Console.WriteLine("Enter your car's mpg: ");
            try
            {
                userCar.setMilesPerGallon(Convert.ToDouble(Console.ReadLine()));
            }
            catch (Exception)
            {
                userCar.setMilesPerGallon(21);
            }

            // below is a method to display the menu
            static void DisplayMenu(Car car)
            {
                Console.WriteLine(car.ToString());
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("[1] Travel to Kingsport (25 miles)");
                Console.WriteLine("[2] Travel to Knoxville (108 miles)");
                Console.WriteLine("[3] Specify Distance to Travel");
                Console.WriteLine("[4] Check on car details");
                Console.WriteLine("[5] Fill Gas Tank");
                Console.WriteLine("[0] Quit Program");
                Console.WriteLine("-------------------------------------");
            }

            int menuInput = 0;
            double miles = 0;
            double gas = 0;
            bool intCheck = false;
            bool highCheck = false;
            bool doubleCheck = false;
            bool mileCheck = true;
            bool gasCheck = true;

            do
            {
                // below are error checks for menu inputs if the user input a number either too high or one which was not valid
                Console.Clear();
                if (intCheck == true)
                {
                    Console.WriteLine("* ERROR: Menu input was not an integer!");
                }
                if (highCheck == true)
                {
                    Console.WriteLine("* ERROR: Menu input was higher than expected!");
                }
                intCheck = false;
                highCheck = false;

                //below gets the users menu input
                DisplayMenu(userCar);
                try
                {
                    menuInput = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    menuInput = 6;
                    intCheck = true;
                }

                switch (menuInput) 
                {
                    case 1:
                        // below drives to Kingsport
                        Console.Clear();
                        Console.WriteLine(userCar.Drive(25));
                        Console.Write("Press Enter to Continue: ");
                        Console.ReadLine();
                        break;
                    case 2:
                        //below drives to Knoxville
                        Console.Clear();
                        Console.WriteLine(userCar.Drive(108));
                        Console.Write("Press Enter to Continue: ");
                        Console.ReadLine();
                        break;
                    case 3:
                        // below drives a user chosen distance
                        do
                        {
                            // below gets user input & checks if the input was valid and repeats until it is
                            try
                            {
                                Console.Clear();
                                if (doubleCheck == true)
                                {
                                    Console.WriteLine("* ERROR: mile input was not a double!");
                                }
                                doubleCheck = false;
                                Console.Write("Enter the Amount of Miles: ");
                                miles = Convert.ToDouble(Console.ReadLine());
                                mileCheck = false;
                            }
                            catch (Exception)
                            {
                                doubleCheck = true;
                            }
                        }
                        while (mileCheck == true);
                        mileCheck = true;
                        Console.WriteLine(userCar.Drive(miles));
                        Console.Write("Press Enter to Continue: ");
                        Console.ReadLine();
                        break;
                    case 4:
                        // below displays the created car's attributes
                        Console.Clear();
                        Console.WriteLine(userCar.ToString());
                        Console.Write("Press Enter to Continue: ");
                        Console.ReadLine();
                        break;
                    case 5:
                        // below fills the tank by the amount of gallons the user choose
                        do
                        {
                            // below gets user input & checks if the input was valid and repeats until it is
                            try
                            {
                                Console.Clear();
                                if (doubleCheck == true)
                                {
                                    Console.WriteLine("* ERROR: Gas input was not a double!");
                                }
                                doubleCheck = false;
                                Console.Write("Enter the Amount of Gas: ");
                                gas = Convert.ToDouble(Console.ReadLine());
                                gasCheck = false;
                            }
                            catch (Exception)
                            {
                                doubleCheck = true;
                            }
                        }
                        while (gasCheck == true);
                        mileCheck = true;
                        Console.WriteLine(userCar.FillGasTank(gas));
                        Console.Write("Press Enter to Continue: ");
                        Console.ReadLine();
                        break;
                }
                // this checks to see if the intCheck was triggered and if not then it'll check to see if the input was higher than the max menu selection
                if (intCheck == false)
                {
                    if (menuInput > 5)
                    {
                        highCheck = true;
                    }
                }
            }
            while (menuInput > 0);
            Console.Clear();
            Console.WriteLine("Program Closing...");

        }
    }
}