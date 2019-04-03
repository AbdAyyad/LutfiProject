using System;
using System.IO.Compression;
using System.IO;
using System.Text;
using System.Linq;

namespace GraduationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("enter docx file path: ");
            //string docxPath = Console.ReadLine();
            string docxPath = @"abc.docx";
            string directory = RandomGenerator.GetRandomString();
            Compressor.UnZip(docxPath, directory);
            RsaEncryption cypher = new RsaEncryption();

            //Console.Write("enter the path for the file we want hide: ");
            //string fileToHide = Console.ReadLine();
            string fileToHide = @"file.txt";
            byte[] data = FileIO.ReadFromFile(fileToHide);
            Console.WriteLine("plain text: ");
            data.ToList().ForEach(item => Console.Write("{0} ", item));

            data = cypher.Encrypt(data);
            Console.WriteLine("encrpted text: ");
            data.ToList().ForEach(item => Console.Write("{0} ", item));
            Console.WriteLine();

            FileIO.WriteBytesToFile("encrypted.txt", data);
            File.Copy("encrypted.txt", directory + "/" + fileToHide);
            Compressor.Zip(directory, "new" + docxPath);
            Directory.Delete(directory, true);
            File.Delete("encrypted.txt");

            FileIO.WriteToFile("publicKey.xml", cypher.PublicKeyXml);
            Console.WriteLine("public key:");
            Console.WriteLine(cypher.PublicKeyXml);
            Console.WriteLine();

            FileIO.WriteToFile("privateKey.xml", cypher.PrivateKeyXml);
            Console.WriteLine("private key:");
            Console.WriteLine(cypher.PrivateKeyXml);
            Console.WriteLine();

        }
    }
}
