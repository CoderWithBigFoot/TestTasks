﻿using System;
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
   public class ConsoleInteraction: IInteraction
    {
        public Airplane GetAirplaneFromUser() {

            List<string> result = new List<string>() ;
            string inputString = null;
            string trimmedValue = null;
            bool isCorrect = false;
            Airplane plane;
            List<ValidationResult> validationResults;

            Console.WriteLine("\n    Enter the plane information. The input format: Name , Number , Seats , Range of flight\n");

            inputString = Console.ReadLine();
            if (inputString == "") { return null; }

                     
            //name,number,seats,rangeofflight

            foreach (var current in inputString.Split(new char[] {','})) // may be add ' '
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
        protected bool AirplaneValidation(List<string> parameters,out List<ValidationResult> validationErrors,out Airplane plane) {
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

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Length > 1 || input == "")
                {
                    Console.WriteLine("Incorrect symbol. Do you want to try again?(Y/N).");

                    while (true)
                    {
                        input = Console.ReadLine();

                        if (input == "Y") { break; }
                        if (input == "N") { return null; }
                        else { continue; }
                    }
                }
                if (input.Length == 1 && Char.IsLetter(input[0])) {
                    return input[0];
                }
            }
                           
            


        }
        



        }

    }

