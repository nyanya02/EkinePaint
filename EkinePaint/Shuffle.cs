using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EkinePaint
{
    public static class Shuffle
    {
        public static string[] ReadImage(string fileDirectoryName)
        {
            string[] fileAll = Directory.GetFiles(fileDirectoryName, "*");

            return fileAll;
        }

        public static string[] ShuffleImage(string[] fileAll)
        {
            Random random = new Random();
            int n = fileAll.Length;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string l = fileAll[k];
                fileAll[k] = fileAll[n];
                fileAll[n] = l;
            }

            return fileAll;
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();

            int num = random.Next(min, max);

            return num;
        }
    }
}
