using System;
using System.IO;

namespace Pr22
{
    public class Euler
    {
        public static void Main(string[] args)
        {
            string raw_input = File.ReadAllLines("./p022_names.txt")[0];
            string[] names = raw_input.Replace("\"","").Split(',');
            Array.Sort(names);
            
            int i = 0;
            int name_score;
            int total_score = 0;
            foreach(string name in names)
            {
                name_score = 0;

                foreach(char c in name)
                {
                    name_score += (int) c - 64;
                }

                total_score += name_score * ++i; 
            }

            Console.WriteLine(total_score);
        }
    }
}