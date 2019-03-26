using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;


namespace GraduationProject
{
    class Compressor
    {
        private Compressor() { }

        public static void UnZip(string inputFile, string outputDirectory) {
            ZipFile.ExtractToDirectory(inputFile, outputDirectory);
        }

        public static void Zip(string directory, string outputfile)
        {
            ZipFile.CreateFromDirectory(directory, outputfile);
        }
    }
}
