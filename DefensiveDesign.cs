using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static string StringInputLength(int minChars = 1, int maxChars = 10, string msg = "")
        {
            bool validInput = false;
            string returnValue = "";
            while (!validInput)
            {
                Console.Write(msg);
                string? rawInput = Console.ReadLine();
                if (rawInput == null)
                {
                    Console.WriteLine("Please provide a value.");
                }
                else
                {
                    if (rawInput.Length >= minChars && rawInput.Length <= maxChars)
                    {
                        returnValue = rawInput;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Please provide a value that is at least " + minChars + " in length, but no more than " + maxChars + " in length.");
                    }
                }
            }

            return returnValue;
        }

        public static bool InputMaskHandler(string checkValue, string inputMask)
        {
            try
            {
                if (inputMask == null)
                {
                    throw new ArgumentNullException("Mask cannot be null");
                }

                return InputMaskCheck(checkValue, inputMask);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Configuration Error: {ex.Message}");
            }

            catch (Exception ex)
            {
                // Catch-all for unexpected issues
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            return false;
        }

        public static bool InputMaskCheck(string checkValue, string inputMask)
        {
            //Rules:
            // - L : Letters only
            // - N : Digit (0-9)
            // - A : Alphanumeric
            // - C : Any character
            // - space/literal : Must mach exactly

            if(checkValue.Length != inputMask.Length)
            {
                return false;
            }

            for(int i = 0; i < inputMask.Length; i++)
            {
                char m = inputMask.ToUpper()[i];
                char v = checkValue[i];

                switch (m)
                {
                    case 'L': //Letter Required
                        if (!char.IsLetter(v))
                        {
                            return false;
                        }
                        break;
                    case 'N': //Digit Required
                        if (!char.IsDigit(v))
                        {
                            return false;
                        }
                        break;
                    case 'A': //Alphanumeric Required
                        if (!char.IsLetterOrDigit(v))
                        {
                            return false;
                        }
                        break;
                    case 'C':
                        break;
                    default: //Literal match
                        if (v != m)
                        {
                            return false;
                        }
                        break;
                }
            }

            return true;
        }
    }
}
