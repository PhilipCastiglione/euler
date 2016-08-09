using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static int[] BuildArray(int size)
        {
            var built_array = new int[size + 1];
            if(size == 1)
            {
                built_array[0] = 1;
            }
            else
            {
                built_array[0] = 0;

                var smaller_builder = BuildArray(size - 1);

                for(int i = 1; i < smaller_builder.Length; i++)
                
                {
                    built_array[i + 1] = built_array[i] + smaller_builder[i - 1];
                    i++;
                }
            }
            built_array[size - 1] = built_array[size - 2] * 2;

            return built_array;
        }
        public static void Main(string[] args)
        {
            var euler_array = BuildArray(3);

            Console.WriteLine(euler_array[euler_array.Length - 1]);
        }
    }
}
