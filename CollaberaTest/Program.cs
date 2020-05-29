using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaberaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            input input = new input();
            while (input.result == false)
            {
                Console.Write("\n Please Enter Your Input: ");
                input.userInput = Console.ReadLine();
                input.result = double.TryParse(input.userInput, out input.NumericData);
                if (input.result == false)
                {
                    Console.Clear();
                    Console.Write("\n Please Enter Numbers Only.");
                }
                Console.WriteLine(input.ConvertNumberToWords(input.NumericData));
                Console.ReadLine();
            }
        }
        public class input : IConvertNumberToWord
        {
            public input() { }
            public string userInput;
            public double NumericData;
            public bool result = false;

            public string Conversion(int number, string sample)
            {
                string str = "";
                var digits = new Digits();

                // if number is more than 19, divide it  
                if (number > 19)
                {
                    str += digits.DoubleDigit[number / 10] + digits.MixedDigit[number % 10];
                }
                else
                {
                    str += digits.MixedDigit[number];
                }

                // if nubmer is non-zero  
                if (number != 0)
                {
                    str += sample;
                }

                return str;
            }

            public string ConvertNumberToWords(double userInput)
            {
                // stores word representation of the user input number
                string output = string.Empty;

                // handles digits at ten millions and hundred millions places (if any)  
                output += Conversion((int)(userInput / 10000000), "crore ");

                // handles digits at hundred thousands and one millions places (if any)  
                output += Conversion((int)((userInput / 100000) % 100), "lakhs ");

                // handles digits at thousands and tens places (if any)  
                output += Conversion((int)((userInput / 1000) % 100), "thousand ");

                // handles digit at hundreds places (if any)  
                output += Conversion((int)((userInput / 100) % 10), "hundred ");

                if (userInput > 100 && userInput % 100 > 0)
                {
                    output += "and ";
                }
                // handles digits at ones and tens places (if any)  
                output += Conversion((int)(userInput % 100), "");
                return output;
            }
            class Digits
            {
                public string[] MixedDigit = {"", "one ", "two ", "three ", "four ",
                       "five ", "six ", "seven ", "eight ",
                       "nine ", "ten ", "eleven ", "twelve ",
                       "thirteen ", "fourteen ", "fifteen ",
                       "sixteen ", "seventeen ", "eighteen ",
                       "nineteen "};
                public string[] DoubleDigit = {"", "", "twenty ", "thirty ", "forty ",
                       "fifty ", "sixty ", "seventy ", "eighty ",
                       "ninety "};
            }

        }
    }
}