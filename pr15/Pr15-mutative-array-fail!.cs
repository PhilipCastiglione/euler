using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static int[] BuildArray(int size)
        {
            var built_array = new int[size + 1];
            built_array[0] = 1;

            if(size != 1)
            {
                var smaller_builder = BuildArray(size - 1);

                for(int i = 1; i < smaller_builder.Length; i++)
                {
                    built_array[i] = built_array[i - 1] + smaller_builder[i];
                    i++;
                }
            }

            built_array[size] = built_array[size - 1] * 2;

            Console.WriteLine("SIZE: {0}", size);
            Console.WriteLine("ARY LEN: {0}", built_array.Length);
            for(int i = 0; i < built_array.Length; i++)
            {
                Console.WriteLine("ARY IDX {0}: {1}", i, built_array[i]);
            }

            return built_array;
        }
        public static void Main(string[] args)
        {
            var euler_array = BuildArray(Int32.Parse(args[0]));

            Console.WriteLine(euler_array[euler_array.Length - 1]);
        }
    }
}
