using System;
using System.Collections.Generic;

namespace ValidateSequence
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            int arrayIndex = 0;
            int sequenceIndex = 0;

            while (arrayIndex < array.Count && sequenceIndex < sequence.Count)
            {
                if (array[arrayIndex] == sequence[sequenceIndex])
                {
                    sequenceIndex++;
                }
                arrayIndex++;
            }

            return sequenceIndex == sequence.Count;
        }

        public static bool IsValidSubsequenceV2(List<int> array, List<int> sequence)
        {
            // Write your code here.
            int index = 0;

            foreach (int value in array)
            {
                if (index == sequence.Count)
                {
                    break;
                }

                if (value == sequence[index])
                {
                    index++;
                }
            }

            return index == sequence.Count;
        }
    }

}
