using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Flooring_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // **************************************************
            //
            // Title: Marchant - Flooring Calculator
            // Description: Doing simple calculations in Visual studio
            // Application Type: Console
            // Author: Velis, John, edited by Marchant, James
            // Dated Created: 9/20/2020
            // Last Modified: 11/22/2020
            //
            // **************************************************


            //
            // variables
            //

            string RoomName;
            string userResponse;
            string roomFlooringType;
            int roomLength;
            int roomWidth;
            int roomArea;
            int months;
            double totalCost = 0;
            double payment;
            const double UNIT_COST_OF_WOOD = 5.95;
            const double UNIT_COST_OF_TILE = 9.95;
            const double UNIT_COST_OF_CARPET = 7.95;
            bool validResponse = false;

            //
            // theme
            //

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            //*************************************************
            //*              SCREEN - Opening                 *
            //*************************************************

            //
            // display header
            //

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThe Flooring Calculator");
            Console.WriteLine();

            //
            // pause to continue
            //

            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.WriteLine();
            Console.ReadKey();

            //*************************************************
            //*           SCREEN - Instructions               *
            //*************************************************

            //
            // display header
            //

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tInstructions");
            Console.WriteLine();

            //
            // display instructions
            //

            Console.WriteLine("\tYou will enter several values for the flooring of your room");

            //
            // pause to continue
            //

            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.WriteLine();
            Console.ReadKey();


            //*************************************************
            //*            SCREEN - Get User Info             *
            //*************************************************

            //
            // display header
            //

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tInstructions");
            Console.WriteLine();

            //
            // get name of room
            //

            Console.Write("\tEnter name of room:");
            RoomName = Console.ReadLine();

            //
            // get dimensions of room
            //

            Console.WriteLine();

            //
            // validate user input for room length
            //

            do
            {
                Console.Write("\tEnter length of room:");
                userResponse = Console.ReadLine();
                if (int.TryParse(userResponse, out roomLength) && roomLength > 0)
                {
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine("\tPlease enter a number for the length of the room");
                    Console.WriteLine("\tPlease re-enter your value");
                    Console.WriteLine();
                }
            } while (!validResponse);
            do
            {
                validResponse = false;
                Console.Write("\tEnter width of room:");
                userResponse = Console.ReadLine();
                if (int.TryParse(userResponse, out roomWidth) && roomWidth > 0)
                {
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine("\tPlease enter a number for the length of the room");
                    Console.WriteLine("\tPlease re-enter your value");
                    Console.WriteLine();
                }
            } while (!validResponse);
            //
            // get flooring type and validate
            //

            validResponse = false;
            do
            {
                Console.WriteLine();
                Console.Write("\tEnter flooring type [wood, tile, carpet]:");
                roomFlooringType = Console.ReadLine();
                if (roomFlooringType == "wood" || roomFlooringType == "tile" || roomFlooringType == "carpet")
                {
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine("\tPlease enter a valid flooring type");
                    Console.WriteLine("\tPlease re-enter your flooring type");
                    Console.WriteLine();
                }
            } while (!validResponse);


            //
            // echo user information
            //

            Console.WriteLine();
            Console.WriteLine($"\tRoom: {RoomName}");
            Console.WriteLine($"\tLength: {roomLength}");
            Console.WriteLine($"\tWidth: {roomWidth}");
            Console.WriteLine($"\tFlooring Type: {roomFlooringType}");

            //
            // pause to continue
            //

            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.WriteLine();
            Console.ReadKey();

            //
            // calculate flooring cost
            //
            roomArea = roomLength * roomWidth;
            switch (roomFlooringType)
            {
                case "wood":
                    totalCost = roomArea * UNIT_COST_OF_WOOD;
                    break;
                case "tile":
                    totalCost = roomArea * UNIT_COST_OF_TILE;
                    break;
                case "carpet":
                    totalCost = roomArea * UNIT_COST_OF_CARPET;
                    break;
            }
            //*************************************************
            //*           SCREEN - Display Results            *
            //*************************************************

            //
            // display header
            //

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tResults");
            Console.WriteLine();

            //
            // display results
            //

            Console.WriteLine();
            Console.WriteLine($"\tRoom: {RoomName}");
            Console.WriteLine($"\tLength: {roomLength}");
            Console.WriteLine($"\tWidth: {roomWidth}");
            Console.WriteLine($"\tFlooring Type: {roomFlooringType}");
            Console.WriteLine($"\tArea: {roomArea}");
            Console.WriteLine($"\tTotal cost: {totalCost:C}");

            //
            // pause to continue
            //

            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.WriteLine();
            Console.ReadKey();


            //*************************************************
            //*              SCREEN - Payment                 *
            //*************************************************

            //
            // display header
            //

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tPayment Plan");
            Console.WriteLine();

            Console.WriteLine("Between 1-12 months, how long would you like the payment plan to be?");
            validResponse = false;
            do
            {
                if ((int.TryParse(Console.ReadLine(), out months) && months >= 1 && months <= 12))
                {
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine("Please enther a value between 1 and 12.");
                }
            } while (!validResponse);
            payment = totalCost / months;


            Console.WriteLine($"Number of months for the payment plan: {months}.");
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("\tMonth\tTotal Amount Payed\tTotal Owed");



            for (int index = 1; index < months + 1; index++)
            {
                double amountPayed = payment * index;
                double totalOwed = totalCost - (payment * index);
                Math.Round(amountPayed, 2);
                Math.Round(totalOwed, 2);
                string amountPayed2 = String.Format("{0:C}", amountPayed);
                string totalOwed2 = String.Format("{0:C}", totalOwed);

                Console.WriteLine();
                Console.Write($"\t{index}");
                Console.Write($"\t\t{amountPayed2}");
                Console.Write($"\t\t\t{totalOwed2}");
            }
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.WriteLine();
            Console.ReadKey();

            //*************************************************
            //*              SCREEN - Closing                 *
            //*************************************************

            //
            // display header
            //

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using our application");
            Console.WriteLine();

            //
            // pause to continue
            //

            Console.WriteLine();
            Console.WriteLine("\tPress any key to exit.");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
