using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Airport_The_task_to_check_myself_.Models;
using Airport_The_task_to_check_myself_.Infractructure.Interaction;
using Airport_The_task_to_check_myself_.Interfaces;
namespace Airport_The_task_to_check_myself_
{
    

   public class Program
    {
        public static void Main(string[] args)
        {
            #region
            /*Airport<Airplane> airport = new Airport<Airplane>();
            IInteraction consoleInteraction = new ConsoleInteraction();
            Airplane plane;
            bool isInProcess = true;
            string continueString = null;
            char? letterToCheck;

            while (isInProcess)
            {

                plane = consoleInteraction.GetAirplaneFromUser();
                if (plane == null)
                {
                    Console.WriteLine("\nDo you want to enter another planes?(Y/N)");
                    while (true) {
                        continueString = Console.ReadLine();
                        if (continueString == "Y") { break; }
                        if (continueString == "N") { isInProcess = false;break; }
                        else { continue; }
                    }
                }
                if (plane != null) {
                  airport.Add(plane);
                    Console.WriteLine("\nEntered plane: \n" + plane.ToString());
                }
            }

            Console.WriteLine();
            Console.WriteLine(airport.ToString());
            Console.WriteLine();
            Console.ReadKey();

            airport.ShowPlainsSortedByNumber();
            Console.ReadKey();
            airport.ShowPlainsWithMaxSeats();
            Console.ReadKey();

            airport.ShowRangeOfFlight(RangeOfFlightType.average);
            airport.ShowRangeOfFlight(RangeOfFlightType.min);
            airport.ShowRangeOfFlight(RangeOfFlightType.max);

           Console.ReadKey();
            letterToCheck = consoleInteraction.GetLetterFromUser();

            if (letterToCheck != null) {
                airport.ShowPlainsWithLetterInNumber(letterToCheck);
            }


           Console.ReadKey();
           airport.ShowSeparatedPlanesByType();
            */
            #endregion



            
            

            Console.ReadLine();
        }
    }
}
