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
            IAirport<IAirplane> airport = new Airport<IAirplane>();
            IInteraction consoleInteraction = new ConsoleInteraction();
            IAirplane plane;
            bool isInProcess = true;
            string continueString = null;
            char? letterToCheck;
            Airplane checkedAirplane = null;

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
                    checkedAirplane = plane as Airplane;
                    if (checkedAirplane == null) continue;

                  airport.Add(checkedAirplane);
                    Console.WriteLine("\nEntered plane: \n" + plane.ToString());
                }
            }
            
            Console.WriteLine();
            Console.WriteLine(airport.ToString());
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("   Airplanes sorted by number:\n");
            consoleInteraction.ShowPlanes(airport.GetPlainsSortedByNumber());
            Console.ReadKey();

            Console.WriteLine("   Airplanes with max seats:\n");
            consoleInteraction.ShowPlanes(airport.GetPlainsWithMaxSeats());
            Console.ReadKey();

            consoleInteraction.ShowRangesOfFlight(
                airport.GetRangeOfFlight(RangeOfFlightType.min),
                airport.GetRangeOfFlight(RangeOfFlightType.max),
                airport.GetRangeOfFlight(RangeOfFlightType.average)
                );
           

           Console.ReadKey();
            Console.WriteLine("   Gonna find planes by letter:");
            letterToCheck = consoleInteraction.GetLetterFromUser();

            if (letterToCheck != null) {
                consoleInteraction.ShowPlanes(airport.GetPlainsWithLetterInNumber(letterToCheck));
            }


           Console.ReadKey();
            Console.WriteLine("\n   The goups of planes by their type:\n");
           consoleInteraction.ShowPlanes(airport.GetSeparatedPlanesByType());
            
            #endregion
            Console.ReadLine();
        }
    }
}
