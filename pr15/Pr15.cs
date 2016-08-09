using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static long[] BuildArray(int size)
        {
            var built_array = new long[size + 1];
            built_array[0] = 1;

            if(size != 1)
            {
                var smaller_builder = BuildArray(size - 1);

                for(int i = 1; i < smaller_builder.Length; i++)
                {
                    built_array[i] = built_array[i - 1] + smaller_builder[i];
                }
            }

            built_array[size] = built_array[size - 1] * 2;

            return built_array;
        }
        public static void Main(string[] args)
        {
            var euler_array = BuildArray(Int32.Parse(args[0]));

            Console.WriteLine(euler_array[euler_array.Length - 1]);
        }
    }
}
