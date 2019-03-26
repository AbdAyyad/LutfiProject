using System;
using System.IO.Compression;


namespace GraduationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter docx file path: ");
            string path = Console.ReadLine();
            string directory = RandomGenerator.GetRandomString();
            Compressor.UnZip(path, directory);
            //for (int i = 0; i < 5; ++i) {
            //    Console.WriteLine(RandomGenerator.GetRandomString());
            //}
        }
    }
}
