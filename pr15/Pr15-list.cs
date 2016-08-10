using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplicationList
{
    public class Program
    {
        static List<long> BuildLatticeRow(int size)
        {
            var latticeRow = new List<long>();
            latticeRow.Add(1);

            if (size != 1)
            {
                var prevLatticeRow = BuildLatticeRow(size - 1);

                for (int i = 1; i < prevLatticeRow.Count; i++)
                {
                    latticeRow.Add(latticeRow.Last() + prevLatticeRow[i]);
                }
            }

            latticeRow.Add(latticeRow.Last() * 2);

            return latticeRow;
        }
        public static void ListMain(string[] args)
        {
            var latticeRow = BuildLatticeRow(int.Parse(args[0]));

            Console.WriteLine(latticeRow[latticeRow.Count - 1]);
        }
    }
}
