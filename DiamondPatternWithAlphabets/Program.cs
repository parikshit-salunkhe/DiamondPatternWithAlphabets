using System;
using System.Linq;

namespace DiamondPatternWithAlphabets
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a character to get its Diamond Pattern :");
            char inputAlphabet = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            try
            {
                DiamondPattern diamondPattern = new DiamondPattern();
                string[] diamondPatternArray = diamondPattern.Generate(inputAlphabet);
                diamondPattern.PrintToConsole(diamondPatternArray);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
