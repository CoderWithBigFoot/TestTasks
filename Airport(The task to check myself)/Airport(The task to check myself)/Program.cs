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
        public static IEnumerable<string> GetStringsWithSubstring(IEnumerable<string> strings, string substring) {
            if (strings == null) { yield break; }

            foreach (var current in strings) {
                if (current.Contains(substring)) { yield return current; }
            }
        } 
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


            List<Airplane> planes = new List<Airplane>() {
                /*new Airplane() {
                    Seats = 12
                },
                new Airplane() {
                    Seats = 12
                },
                new Airplane() {
                    Seats = 11
                }*/
            };

            List<string> test = new List<string>() { "abc,abc,abcd,dfghasd" };
            if (GetStringsWithSubstring(null, "a") == null)
            {
                Console.WriteLine("is null");
            }
            
            /*foreach (var current in GetStringsWithSubstring(test, "a")) {
                Console.WriteLine(current);
            }*/


            
            
            Console.ReadKey();
        }
    }
}
