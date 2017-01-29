using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_The_task_to_check_myself_.Interfaces;
using Airport_The_task_to_check_myself_.Models;
using Airport_The_task_to_check_myself_.Infrastructure.Exceptions;
using System.ComponentModel.DataAnnotations;
namespace Airport_The_task_to_check_myself_.Infractructure.Interaction
{

    /*I created this class for incapsulate almost whole console interaction logic*/
   public class ConsoleInteraction: IInteraction
    {
        public IAirplane GetAirplaneFromUser() {

            List<string> result = new List<string>() ;
            string inputString = null;
            string trimmedValue = null;
            bool isCorrect = false;
            IAirplane plane;
            List<ValidationResult> validationResults;

            Console.WriteLine("\nEnter the plane information.\nThe input format: Name , Number , Seats , Range of flight\n");

            inputString = Console.ReadLine();
            if (inputString == "") { return null; }

                     
            //name,number,seats,rangeofflight

            foreach (var current in inputString.Split(new char[] {','}))
            {
                trimmedValue = current.Trim();
                if (trimmedValue == "") { continue; }
                result.Add(trimmedValue);        
            }

            try
            {
                isCorrect = this.AirplaneValidation(result, out validationResults, out plane);

                if (isCorrect) { return plane; }
                else
                {
                    Console.WriteLine();
                    foreach (var currentError in validationResults)
                    {
                        Console.WriteLine(currentError.ErrorMessage);
                    }
                    return null;
                }
            }
            catch (IncorrectParametersCountException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (FormatException) {
                Console.WriteLine("The seats and range of flight must be numerals." );
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        protected bool AirplaneValidation(List<string> parameters,out List<ValidationResult> validationErrors,out IAirplane plane) {
            if (parameters.Count() != 4) { throw new IncorrectParametersCountException(); }

         
               plane = new Airplane
                {
                    Name = parameters[0].Trim(),
                    Number = parameters[1].Trim(),
                    Seats = Int32.Parse(parameters[2].Trim()),      //here is may be a FormatException
                    RangeOfFlight = Double.Parse(parameters[3].Trim())
                };

    
                var results = new List<ValidationResult>();
                var context = new ValidationContext(plane);

                if (Validator.TryValidateObject(plane, context, results, true))
                {
                    validationErrors = results; 
                    return true;
                }
                else {
                    validationErrors = results;
                    plane = null;
                    return false;
                }

            }
        public char? GetLetterFromUser() {
            string yesOrNo = null;
            while (true)
            {
                Console.WriteLine("Enter the searching letter (searching in number): ");
                string input = Console.ReadLine();
                if (input.Length > 1 || input == "" || !Char.IsLetter(input[0]))
                {
                    Console.WriteLine("Incorrect symbol. Do you want to try again?(Y/N).");

                    while (true)
                    {
                        yesOrNo = Console.ReadLine();

                        if (yesOrNo == "Y") { break; }
                        if (yesOrNo == "N") { return null; }
                        else { continue; }
                    }
                }
                if (input.Length == 1 && Char.IsLetter(input[0])) {
                    return input[0];
                }
            }
                           
            


        }
        public void ShowPlanes(IEnumerable<IAirplane> collection) {
            if (collection == null || collection.Count() == 0) { Console.WriteLine("There are no planes");return; }

            foreach (var current in collection) {
                Console.WriteLine(current.ToString());
                Console.WriteLine();
            }
        }
        public void ShowPlanes(IEnumerable<IGrouping<PlaneTypes, IAirplane>> collection) {
            if (collection == null || collection.Count()==0) { Console.WriteLine("There are no planes");return; }

            foreach (var currentGroup in collection) {
                Console.WriteLine($"   Type is: {currentGroup.Key.ToString()}\n\n");
                foreach (var plane in currentGroup) {
                    Console.WriteLine(plane.ToString());
                }
            }
        }
        /// <summary>
        /// Shows the min, max and average ranges of flight
        /// </summary>
        /// <param name="minRangeOfFlight">The min range</param>
        /// <param name="maxRangeOfFlight">The max range</param>
        /// <param name="averageRangeOfFlight">The average range</param>
        public void ShowRangesOfFlight(double? minRangeOfFlight, double? maxRangeOfFlight, double? averageRangeOfFlight) {
            Console.WriteLine("   The ranges of flight: \n");
            if (minRangeOfFlight == null || maxRangeOfFlight == null || averageRangeOfFlight == null) { Console.WriteLine("Incorrect ranges."); return; }

            Console.WriteLine($"The min range of flight: {minRangeOfFlight}\nThe max range of flight: {maxRangeOfFlight}\nThe average range of flight: {averageRangeOfFlight}\n");
        }
       }
    }

