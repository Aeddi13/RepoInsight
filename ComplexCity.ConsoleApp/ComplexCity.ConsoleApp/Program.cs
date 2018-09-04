using System;
using ComplexCity.BusinessLogic;

namespace ComplexCity.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = "E:\\Aeddimedia\\Development\\MealPlanner\\Server\\src";

            string headerMessage = String.Format("Checking files for directory {0}", directoryPath);
            Console.WriteLine(headerMessage);

            FileInfo[] fileInfos = FileInfoFactory.CreateFilesForDirectory(directoryPath);

            foreach (FileInfo fileInfo in fileInfos)
            {
                Console.Write(fileInfo.FileName);
                Console.Write(" | lines of code: " + fileInfo.LinesOfCode);
                Console.Write(" | number of leading spaces: " + fileInfo.NumberOfLeadingSpaces);
                Console.WriteLine(" | spaces per line " + fileInfo.GetLeadingSpacesPerLine());
            }

            Console.ReadLine();
        }
    }
}
