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
    public class Human {
        public string Name { set; get; }
        public string Sername { set; get; }
    }

   public class Program
    {
        
       public static void Main(string[] args)
        {

            
            try
            {
                char letter = Char.Parse(Console.ReadLine());
            }
            catch (FormatException ex) { Console.WriteLine(ex.Message); }
               
            Console.ReadKey();
        }
    }
}
