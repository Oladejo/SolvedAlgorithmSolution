namespace MovingMedian
{
    public class ProgramOld
    {
        private static List<double> result = new List<double>();
        private static int[] listOfNumbers { get; set; }
        private static int n = 0;
        private static int sw = 0;

        public static string ArrayChallenge(int[] arr)
        {
            sw = arr[0];

            listOfNumbers = new int[arr.Length - 1];

            Array.Copy(arr, 1, listOfNumbers, 0, arr.Length - 1);


            var listOfNumbers2 = new int[arr.Length - 1];

            Array.Copy(arr, 1, listOfNumbers2, 0, arr.Length - 1);
            Array.Sort(listOfNumbers2);

            int i = 1;
            while (i < sw && listOfNumbers2.Length > 0)
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

            var currentWindow = GetSlidingWindow(listOfNumbers);
            if (currentWindow != null) result.Add(GetMedianFromCurrentWindow(currentWindow));
            GetNextSlidingWindow();

            return string.Join(", ", result.ToArray());
        }

        private static void GetNextSlidingWindow()
        {
            n++;
            var currentWindow = GetSlidingWindow(listOfNumbers);
            if (currentWindow != null)
            {
                result.Add(GetMedianFromCurrentWindow(currentWindow));
                GetNextSlidingWindow();
            }
        }

        private static double GetMedianFromCurrentWindow(int[] window)
        {
            Array.Sort(window);
            if ((window.Length % 2) == 0)
            {
                var i1 = window.Length / 2;
                var i2 = i1 + 1;
                return (double)(window[i1 - 1] + window[i2 - 1]) / 2;
            }
            else
            {
                var i = (window.Length - 1) / 2;
                return window[i];
            }
        }

        private static int[] GetSlidingWindow(int[] listOfNumbers)
        {
            try
            {
                var w = new int[sw];
                Array.Copy(listOfNumbers, n, w, 0, sw);
                return w;
            }
            catch
            {
                return null;
            }
        }


        static void MainOld(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Console.WriteLine(ArrayChallenge(new int[] { 3, 1, 3, 5, 10, 6, 4, 3, 1 }));

            //Console.WriteLine(ArrayChallenge(new int[] { 5, 2, 4, 6 }));

            Console.WriteLine(ArrayChallenge(new int[] { 3, 0, 0, -2, 0, 2, 0, -2 }));

            Console.ReadLine();
        }

    }
}
