namespace SmallestDifferent
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            int[] expected = { 20, 17 };
            int[] arrayOne = new int[] { -1, 5, 10, 20, 3 };
            int[] arrayTwo = new int[] { 26, 134, 135, 15, 17 };

            SmallestDifferenceV2(arrayOne, arrayTwo);
        }

        //O(n^2)
        public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
        {
            int different = int.MaxValue;
            int indexI = 0, indexJ = 0;

            for (int i = 0; i < arrayOne.Length; i++)
            {
                for (int j = 0; j < arrayTwo.Length; j++)
                {
                    int result = Math.Abs(arrayOne[i] - arrayTwo[j]);
                    if (result == 0) return new int[] { arrayOne[i], arrayTwo[j] };

                    if (result < different)
                    {
                        different = result;
                        indexI = i;
                        indexJ = j;
                    }
                }
            }

            if(different > 0) return new int[] { arrayOne[indexI], arrayTwo[indexJ] };

            // Write your code here.
            return new int[] { };
        }

        //O(NlogN + MlogM)
        public static int[] SmallestDifferenceV2(int[] arrayOne, int[] arrayTwo)
        {
            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);

            int smallest = int.MaxValue;
            int indOne = 0;
            int indTwo = 0;

            int[] smallestPair = Array.Empty<int>();

            while(indOne < arrayOne.Length && indTwo < arrayTwo.Length)
            {
                int firstNum = arrayOne[indOne];
                int secondNum = arrayTwo[indTwo];

                if (firstNum == secondNum) return new int[] { firstNum, secondNum };

                if (firstNum < secondNum)
                {
                    indOne++;
                }
                else { 
                    indTwo++; 
                }

                int current = Math.Abs(firstNum - secondNum);
                if (smallest > current)
                {
                    smallest = current;
                    smallestPair = new int[] { firstNum, secondNum };
                }
            }
            return smallestPair;
        }

    }


}