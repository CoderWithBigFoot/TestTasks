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

            /*Airplane airplane = new Airplane() {
                Name = "s",
                Number = "TR-123",
                Seats = -12,
                RangeOfFlight = 123.123
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(airplane);

            Validator.TryValidateObject(airplane, context, results, true);
            //Validator.TryValidateObject(airplane, context, results, true);




            Console.WriteLine();

            foreach (var error in results) {
                Console.WriteLine(error.ErrorMessage);
            }
            */

            /*string str = Console.ReadLine();
            if (str == "") { Console.WriteLine(" it is empty string "); }
            */

            Airplane plane = new Airplane() {
                Name = "First",
                Number = "GK - 101",
                RangeOfFlight = 123,
                Seats = -9
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(plane);

            Validator.TryValidateObject(plane, context, results, true);

            foreach (var error in results)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            ///show results only when validation is passed
            Console.WriteLine(plane.Seats + " " + plane.PlaneType);


            Console.ReadKey();
        }
    }
}
