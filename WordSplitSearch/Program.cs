namespace WordSplitSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string[] data = new string[] { "hellocat", "apple, bat,cat,goodbye,hello,yellow,why" };

            Console.WriteLine(WordSplit(data));
        }

        private static string WordSplit(string[] data)
        {
            if(data.Length == 2)
            {
                string wordToSplit = data[0];

                HashSet<string> wordToSearch = new HashSet<string>(data[1].Split(","));

                foreach (string word in wordToSearch)
                {
                    if (wordToSplit.StartsWith(word))
                    {
                        string endWord = wordToSplit.Substring(word.Length);

                        if (wordToSearch.Contains(endWord))
                        {
                            return $"{word},{endWord}";
                        }
                    }

                    if (wordToSplit.EndsWith(word))
                    {
                        string startWord = wordToSplit.Substring(0, wordToSplit.Length - word.Length);

                        if (wordToSearch.Contains(startWord))
                        {
                            return $"{startWord}, {word}";
                        }
                    }
                }
            }

            return "Not Possible";
        }


    }
}