using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public void SymbolAsInput_ShouldThrowArgumentException(char input)  
        {
            var diamondPattern = new DiamondPattern();

            Assert.ThrowsException<ArgumentException>(() => diamondPattern.Generate(input));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void ValidInput_TotalNumberOfRowsShouldAlwaysbeOddNumber(char input)
        {
            var diamondPattern = new DiamondPattern();

            int countOfRows = diamondPattern.Generate(input).Length;
            Console.WriteLine("TotalRows {0} ", countOfRows);
            Assert.IsFalse(countOfRows % 2 == 0);
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
            Console.WriteLine("ExpectedRows {0} vs TotalRows {1} ", expectedNumberOfRows, countOfRows);
            Assert.AreEqual(expectedNumberOfRows, countOfRows);
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
        public void ValidInput_MiddleRowMustContainLetterMatchingUserInput(char input)
        {
            var diamondPattern = new DiamondPattern();

            string[] result = diamondPattern.Generate(input);

            Assert.IsTrue(result[(result.Length / 2)].Contains(char.ToUpper(input)));
        }

        [TestMethod]
        public void ValidInput_HasCorrectCharacterSequenceForC()
        {
            var diamondPattern = new DiamondPattern();

            var result = diamondPattern.Generate('C');

            Console.WriteLine("ExpectedResult {0} vs AvailableResult {1} ", "ABBCCBBA", getAlphabetSequence(result));
            Assert.AreEqual("ABBCCBBA", getAlphabetSequence(result));
        }

        [TestMethod]
        public void ValidInput_CharactersShouldBeInSeperateRowForC()
        {
            var diamondPattern = new DiamondPattern();

            var result = diamondPattern.Generate('C');

            Console.WriteLine("ExpectedResult {0} vs AvailableResult {1} ", "A", result[0].Replace(" ", string.Empty));
            Console.WriteLine("ExpectedResult {0} vs AvailableResult {1} ", "BB", result[1].Replace(" ", string.Empty));
            Console.WriteLine("ExpectedResult {0} vs AvailableResult {1} ", "CC", result[2].Replace(" ", string.Empty));
            Console.WriteLine("ExpectedResult {0} vs AvailableResult {1} ", "BB", result[3].Replace(" ", string.Empty));
            Console.WriteLine("ExpectedResult {0} vs AvailableResult {1} ", "A", result[4].Replace(" ", string.Empty));

            Assert.AreEqual("A", result[0].Replace(" ",string.Empty));
            Assert.AreEqual("BB", result[1].Replace(" ", string.Empty));
            Assert.AreEqual("CC", result[2].Replace(" ", string.Empty));
            Assert.AreEqual("BB", result[3].Replace(" ", string.Empty));
            Assert.AreEqual("A", result[4].Replace(" ", string.Empty));
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

        public string getAlphabetSequence(string[] resultStringArray)
        {
            StringBuilder sequence =new StringBuilder();

            foreach(string str in resultStringArray)
            {
                sequence.Append(str.Replace(" ", string.Empty));
            }

            return sequence.ToString();
        }

    }
}
