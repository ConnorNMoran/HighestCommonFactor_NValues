using System;
using System.Collections.Generic;

namespace HighestCommonFactor_NValues
{
    class HCF
    {
        enum YesNoPrompt
        {
            Yes,
            No,
            Invalid
        };

        static void Main(string[] args)
        {
            //Establish start of program
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("This program will work out the highest common factor of multiple integers.");

            //Repeat input and algorithm until user is satisfied 
            while (true)
            {
                List<int> values = GetInputsFromUser();
                int result = CheckEachValueFactors(values);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("The highest common factor is:");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result}\n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Would you like to try a new set of values?");
                Console.WriteLine("Please enter Y or N.");

                YesNoPrompt answer = PromptUserYesNo();

                if (answer == YesNoPrompt.No)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Thank you.");


            Console.ForegroundColor = ConsoleColor.Red;
        }


        private static YesNoPrompt PromptUserYesNo()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                string userResponse = Console.ReadLine();
                string userAnswer = userResponse.Trim().ToUpperInvariant();

                Console.WriteLine("");

                YesNoPrompt promptAnswer = (userAnswer == "Y" ? YesNoPrompt.Yes : (userAnswer == "N" ? YesNoPrompt.No : YesNoPrompt.Invalid));

                if (promptAnswer == YesNoPrompt.Invalid)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                }
                else
                {
                    return promptAnswer;
                }
            }
        }

        private static int PromptUserValue()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                int promptValue = 0;
                
                try
                {
                    promptValue = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nInvalid input. Please enter a number.");

                    continue;
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nInvalid input. Please enter a number between -2147483648 and 2147483647.");

                    continue;
                }

                Console.WriteLine("");

                return promptValue;
            }
        }

        //Get the values from the user, making sure to error check.
        private static List<int> GetInputsFromUser()
        {
            List<int> values = new List<int>();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please write the a value you wish to input:");

            values.Add(PromptUserValue());

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Would you like to add another value?");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("So far your values are: ");

                Console.ForegroundColor = ConsoleColor.Magenta;

                foreach (int value in values)
                {
                    Console.WriteLine(value);
                }

                Console.WriteLine("");

                if (PromptUserYesNo() == YesNoPrompt.Yes)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Please write the value you wish to add.");

                    values.Add(PromptUserValue());
                }
                else
                {
                    Console.Clear();

                    return values;
                }
            }
        }

        private static int CheckEachValueFactors(List<int> values)
        {
            int currentFactor = values[0];
            values.RemoveAt(0);

            foreach (int value in values)
            {
                currentFactor = EuclideanAlgorithm(currentFactor, value);

                if (currentFactor == 1)
                {
                    break;
                }
            }

            return currentFactor;
        }

        //Recursive function using the Euclidean algorithm.
        private static int EuclideanAlgorithm(int value1, int value2)
        {
            if (value2 == 0)
            {
                return value1;
            }

            return EuclideanAlgorithm(value2, value1 % value2);
        }
    }
}