using System;
using System.Collections.Generic;

namespace TheSumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
			//var data = new int[] { 12, 3, 1, 2, -6, 5, -8, 6 };
			var data = new int[] { -1, 0, 1, 2, -1, -4 };
			int target = 0;

			var watch = new System.Diagnostics.Stopwatch();
			watch.Start();

			var result = ThreeNumberSum(data, target);
		
			foreach (var v in result)
            {
				Console.WriteLine(string.Join(",", v));
            }

			watch.Stop();

			Console.WriteLine($"Task Ends {watch.ElapsedMilliseconds} ms");


			var data2 = new int[] { 7, 6, 4, -1, 1, 2 };
			int target2 = 16;

			watch.Start();
			var result2 = FourNumberSum(data2, target2);

			foreach (var v in result2)
			{
				Console.WriteLine(string.Join(",", v));
			}
			watch.Stop();
			Console.WriteLine($"Task Ends Four sums {watch.ElapsedMilliseconds} ms");


		}

		static List<int[]> ThreeNumberSum(int[] array, int targetSum)
		{
			// Write your code here.
			Array.Sort(array);
			List<int[]> result = new List<int[]>();
			HashSet<string> checkDuplicate = new HashSet<string>();

			for (int i = 0; i < array.Length; i++)
			{
				int left = i + 1;
				int right = array.Length - 1;
				while (left < right)
				{
					int currentSum = array[i] + array[left] + array[right];
					if (currentSum == targetSum)
					{
						int[] triplet = new int[] { array[i], array[left], array[right] };
						string v = string.Join(",", triplet);
						
						if (!checkDuplicate.Contains(v))
                        {
							result.Add(triplet);
							checkDuplicate.Add(v);
						}

						left++;
						right--;
					}
					else if (currentSum < targetSum)
					{
						left++;
					}
					else
					{
						right--;
					}
				}
			}

			return result;
		}

		public static List<int[]> FourNumberSum(int[] array, int targetSum)
		{
			// Write your code here.
			Array.Sort(array);
			List<int[]> result = new List<int[]>();
			HashSet<string> handleDuplicate = new HashSet<string>();
			int length = array.Length;

			for (int i = 0; i < length; i++)
			{
				for (int j = i + 1; j < length; j++)
				{
					int left = j + 1;
					int right = length - 1;

					while (left < right)
					{
						int sum = array[i] + array[j] + array[left] + array[right];
						if (sum == targetSum)
						{
							int[] data = new int[] { array[i], array[j], array[left], array[right] };
							string checkData = string.Join(",", data);

							if (!handleDuplicate.Contains(checkData))
							{
								result.Add(data);
								handleDuplicate.Add(checkData);
							}
							left++;
							right--;
						}
						else if (sum < targetSum)
						{
							left++;
						}
						else
						{
							right--;
						}
					}
				}
			}

			return result;
		}
	}


}
