namespace MovingMedian
{
    public class Program
    {
        public static int[] GetSlidingWindow(int[] listOfNumbers,int sourceIndex, int newArrayLength)
        {
            var arraySlide = new int[newArrayLength];

            try
            {
                if (listOfNumbers.Length == 0) return Array.Empty<int>();

                Array.Copy(listOfNumbers, sourceIndex, arraySlide, 0, newArrayLength);
                return arraySlide;
            }
            catch
            {
                return Array.Empty<int>();
            }
        }

        private static int GetMedianFromCurrentWindow(int[] window)
        {
            //must always contain data 
            if(window.Length == 0) throw new Exception("Data is null");

            Array.Sort(window);
            if ((window.Length % 2) == 0)
            {
                int i1 = window.Length / 2;
                //return (window[i1] + window[i1 + 1]) / 2;

                return (window[i1 - 1] + window[i1]) / 2;
            }

            int i = (window.Length - 1) / 2;
            return window[i];
        }

        private static List<int> GetNextSlidingWindow(int[] listOfNumbers, int sourceIndex, int newArrayLength, List<int> result)
        {            
            var currentWindow = GetSlidingWindow(listOfNumbers, sourceIndex, newArrayLength);
            if (currentWindow.Length > 0)
            {
                result.Add(GetMedianFromCurrentWindow(currentWindow));
                GetNextSlidingWindow(listOfNumbers, ++sourceIndex, newArrayLength, result);
            }
            return result;
        }

        public static string ArrayChallenge(int[] arr)
        {
            List<int> result = new();
            
            int sourceIndex = arr[0];

            int[] listOfNumbers = new int[arr.Length - 1];

            Array.Copy(arr, 1, listOfNumbers, 0, arr.Length - 1);

            int[] listOfNumbers2 = new int[arr.Length - 1];

            Array.Copy(arr, 1, listOfNumbers2, 0, arr.Length - 1);
            Array.Sort(listOfNumbers2);

            int i = 1;
            while (i < sourceIndex && listOfNumbers2.Length > 0)
            {
                if (i >= listOfNumbers2[0])
                {
                    if (listOfNumbers2[0] < 0)
                    {
                        result.Add(0);
                    }
                    else
                    {
                        result.Add(i);
                    }
                }
                i++;
            }

            result = GetNextSlidingWindow(listOfNumbers, 0, sourceIndex, result);

            return string.Join(", ", result.ToArray());
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine(ArrayChallenge(new int[] { 3, 1, 3, 5, 10, 6, 4, 3, 1 }));
            Console.WriteLine(ArrayChallenge(new int[] { 5, 2, 4, 6 }));
            Console.WriteLine(ArrayChallenge(new int[] { 3, 0, 0, -2, 0, 2, 0, -2 }));

            //var SlidingWindowMedian = new SlidingWindowMedian();
            //var result = SlidingWindowMedian.MedianSlidingWindow(new int[] { 2147483647, 2147483647 }, 2);
            //Console.WriteLine(string.Join(", ", result.ToArray()));

            Console.ReadLine();
        }

    }
}