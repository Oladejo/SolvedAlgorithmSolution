using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MartianArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine($"Result 1 { GetRecipient("@User_One @UserABC! Have you seen this from @Userxyz?", 1)}");
            Console.WriteLine($"Result 2 { GetRecipient2("@User_One @UserABC! Have you seen this from @Userxyz?", 1)}");

            //int[] arrayOfNumbers1 = { 1, 3 };
            //int[] arrayOfNumbers2 = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            //int[] arrayOfNumbers3 = { 1, 3, 2 };
            //int[] arrayOfNumbers4 = { 1, 3, 3, 2 , 1 };
            //int[] arrayOfNumbers5 = { 1, 2, -18, -18, 1, 2 };
            //int[] arrayOfNumbers6 = { };
            //int[] arrayOfNumbers7 = { 1 };
            //int[] arrayOfNumbers8 = { 2 };
            //int[] arrayOfNumbers9 = { 1, 2, 3 };
            //int[] arrayOfNumbers10 = { 1, 3, 2, 2, 1, 5, 1, 5 };


            //Console.WriteLine(isMartian(arrayOfNumbers1));
            //Console.WriteLine(isMartian(arrayOfNumbers2));
            //Console.WriteLine(isMartian(arrayOfNumbers3));
            //Console.WriteLine(isMartian(arrayOfNumbers4));
            //Console.WriteLine(isMartian(arrayOfNumbers5));
            //Console.WriteLine(isMartian(arrayOfNumbers6));
            //Console.WriteLine(isMartian(arrayOfNumbers7));
            //Console.WriteLine(isMartian(arrayOfNumbers8));
            //Console.WriteLine(isMartian(arrayOfNumbers9));
            //Console.WriteLine(isMartian(arrayOfNumbers10));

            //Console.WriteLine(closestFibonacci(12));
            //Console.WriteLine(closestFibonacci(33));
            //Console.WriteLine(closestFibonacci(34));
            //Console.WriteLine(closestFibonacci(3));
            //Console.WriteLine(closestFibonacci(4));

            //int[] arrayOfNumbers1 = { 1, 2, 3, 4, 5 };
            //int[] arrayOfNumbers2 = { 1, 3, 5};
            //int[] arrayOfNumbers3 = { 2, 4, 6 };
            //int[] arrayOfNumbers4 = { 1 };
            //int[] arrayOfNumbers5 = { 2 };
            //int[] arrayOfNumbers6 = { 0, 0, 0, 0, 0 };

            //Console.WriteLine(computeWeightedSum(arrayOfNumbers1));
            //Console.WriteLine(computeWeightedSum(arrayOfNumbers2));
            //Console.WriteLine(computeWeightedSum(arrayOfNumbers3));
            //Console.WriteLine(computeWeightedSum(arrayOfNumbers4));
            //Console.WriteLine(computeWeightedSum(arrayOfNumbers5));
            //Console.WriteLine(computeWeightedSum(arrayOfNumbers6));


            int[] arrayOfNumbers1a = { 0, 1, 2 };
            int[] arrayOfNumbers1b = { 2, 0, 1 };

            int[] arrayOfNumbers2a = { 0, 1, 2, 1 };
            int[] arrayOfNumbers2b = { 2, 0, 1 };

            int[] arrayOfNumbers3a = { 2, 0, 1 };
            int[] arrayOfNumbers3b = { 0, 1, 2, 1 };

            int[] arrayOfNumbers4a = { 0, 5, 5, 5, 1, 2, 1 };
            int[] arrayOfNumbers4b = { 5, 2, 0, 1 };

            int[] arrayOfNumbers5a = { 5, 2, 0, 1 };
            int[] arrayOfNumbers5b = { 0, 5, 5, 5, 1, 2, 1 };

            int[] arrayOfNumbers6a = { 0, 2, 1, 2 };
            int[] arrayOfNumbers6b = { 3, 1, 2, 0 };


            int[] arrayOfNumbers7a = { 3, 1, 2, 0 };
            int[] arrayOfNumbers7b = { 0, 2, 1, 0 };

            int[] arrayOfNumbers8a = { 1, 1, 1, 1, 1, 1 };
            int[] arrayOfNumbers8b = { 1, 1, 1, 1, 1, 2 };

            int[] arrayOfNumbers9a = {  };
            int[] arrayOfNumbers9b = { 3, 1, 1, 1, 1, 2 };

            int[] arrayOfNumbers10a = { };
            int[] arrayOfNumbers10b = { };

            //Console.WriteLine(equivalentArrays(arrayOfNumbers1a, arrayOfNumbers1b));
            //Console.WriteLine(equivalentArrays(arrayOfNumbers2a, arrayOfNumbers2b));
            //Console.WriteLine(equivalentArrays(arrayOfNumbers3a, arrayOfNumbers3b));
            //Console.WriteLine(equivalentArrays(arrayOfNumbers4a, arrayOfNumbers4b));
            //Console.WriteLine(equivalentArrays(arrayOfNumbers5a, arrayOfNumbers5b));
            //Console.WriteLine(equivalentArrays(arrayOfNumbers6a, arrayOfNumbers6b));
            //Console.WriteLine(equivalentArrays(arrayOfNumbers7a, arrayOfNumbers7b));
            //Console.WriteLine(equivalentArrays(arrayOfNumbers8a, arrayOfNumbers8b));
            //Console.WriteLine(equivalentArrays(arrayOfNumbers9a, arrayOfNumbers9b));
            //Console.WriteLine(equivalentArrays(arrayOfNumbers10a, arrayOfNumbers10b));



        }

        public static string GetRecipient(string message, int position)
        {
            // Your code goes here
            string result = "";

            if (!string.IsNullOrWhiteSpace(message))
            {
                var data = new Regex("@[0-9A-Za-z_-]+", RegexOptions.Compiled);

                var match = data.Matches(message);
                var holder = new string[match.Count];

                //o(n)
                for (int i = 0; i < match.Count; i++)
                {
                    holder[i] = match[i].Value.Replace("@", ""); //o(1)
                }

                try
                {
                    result = holder[position - 1]; //0(1)
                }
                catch (IndexOutOfRangeException) { }
            }

            return result;
        }

        public static string GetRecipient2(string message, int position)
        {
            // Your code goes here
            string result = "";

            if (!string.IsNullOrWhiteSpace(message))
            {
                Regex data = new Regex("@[0-9A-Za-z_-]+", RegexOptions.Compiled);

                MatchCollection match = data.Matches(message);

                if(position > 0)
                {
                    position -= 1;
                }

                for (int i = 0; i < match.Count; i++)
                {
                    if (position == i)
                    {
                        return match[i].Value.Replace("@", "");
                    }
                }
            }

            return result;
        }

        public static int isMartian(int[] a)
        {
            int arrayLength = a.Length;

            if(arrayLength == 0) return 0;

            if(arrayLength == 1) return a[0] == 1 ? 1 : 0;

            int countOnes = 0;
            int countTwos = 0;
            int lastStep = a[0];

            if (lastStep == 1) countOnes++;
            if(lastStep == 2) countTwos++;

            for (int i = 1; i < arrayLength; i++)
            {
                if(lastStep == a[i]) return 0; 

                if (a[i] == 1) countOnes++;

                if (a[i] == 2) countTwos++;

                lastStep = a[i];
            }

            if(countOnes > countTwos) return 1;

            return 0;
        }

        public static int closestFibonacci(int n)
        {
            if(n == 0) return 0;

            if(n == 1 || n == 2) return 1;

            int n1 = 1;
            int n2 = 1;
            int result = 0;

            for (int i = 3; i <= n; i++)
            {
                result = n1 + n2;  

                if(result > n) return n2;

                if(result == n - 1  || result == n ) return result;

                n1 = n2;
                n2 = result;
            }

            return result;
        }

        public static int computeWeightedSum(int[] a)
        {
            int even = 0;
            int odd = 0;

            for(int i = 0; i < a.Length; i++)
            {
                if(a[i] % 2 == 0)
                {
                    even += a[i];
                }
                else
                {
                    odd += a[i];
                }
            }

            return 2*even + 3*odd;
        }

        public static int equivalentArrays(int[] a1, int[] a2)
        {
            int a1Length = a1.Length;
            int a2Length = a2.Length;
            int result = 0;

            if(a1Length == 0 && a2Length == 0) return 1;

            HashSet<int> basket = new HashSet<int>();

            for (int i = 0; i < a1Length; i++)
            {
                if (!basket.Contains(a1[i]))
                {
                    basket.Add(a1[i]);
                }
            }

            for (int i = 0; i < a2Length; i++)
            {
                if (!basket.Contains(a2[i]))
                {
                    basket.Add(a2[i]);
                }
            }

            foreach(int i in basket)
            {
                if (isPresent(a1, i) && isPresent(a2, i))
                {
                    result = 1;
                }
                else
                {
                    return 0;
                }
            }

            return result;
        }

        public static bool isPresent(int[] array, int value)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] == value) return true;
            }

            return false;
        }


    }
}





