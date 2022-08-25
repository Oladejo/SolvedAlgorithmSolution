namespace MovingMedian
{
    public class SlidingWindowMedian
    {
        public static double[] MedianSlidingWindow(int[] nums, int k)
        {
            List<double> result = new();

            result = GetNextSlidingWindow(nums, 0, k, result);

            return result.ToArray();
        }

        private static List<double> GetNextSlidingWindow(int[] nums, int sourceIndex, int k, List<double> result)
        {
            var currentWindow = GetSlidingWindow(nums, sourceIndex, k);
            if (currentWindow.Length > 0)
            {
                double dd = GetMedianFromCurrentWindow(currentWindow);
                result.Add(dd);
                GetNextSlidingWindow(nums, ++sourceIndex, k, result);
            }
            return result;
        }

        private static int[] GetSlidingWindow(int[] nums, int sourceIndex, int k)
        {
            var arraySlide = new int[k];
            try
            {
                if (nums.Length == 0) return Array.Empty<int>();

                Array.Copy(nums, sourceIndex, arraySlide, 0, k);
                return arraySlide;
            }
            catch
            {
                return Array.Empty<int>();
            }
        }

        private static double GetMedianFromCurrentWindow(int[] window)
        {
            if (window.Length == 0) throw new Exception("Data is null");
            Array.Sort(window);

            if ((window.Length % 2) == 0)
            {
                int i1 = window.Length / 2;
                return ((double)window[i1 - 1] + (double)window[i1]) / 2;
            }

            int i = (window.Length - 1) / 2;
            return window[i];
        }

    }
}
