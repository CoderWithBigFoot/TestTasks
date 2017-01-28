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
             Airport<Airplane> airport = new Airport<Airplane>();
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

             airport.GetPlainsSortedByNumber();
             Console.ReadKey();
             airport.GetPlainsWithMaxSeats();
             Console.ReadKey();

             airport.GetRangeOfFlight(RangeOfFlightType.average);
             airport.GetRangeOfFlight(RangeOfFlightType.min);
             airport.GetRangeOfFlight(RangeOfFlightType.max);

             letterToCheck = consoleInteraction.GetLetterFromUser();

             if (letterToCheck != null) {
                 airport.GetPlainsWithLetterInNumber(letterToCheck);
             }


             Console.WriteLine("\n\n -----------\n\n");

             airport.SeparateByType();
             
            #endregion

            

            Console.ReadLine();
        }
    }
}
