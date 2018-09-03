using System;
using ComplexCity.BusinessLogic;

namespace ComplexCity.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FileInfo[] fileInfos = FileInfoFactory.CreateFilesForDirectory("E:\\Aeddimedia\\Development\\MealPlanner\\Server\\src");

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
