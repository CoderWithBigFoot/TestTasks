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

    /*public class CustomCollection<T> :ICollection<T>, IEnumerable<T> where T: class  {
        private List<T> nestedCollection;
        [Range(1,100,ErrorMessage = "There must be from 1 to 100")]
        public int SomeInt { set; get; }

        public CustomCollection() {
            this.nestedCollection = new List<T>();
        }

        public IEnumerator<T> GetEnumerator() {
            return this.nestedCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator(){
            return GetEnumerator();
        }
    }
    */

    

   public class Program
    {
        
       public static void Main(string[] args)
        {

            /* Airplane plane = new Airplane() {
                 Name = "First",
                 Number = "GK - 101",
                 RangeOfFlight = 123,
                 Seats =11
             };

             var results = new List<ValidationResult>();
             var context = new ValidationContext(plane);

             if (!Validator.TryValidateObject(plane, context, results, true))
             {
                 Console.WriteLine("Incorrect validation");
             }
             else {
                 Console.WriteLine(plane.Seats + " " + plane.PlaneType);
             }*/

            /*foreach (var error in results)
            {
                Console.WriteLine(error.ErrorMessage);
            }*/
            ///show results only when validation is passed

            /*ITest test = new TestClass() { Name = "n" };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(test);
            if (!Validator.TryValidateObject(test, context, results, true))
            {
                Console.WriteLine("Some errors");
            }
            else { Console.WriteLine("all is ok"); }
            */
            Airplane plane = new Airplane() { Name = "Second",Number = "Z123",RangeOfFlight = 123 };
            /*List<Airplane> planes = new List<Airplane>() {
                plane,
                new Airplane { Name = "First",Seats = 123,Number = "Y5413"},
                new Airplane { Name = "Second",Number = "Y4123"}
            };*/


            Airport<Airplane> airport = new Airport<Airplane> {
                /*plane,
                new Airplane { Name = "First",Seats = 123,Number = "Y5413",RangeOfFlight = 3},
                new Airplane { Name = "Second",Number = "Y4123",RangeOfFlight = 5.1}*/
            };

            var result = airport.GetPlainsWithLetterInNumber(Char.Parse(Console.ReadLine()));
            if (result.Count() == 0)
            {
                Console.WriteLine("There are zero ");
            }
            else {
                foreach (var current in result) {
                    Console.WriteLine(current.ToString());
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
