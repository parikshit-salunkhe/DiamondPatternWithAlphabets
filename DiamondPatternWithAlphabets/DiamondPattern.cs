using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPatternWithAlphabets
{
    public class DiamondPattern
    {
        /// <summary>
        /// Generates the diamond patters, with the input Alphabet being the midpoint of the Diamond 
        /// </summary>
        /// <param name="inputAlphabet"></param>
        /// <returns></returns>
        public string[] Generate(char inputAlphabet)
        {
            if (char.IsLetter(inputAlphabet))
            {
                inputAlphabet = char.ToUpper(inputAlphabet); 

                // Create a char array containing all the alphabets and then find the index position of the user entered alphabet
                char[] alphabetArray = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
                int inputAlphabetIndex = Array.IndexOf(alphabetArray, inputAlphabet);

                // This string array will contain the daimond pattern. Initialized it to the exact number of rows required as per the user input.
                string[] diamondPatternArray = new string[((inputAlphabetIndex + 1) * 2) - 1];

                // Step 1 - Start with first part of the Triangle

                string whiteSpaceCharacter = " ";

                for (int i = 0; i <= inputAlphabetIndex; i++)
                {
                    for (int j = 0; j < inputAlphabetIndex - i; j++)
                    {
                        diamondPatternArray[i] += whiteSpaceCharacter;
                    }

                    diamondPatternArray[i] += alphabetArray[i];

                    if (alphabetArray[i] != 'A')
                    {
                        for (int j = 0; j < 2 * i - 1; j++)
                        {
                            diamondPatternArray[i] += whiteSpaceCharacter;
                        }
                        diamondPatternArray[i] += alphabetArray[i];
                    }
                }

                // Step 2 - Invert the Trainagle built in Step 1

                int invertedTriangeCursor = inputAlphabetIndex - 1;

                for (int i = inputAlphabetIndex + 1; i <= inputAlphabetIndex * 2; i++)
                {
                    diamondPatternArray[i] = diamondPatternArray[invertedTriangeCursor];
                    invertedTriangeCursor--;
                }

                return diamondPatternArray;
            }
            else
            {
                throw new ArgumentException(String.Format("{0} is not an alphabet", inputAlphabet), "inputAlphabet");
            }
        }

        /// <summary>
        /// Iterates through the string array and logs it to the console
        /// </summary>
        /// <param name="diamondArray"></param>
        public void PrintToConsole(string[] diamondArray)
        {
            Console.WriteLine("--------------------- Output ---------------------");
            Console.WriteLine();

            foreach (string row in diamondArray)
            {
                Console.WriteLine(row);
            }

            Console.WriteLine();
            Console.WriteLine("--------------------- End ---------------------");

            Console.ReadKey();
        }
    }
}
