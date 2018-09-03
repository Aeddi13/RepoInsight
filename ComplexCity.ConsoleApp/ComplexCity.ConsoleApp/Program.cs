using System;
using Complexity.BusinessLogic;

namespace ComplexCity.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FileInfo[] fileInfos = FileFactory.CreateFilesForDirectory("D:\\temp");

            foreach (FileInfo fileInfo in fileInfos)
            {
                Console.Write(fileInfo.FileName);
                Console.Write(" | lines of code: " + fileInfo.LinesOfCode);
                Console.WriteLine(" | number of leading spaces: " + fileInfo.NumberOfLeadingSpaces);
            }

            Console.ReadLine();
        }
    }
}
