using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateProject
{
    public class DefensiveDesign
    {
        public static int GetInteger(string message = "")
        {
            bool validInput = false;
            int returnValue = 0;

            while (!validInput)
            {
                Console.Write(message);
                string? rawInput = Console.ReadLine();
                if(rawInput == null)
                {
                    Console.WriteLine("Please provide a value.");
                }
                else
                {
                    validInput = int.TryParse(rawInput, out returnValue);
                }

                if (!validInput)
                {
                    Console.WriteLine("Please provide a valid number.");
                }
            }

            return returnValue;
        }

        public static int RangedIntInput(int min = 0, int max = 10, string msg = "")
        {
            bool validInput = false;
            int inputValue = 0;
            while (!validInput)
            {
                inputValue = GetInteger(msg);
                if(inputValue >= min && inputValue <= max)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid number, must be between " + min + " and " + max + " inclusive.");
                }
            }

            return inputValue;
        }
    }
}
