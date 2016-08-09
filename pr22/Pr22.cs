using System;
using System.IO;

namespace Pr22
{
    public class Euler
    {
        public static void Main(string[] args)
        {
            var raw_input = File.ReadAllText("./p022_names.txt");
            var names = raw_input.Replace("\"","").Split(',');
            Array.Sort(names);
            
            var i = 0;
            var total_score = 0;
            foreach(var name in names)
            {
                var name_score = 0;

                foreach(var c in name)
                {
                    name_score += (int) c - 64;
                }

                total_score += name_score * ++i; 
            }

            Console.WriteLine(total_score);
        }
    }
}