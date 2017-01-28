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
            
            IAirport<Airplane> airport = new Airport<Airplane>();
            IInteraction consoleInteraction = new ConsoleInteraction();
            Airplane plane;

            plane = consoleInteraction.GetAirplaneFromUser();
            if (plane != null) { Console.WriteLine(plane.ToString()); }        
            Console.ReadKey();
        }
    }
}
