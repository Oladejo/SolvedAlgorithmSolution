using System;

namespace TreePathLarger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Tree Path Larger");
        }

        public static string Solition(long[] arr)
        {
            if (arr.Length == 0) return "";

            long leftSum = 0;
            long rightSum = 0;
            leftSum = Sum(arr, 2);
            rightSum = Sum(arr, 3);

            return (leftSum == rightSum) ? "" : (leftSum > rightSum ? "Left" : "Right");
        }

        //it using a recursive process
        private static long Sum(long[] arr, int index)
        {
            if (index - 1 < arr.Length) 
            {
                if (arr[index - 1] == -1) return 0;
                return arr[index - 1] + Sum(arr, index * 2) + Sum(arr, index * 2 + 1);
            }
            return 0;
        }
    }

}
