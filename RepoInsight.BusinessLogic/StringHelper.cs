using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoInsight.BusinessLogic
{
    /// <summary>
    /// Contains helper methods for string operations.
    /// </summary>
    public static class StringHelper
    {
        public static bool IsLineAComment(string lineOfCode)
        {
            if (String.IsNullOrEmpty(lineOfCode))
            {
                return false;
            }

            bool retVal = false;

            // replace tabs
            lineOfCode = ReplaceTabsWithWhitespaces(lineOfCode);

            // remove leading whitespaces
            int numberOfLeadingSpaces = lineOfCode.TakeWhile(Char.IsWhiteSpace).Count();
            lineOfCode = lineOfCode.Substring(numberOfLeadingSpaces);

            if (lineOfCode.StartsWith("//"))
            {
                retVal = true;
            }

            if (lineOfCode.StartsWith("/*"))
            {
                retVal = true;
            }

            if (lineOfCode.StartsWith("* "))
            {
                retVal = true;
            }

            if (lineOfCode.StartsWith("<!--"))
            {
                retVal = true;
            }

            if (lineOfCode.StartsWith("#"))
            {
                retVal = true;
            }

            return retVal;
        }

        public static string ReplaceTabsWithWhitespaces(string initialString)
        {
            // replace tabs with 4 whitespaces
            string replacedString = initialString.Replace(Convert.ToChar(9).ToString(), "    ");
            return replacedString;
        }
    }
}
