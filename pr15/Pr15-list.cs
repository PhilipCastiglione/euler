using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplicationList
{
    public class Program
    {
        public static List<long> BuildArray(int size)
        {
            var built_array = new List<long>();
            built_array.Add(1);

            if(size != 1)
            {
                var smaller_builder = BuildArray(size - 1);

                for(int i = 1; i < smaller_builder.Count; i++)
                {
                    built_array.Add(built_array.Last() + smaller_builder[i]);
                }
            }

            built_array.Add(built_array.Last() * 2);

            return built_array;
        }
        public static void ListMain(string[] args)
        {
            var euler_array = BuildArray(Int32.Parse(args[0]));

            Console.WriteLine(euler_array[euler_array.Count - 1]);
        }
    }
}
