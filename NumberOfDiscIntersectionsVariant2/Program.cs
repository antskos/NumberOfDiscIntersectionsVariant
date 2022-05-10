using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfDiscIntersections
{
    public class MySolution
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 1, 2147483647, 0 };
            //int[] A = new int[] { 1, 5, 2, 1, 4, 0 };
            //int[] A = Enumerable.Repeat(2, 3).ToArray();
            int intersections = CountIntersections(A);
            Console.WriteLine($"Количество пересечений {intersections}");
        }

        public static int CountIntersections(int[] A)
        {
            if((A == null) || (A.Length <= 1)) return 0;

            var query = Enumerable.Range(0, A.Length).Select
                                                     (
                                                        i => new Tuple<int, int>(i - A[i] < 0 ? 0 : i - A[i],
                                                        (uint)i + (uint)A[i] > (uint)A.Length - 1 ? A.Length - 1 : i + A[i])
                                                     )
                                                     .OrderBy(i => i.Item1)
                                                     .ToArray();
                                                      
            foreach (var item in query)
            {
                Console.WriteLine($"Ячейка {item}");
            }
            Console.WriteLine();


            int intersections = 0;

            for (int i = 1; i < query.Count(); i++)
            {
                if (intersections >= 10000000) return -1;
                intersections += CountItems(query, i, query[i - 1].Item2);
            }

            return intersections;
        }

        static int CountItems(Tuple<int,int>[] A, int i, int curR) 
        {
            int counter = 0;
            while (i < A.Length)
            {
                if (curR >= A[i].Item1)
                {
                    counter++;
                }
                else break;
                i++;
            }
            return counter;
        }


    }
}

