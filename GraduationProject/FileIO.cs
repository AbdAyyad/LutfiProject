using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace GraduationProject
{
    class FileIO
    {
        private FileIO() { }

        public static void WriteBytesToFile(string fileName, byte[] fileContent)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.CreateNew);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            fileContent.ToList().ForEach(item => streamWriter.WriteLine(item));
            streamWriter.Flush();
            streamWriter.Close();
        }

        public static void WriteToFile(string fileName, string fileContent)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.CreateNew);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            streamWriter.WriteLine(fileContent);
            streamWriter.Flush();
            streamWriter.Close();
        }

        public static byte[] ReadBytesFromFile(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            StreamReader streamReader = new StreamReader(fileStream);
            List<byte> list = new List<byte>();

            while (!streamReader.EndOfStream)
            {
                list.Add(Byte.Parse(streamReader.ReadLine()));
            }

            streamReader.Close();
            return list.ToArray();
        }

        public static byte[] ReadFromFile(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            StreamReader streamReader = new StreamReader(fileStream);
            StringBuilder str = new StringBuilder();

            while (!streamReader.EndOfStream)
            {
                str.Append(streamReader.ReadLine());
            }

            streamReader.Close();
            return Encoding.ASCII.GetBytes(str.ToString());
        }
    }
}
