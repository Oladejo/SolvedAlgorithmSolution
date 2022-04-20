using System;
using System.Collections.Generic;

namespace SubSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] arr = { 1, 2, 3};
            var result = Subsets(arr);
            DisplaySubset(result);

            var sum = GetSumofSubsets(arr);
            DisplaySumofSubset(sum);

        }

        public static void DisplaySubset(IList<IList<int>> subsets)
        {
            int j = 1;
            Console.Write("[");
            foreach (var i in subsets)
            {
                Console.Write($"[{String.Join(",", i)}]");
                if (j < subsets.Count)
                {
                    Console.Write(",");
                }
                j++;
            }
            Console.Write("]");
        }

        public static IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> subsets = new List<IList<int>>();
            int count = nums.Length;

            generateSubSet(0,
                           nums, 
                           count,
                           new List<int>(),
                           subsets);

            return subsets;
        }

        public static void generateSubSet(int index, int[] nums, int count, List<int> current, List<IList<int>> subsets)
        {
            subsets.Add(new List<int>(current));
            
            for (int i = index; i < count; i++)
            {
                current.Add(nums[i]);
                generateSubSet(i + 1, nums, count, current, subsets);
                current.RemoveAt(current.Count - 1);
            }
        }

        //Get the sum of each subset and return it
        public static void DisplaySumofSubset(IList<int> subsets)
        {
            Console.WriteLine();
            Console.Write($"[{String.Join(",", subsets)}]");
        }

        public static IList<int> GetSumofSubsets(int[] nums)
        {
            List<int> sumOfSubSet = new();
            int count = nums.Length;

            GenerateSumofSubSet(0,
                           nums,
                           count,
                           new List<int>(),
                           sumOfSubSet);

            return sumOfSubSet;
        }

        public static void GenerateSumofSubSet(int index, int[] nums, int count, IList<int> current, IList<int> sumOfSubSet)
        {
            sumOfSubSet.Add(ArraySum(current));

            for (int i = index; i < count; i++)
            {
                current.Add(nums[i]);
                GenerateSumofSubSet(i + 1, nums, count, current, sumOfSubSet);
                current.RemoveAt(current.Count - 1);
            }
        }

        public static int ArraySum(IList<int> current)
        {
            int sum = 0;
            foreach (var item in current)
            {
                sum += item;
            }
            return sum;
        }
    }


}
