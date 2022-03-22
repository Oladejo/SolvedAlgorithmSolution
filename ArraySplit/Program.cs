using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraySplit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //int[] arr = { 1, 2, 3, 4, 5, 5, 5 };
            //int[] arr = { 2, 1, 2, 3, 3, 4 };
            //int[] arr = { 1, 2, 2, 1 };
            int[] arr = { 2, 2 ,3 ,3 ,2 ,2 };

            var result = DivideArray(arr);

            for (int n = 0; n < result.Length; n++)
            {
                // Print the row number
                Console.Write("Row({0}): ", n);

                for (int k = 0; k < result[n].Length; k++)
                {

                    // Print the elements in the row
                   Console.Write("{0} ", result[n][k]);
                }
                Console.WriteLine();
            }
        }

        static int[][] DivideArray(int[] a)
        {
            int arrLength = a.Length;
            
            if(arrLength < 2)
            {
                return Array.Empty<int[]>();
            }

            Array.Sort(a);

            HashSet<int> left = new HashSet<int>() 
            {   
                a[0]
            };
            HashSet<int> right = new HashSet<int>() 
            { 
                a[1]
            };

            for (int i = 2; i < arrLength; i+=2)
            {
                if (!left.Contains(a[i]))
                {
                    left.Add(a[i]);
                }
                else
                {
                    if (!right.Contains(a[i]))
                    {
                        right.Add(a[i]);
                    }
                    else
                    {
                        //return new int[0][];
                        return Array.Empty<int[]>();
                    }
                }


                if (!right.Contains(a[i + 1]))
                {
                    right.Add(a[i + 1]);
                }
                else
                {
                    if (!left.Contains(a[i + 1]))
                    {
                        left.Add(a[i + 1]);
                    }
                    else
                    {
                        return Array.Empty<int[]>();
                    }
                }
            }

            if (left.Count == right.Count)
            {
                int[][] jaggedArr = new int[2][];
                jaggedArr[0] = left.ToArray();
                jaggedArr[1] = right.ToArray();
                return jaggedArr;
            }

            return Array.Empty<int[]>();
        }
    }
}
