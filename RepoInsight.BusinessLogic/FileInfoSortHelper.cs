namespace RepoInsight.BusinessLogic
{
    /// <summary>
    /// Contains helper methods to sort enumerations of <see cref="FileInfo"/>.
    /// </summary>
    public static class FileInfoSortHelper
    {
        /// <summary>
        /// Compares two <see cref="FileInfo"/> by their leading spaces per line.
        /// </summary>
        /// <param name="x">The first <see cref="FileInfo"/> to compare.</param>
        /// <param name="y">The second <see cref="FileInfo"/> to compare.</param>
        /// <returns>A <see cref="int"/> value.
        /// When the LeadingSpacesPerLine of x are greater than those of y it returns -1;
        /// When the LeadingSpacesPerLine of x are smaller than those of y it returns 1;
        /// When the LeadingSpacesPerLine of x are equal to those of y it returns 0;
        /// </returns>
        public static int CompareFileInfosByLeadingSpacesPerLine(FileInfo x, FileInfo y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the leading spaces per line
                    double difference = x.GetLeadingSpacesPerLine() - y.GetLeadingSpacesPerLine();

                    if (difference < 0)
                    {
                        return -1;
                    }
                    else if (difference > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// Compares two <see cref="FileInfo"/> by their lines of code.
        /// </summary>
        /// <param name="x">The first <see cref="FileInfo"/> to compare.</param>
        /// <param name="y">The second <see cref="FileInfo"/> to compare.</param>
        /// <returns>A <see cref="int"/> value.
        /// When the LinesOfCode of x are greater than those of y it returns -1;
        /// When the LinesOfCode of x are smaller than those of y it returns 1;
        /// When the LinesOfCode of x are equal to those of y it returns 0;
        /// </returns>
        public static int CompareFileInfosByLinesOfCode(FileInfo x, FileInfo y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the lines of code
                    double difference = x.LinesOfCode - y.LinesOfCode;

                    if (difference < 0)
                    {
                        return -1;
                    }
                    else if (difference > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
}
