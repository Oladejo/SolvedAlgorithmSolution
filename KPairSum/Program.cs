using System;
using System.Collections.Generic;
using System.Linq;

namespace KPairSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        //Brute Force
        static IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {

            var result = new List<IList<int>>();
            int arrLength1 = Math.Min(nums1.Length, k);
            int arrLength2 = Math.Min(nums2.Length, k);

            for (int i = 0; i < arrLength1; i++)
            {
                for (int j = 0; j < arrLength2; j++)
                {
                    result.Add(new List<int>() { nums1[i], nums2[j] });
                }
            }

            //This process cause Out of memory issue
            return result.OrderBy(x => x.Sum()).Take(k).ToList();
        }

        static IList<IList<int>> KSmallestPairs2(int[] nums1, int[] nums2, int k)
        {
            var result = new List<IList<int>>();
            int arrLength1 = Math.Min(nums1.Length, k);
            int arrLength2 = Math.Min(nums2.Length, k);

            for (int i = 0; i < arrLength1; i++)
            {
                for (int j = 0; j < arrLength2; j++)
                {
                    result.Add(new List<int>() { nums1[i], nums2[j] });
                }
            }

            result.Sort((x, y) => (x[0] + x[1]) - (y[0] + y[1]));

            var finalResult = new List<IList<int>>();

            for(int i = 0; i < Math.Min(k, result.Count); i++)
            {
                finalResult.Add(result[i]);
            }

            return finalResult;
        }

        //
        static IList<IList<int>> KSmallestPairs3(int[] nums1, int[] nums2, int k)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (nums1 == null || nums1.Length == 0 || nums2 == null || nums2.Length == 0 || k == 0)
                return result;

            // use SortedDictionary mimic min-heap to maintain the first k min pairs 
            // note: SortedDictionary.First() runs in O(logN) rather than O(1)

            SortedDictionary<int, Queue<List<int>>> dictionary = new SortedDictionary<int, Queue<List<int>>>();


            // add all the possible min pairs to the SortedDictionary
            // since the arrays are sorted, for a given nums1[i], the possible min pairs would be: nums1[i] + nums2[0]
            int arrLength = Math.Min(nums1.Length, k);
            for (int i = 0; i < arrLength; i++)
            {
                int sum = nums1[i] + nums2[0];
                if (dictionary.ContainsKey(sum))
                    dictionary[sum].Enqueue(new List<int>() { nums1[i], nums2[0], 0 });
                else
                {
                    Queue<List<int>> queue = new Queue<List<int>>();
                    queue.Enqueue(new List<int>() { nums1[i], nums2[0], 0 });
                    dictionary.Add(sum, queue);
                }
            }

            while (dictionary.Count > 0)
            {
                // get the current min pair
                var minPair = dictionary.First();
                var min = dictionary[minPair.Key].Dequeue();
                result.Add(new List<int>() { min[0], min[1] });
                if (result.Count == k)
                    return result;
                if (dictionary[minPair.Key].Count == 0)
                    dictionary.Remove(minPair.Key);

                // after getting the current min pair, the next min pair could be genereated in two ways:
                // (1) nums1[current] + nums2[current + 1]
                // (2) nums1[current + 1] + nums2[current]
                // there are at most nums1.Length pairs will be added to the result
                // so case (1) has been covered when initlizing the sorted dictionary
                // so we only need to consider case (2)
                int idx = min[2] + 1;
                if (idx < nums2.Length)
                {
                    int sum = min[0] + nums2[idx];
                    if (dictionary.ContainsKey(sum))
                        dictionary[sum].Enqueue(new List<int>() { min[0], nums2[idx], idx });
                    else
                    {
                        Queue<List<int>> queue = new Queue<List<int>>();
                        queue.Enqueue(new List<int>() { min[0], nums2[idx], idx });
                        dictionary.Add(sum, queue);
                    }
                }
            }

            return result;

        }
                
        //successful
        static IList<IList<int>> KSmallestPairsUsingPriorityQueue(int[] nums1, int[] nums2, int k)
        {
            var result = new List<IList<int>>();
            //min heap, store indexes in nums1 and nums2, sort by nums1[i]+nums2[j]
            var priorityQueue = new PriorityQueue<int[], int>();

            int arrLength1 = Math.Min(nums1.Length, k);
            int arrLength2 = nums2.Length;

            for (int i = 0; i < arrLength1; i++)
            {
                //enqueue atmost Math.Min(len1,k) count of [i,0] combines, auto sorted by nums1[i] + nums2[0]
                //{nums1[0],nums2[0]} always the first element
                priorityQueue.Enqueue(new int[] { i, 0 }, nums1[i] + nums2[0]);
            }

            while (k-- > 0 && priorityQueue.Count > 0)
            {
                var first = priorityQueue.Dequeue();
                int i = first[0];
                int j = first[1];
                //the first element must be {nums1[0],nums2[0]} , we add it to result
                result.Add(new List<int>() { nums1[i], nums2[j] });

                //every time we add [i,j] to ans, then j=j+1, enqueue nums1[i]+nums2[j+1] if possible, so we will never miss any combines
                if (++j < arrLength2)
                {
                    priorityQueue.Enqueue(new int[] { i, j }, nums1[i] + nums2[j]);
                }
            }

            return result;

        }
    }
}
