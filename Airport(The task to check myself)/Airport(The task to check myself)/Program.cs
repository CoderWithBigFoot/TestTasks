using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Airport_The_task_to_check_myself_.Models;
namespace Airport_The_task_to_check_myself_
{ 
   public class Program
    {
        
       public static void Main(string[] args)
        {

            /* Airplane plane = new Airplane() {
                 Name = "First",
                 Number = "GK - 101",
                 RangeOfFlight = 123,
                 Seats =12345
             };

             var results = new List<ValidationResult>();
             var context = new ValidationContext(plane);

             if (!Validator.TryValidateObject(plane, context, results, true))
             {
                 Console.WriteLine("Incorrect validation");
             }
             else {
                 Console.WriteLine(plane.ToString());
             }
             */

            string input = Console.ReadLine();

            foreach (var current in input.Split(new char[] { ',',' '})) {
                if (current.Trim() == "") { continue; }
                Console.WriteLine("> "+current.Trim() + " : " + current.Trim().Length);
            }

               
            Console.ReadKey();
        }
    }
}
