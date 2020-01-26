using System;
using System.Collections.Generic;
using System.Linq;
namespace EpamTasks
{
    public class Program
    {
        public static int CountVowels(string s)
        {
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

            int count = s.Count(c => vowels.Contains(c));
            return count;
        }

        // ----- ЗАПРЕЩЕНО ИЗМЕНЯТЬ КОД МЕТОДОВ, КОТОРЫЕ НАХОДЯТСЯ НИЖЕ -----

        public static void Main()
        {
            Console.WriteLine("Task is done when all test cases are correct:");

            int testCaseNumber = 1;

            TestReturnedValues(testCaseNumber++, "", 0);
            TestReturnedValues(testCaseNumber++, " ", 0);
            TestReturnedValues(testCaseNumber++, "a", 1);
            TestReturnedValues(testCaseNumber++, "b", 0);
            TestReturnedValues(testCaseNumber++, "ab", 1);
            TestReturnedValues(testCaseNumber++, "ba", 1);
            TestReturnedValues(testCaseNumber++, "aba", 2);
            TestReturnedValues(testCaseNumber++, "bab", 1);
            TestReturnedValues(testCaseNumber++, "aeiou", 5);
            TestReturnedValues(testCaseNumber++, "bacedifoguh", 5);
            TestReturnedValues(testCaseNumber++, "Lorem ipsum dolor sit amet", 9);
            TestException<ArgumentNullException>(testCaseNumber++, null);
        }

        private static void TestReturnedValues(int testCaseNumber, string s, int expectedResult)
        {
            try
            {
                if (CountVowels(s) == expectedResult)
                {
                    Console.WriteLine(correctCaseTemplate, testCaseNumber);
                }
                else
                {
                    Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
            }
        }

        private static void TestException<T>(int testCaseNumber, string s) where T : Exception
        {
            try
            {
                CountVowels(s);
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
            catch (ArgumentException)
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
                correctTestCaseAmount++;
            }
            catch (Exception)
            {
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
        }

        private static string correctCaseTemplate = "Case #{0} is correct.";
        private static string incorrectCaseTemplate = "Case #{0} IS NOT CORRECT";
        private static int correctTestCaseAmount = 0;
    }
}
