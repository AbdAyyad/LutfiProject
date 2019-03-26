using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationProject
{
    class RandomGenerator
    {
        private static string allChars;

        static RandomGenerator() {
            allChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        }

        private RandomGenerator() { }

        public static string GetRandomString(int length = 20)
        {
            Random random = new Random();
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < length; ++i) {
                str.Append(allChars[random.Next(allChars.Length)]);
            }
            return str.ToString();
        }
    }
}
