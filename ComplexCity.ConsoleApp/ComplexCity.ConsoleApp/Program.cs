using System;
using Complexity.BusinessLogic;

namespace ComplexCity.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            File[] files = FileFactory.CreateFilesForDirectory("D:\\temp\\text");

            foreach (File file in files)
            {
                Console.WriteLine(file.FileName);
                Console.WriteLine("lines of code: " + file.LinesOfCode);
                Console.WriteLine("number of leading spaces: " + file.NumberOfLeadingSpaces);
            }

            Console.ReadLine();
        }
    }
}
