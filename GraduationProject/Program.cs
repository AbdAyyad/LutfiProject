using System;
using System.IO.Compression;
using System.IO;

namespace GraduationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter docx file path: ");
            //string docxPath = Console.ReadLine();
            string docxPath = @"C:\Users\abday\Desktop\New Microsoft Word Document.docx";
            string directory = RandomGenerator.GetRandomString();
            Compressor.UnZip(docxPath, directory);
            Console.Write("enter the path for the file we want hide: ");
            string fileToHide = Console.ReadLine();
            File.Copy(fileToHide, directory + "/" + fileToHide);
            Compressor.Zip(directory, "new" + docxPath);
            Directory.Delete(directory, true);
        }
    }
}
