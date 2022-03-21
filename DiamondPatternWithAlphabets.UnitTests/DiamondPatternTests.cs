using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiamondPatternWithAlphabets.UnitTests
{
    [TestClass]
    public class DiamondPatternTests
    {
        [DataTestMethod]
        [DataRow('x')]
        [DataRow('n')]
        [DataRow('t')]
        public void LowerCaseAlphabetAsInput_ReturnsDiamondPattern(char input) 
        {
            var diamondPattern = new DiamondPattern();

            var result = diamondPattern.Generate(input);

            Assert.IsNotNull(result);
        }

        [DataTestMethod]
        [DataRow('R')]
        [DataRow('D')]
        [DataRow('Z')]
        public void UpperCaseAlphabetAsInput_ReturnsDiamondPattern(char input) 
        {
            var diamondPattern = new DiamondPattern();

            var result = diamondPattern.Generate(input);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void NumericInput_ShouldThrowArgumentException()  
        {
            var diamondPattern = new DiamondPattern();
            Random random = new Random();
            
            Assert.ThrowsException<ArgumentException>(()=>diamondPattern.Generate(Convert.ToChar(random.Next(0, 9))));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetSymbolsAsInputData), DynamicDataSourceType.Method)]
        public void SymbolAsInput_ReturnsException(char input)  
        {
            var diamondPattern = new DiamondPattern();

            Assert.ThrowsException<ArgumentException>(() => diamondPattern.Generate(input));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void ValidInput_FirstAndLastRowMustContainLetterA(char input) 
        {
            var diamondPattern = new DiamondPattern();

            string[] result = diamondPattern.Generate(input);
            Assert.IsTrue(result.First().Contains('A'));
            Assert.IsTrue(result.Last().Contains('A'));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void ValidInput_MiddleRowMustContainLetterMatchingInput(char input) 
        {
            var diamondPattern = new DiamondPattern();

            string[] result = diamondPattern.Generate(input);
            
            Assert.IsTrue(result[(result.Length / 2)].Contains(char.ToUpper(input)));
        }

        /// <summary>
        /// The number of elements in result must be equal to the equation - [ ( (IndexOfUserInputCharacter + 1) * 2 ) - 1 ]
        /// </summary>
        /// <param name="input"></param>
        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void ValidInput_HasCorrectNumberOfRowsInOutput(char input) 
        {
            var diamondPattern = new DiamondPattern();

            char[] alphabetArray = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
            int inputAlphabetIndex = Array.IndexOf(alphabetArray, char.ToUpper(input));
            int expectedNumberOfRows = ((inputAlphabetIndex + 1) * 2) - 1; 

            int countOfRows = diamondPattern.Generate(input).Length;
            Console.WriteLine("Expected {0} and total {1} ", expectedNumberOfRows, countOfRows);
            Assert.AreEqual(expectedNumberOfRows, countOfRows);
        }

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { 'A' };
            yield return new object[] { 'Z' };
            yield return new object[] { 'R' };
            yield return new object[] { 'G' };
            yield return new object[] { 'Y' };
            yield return new object[] { 'B' };
            yield return new object[] { 'g' };
            yield return new object[] { 'u' };
            yield return new object[] { 'w' };
        }

        public static IEnumerable<object[]> GetSymbolsAsInputData()
        {
            yield return new object[] { '@' };
            yield return new object[] { '#' };
            yield return new object[] { '$' };
            yield return new object[] { '%' };
            yield return new object[] { '%' };
            yield return new object[] { '^' };
        }
    }
}
