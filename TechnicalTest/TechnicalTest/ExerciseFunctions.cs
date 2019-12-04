using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest
{

    public sealed class CartesianPoint
    {
		public int X {get; set;}
		public int Y {get; set;}
	}

    internal static class Brackets
    {
        static Dictionary<char, char[]> dictValidBrackets;

        /// <summary>
        /// Constructor. 
        /// </summary>
        static Brackets()
        {
            dictValidBrackets = new Dictionary<char, char[]>();
            dictValidBrackets.Add('(', new char[] { ')', '[', '('});
            dictValidBrackets.Add(')', new char[] { '(', ')', '['});
            dictValidBrackets.Add('[', new char[] { ']'});
            dictValidBrackets.Add(']', new char[] { '[', ')','(' });
        }

        internal static bool isValidBracketChar(string bracketsString)
        {
            int validCharactersCount = bracketsString.Count(x => x == '(') +
                                       bracketsString.Count(x => x == ')') +
                                       bracketsString.Count(x => x == '[') +
                                       bracketsString.Count(x => x == ']');
            
            if (validCharactersCount == bracketsString.Length)
                return true;

            return false;
        }

        internal static bool IsValidBracketsCombination(char currentChar, char nextChar)
        {
            char[] validBrackets = dictValidBrackets[currentChar];
            if (validBrackets.Contains(nextChar))
                return true;

            return false;
        }

        internal static bool IsValidOpenClosedNumberBrackets(string bracketsString)
        {
            int openParenthesis = bracketsString.Count(x=> x== '(');
            int closeParenthesis = bracketsString.Count(x => x == ')');
            int openBrackets = bracketsString.Count(x => x == '[');
            int closeBrackets = bracketsString.Count(x => x == ']');

            if ((openParenthesis == closeParenthesis) && (openBrackets == closeBrackets))
                return true;

            return false;
        }
    }

    public class ExerciseFunctions
    {
        /// <summary>
        /// Function that determines if a date belongs to a leap year
        /// </summary>
        /// <param name="strLeapyear"></param>
        /// <returns></returns>
        public bool leapYear(string strLeapyear)
        {
            DateTime dtLeapYear = new DateTime();
            bool success = DateTime.TryParse(strLeapyear, out dtLeapYear);
            if (success)
            {
                int year = dtLeapYear.Year;
                if ((year % 4 == 0 && year % 100 != 0) || (year % 4 == 0 && year % 100 == 0 && year % 400 == 0))
                {
                    return true;
                }
            }
            else
            {
                throw new Exception();
            }
            return false;
        }

        /// <summary>
        /// Function that gets the common characteres of 2 strings        
        /// /// </summary>
        /// <param name="firstString"></param>
        /// <param name="secondString"></param>
        /// <returns></returns>
        public Char[] repeatedStrings(string firstString, string secondString)
        {
            // Validate if the first string has a repeated character
            foreach (char currentChar in firstString.ToCharArray())
            {
                int numberOcurrences = firstString.Count(x => x == currentChar);
                if (numberOcurrences > 1)
                    throw new Exception("The string provided as first string has next repeated character: " + currentChar + ", please provide a valid one");
            }

            // Validate if the second string has a repeated character
            foreach (char currentChar in secondString.ToCharArray())
            {
                int numberOcurrences = secondString.Count(x => x == currentChar);
                if (numberOcurrences > 1)
                    throw new Exception("The string provided as second string has next repeated character: " + currentChar + ", please provide a valid one");
            }

            Char[] charArray = firstString.Intersect(secondString).ToArray();           

            return charArray;
        }

        /// <summary>
        /// Function that returns the compressing string from other one
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        public string compressedString(string originalString)
        {
            String compressedString = String.Empty;

            // Validate if the first string has a repeated character
            foreach (char currentChar in originalString.ToCharArray())
            {
                int numberOcurrences = originalString.Count(x => x == currentChar);
                if(!compressedString.Contains(currentChar))
                    compressedString += currentChar + numberOcurrences.ToString();
            }

            return compressedString.Length < originalString.Length ? compressedString : originalString;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bracketsString"></param>
        /// <returns></returns>
        public bool closedBrackets(String bracketsString)
        {
            // Must be at least 2 characters to evaluate and its length must be divisible by 2
            if (bracketsString.Length == 1 || !(bracketsString.Length % 2 == 0))
                return false;

            // Verify that all characters os the string are valid ones
            if (!Brackets.isValidBracketChar(bracketsString))
                return false;

            Char[] bracketsArrayChar = bracketsString.ToCharArray();

            // Compare the current posicion with the next one
            for (int pos = 0; pos < bracketsString.Length - 1; pos++)
            {
                char currentChar = bracketsArrayChar[pos];
                char nextChar = bracketsArrayChar[pos + 1];
                if (!Brackets.IsValidBracketsCombination(currentChar, nextChar))
                    return false;
            }

            // If everithing is fine so far, compare that the number of open and closed brackets is the same
            if (Brackets.IsValidOpenClosedNumberBrackets(bracketsString))
                return true;

            return false;            
        }

        /// <summary>
        /// Function that returns the smallest bounding area according with the given Cartesian Points
        /// </summary>
        /// <param name="lstCartesianPoints"></param>
        /// <returns></returns>
        public int smallestArea(List<CartesianPoint> lstCartesianPoints)
        {            
            int smallestXpoint=0, biggestXpoint=0, smallestYpoint=0, biggestYpoint=0;
			
            foreach (CartesianPoint cartesianPoint in lstCartesianPoints)
            {
                if (cartesianPoint.X < smallestXpoint)
					smallestXpoint = cartesianPoint.X;

               if (cartesianPoint.X > biggestXpoint)
                    biggestXpoint = cartesianPoint.X;

                if (cartesianPoint.Y < smallestYpoint)
					smallestYpoint = cartesianPoint.Y;

               if (cartesianPoint.Y > biggestYpoint)
                    biggestYpoint = cartesianPoint.Y;											
            }

            return ((Math.Abs(smallestXpoint) + biggestXpoint) * (Math.Abs(smallestYpoint) + biggestYpoint));
        }
    }
}
