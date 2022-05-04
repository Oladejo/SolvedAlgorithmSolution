using System;
using System.Collections.Generic;

namespace CurrencyConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Currency Conversion!");
            List<Node> nodes = new List<Node>();
            nodes.Add(new Node("USD", "JPY", 110));
            nodes.Add(new Node("USD", "AUD", 1.45));
            nodes.Add(new Node("JPY", "GBP", 0.0070));

            Console.WriteLine(GetRatio("GBP", "AUD", nodes));
            Console.WriteLine(GetRatio("AUD", "JPY", nodes));
        }

        public static double GetRatio(string start, string end, List<Node> data)
        {
            Dictionary<string, Dictionary<string, double>> map = MapData(data);

            Queue<string> queue = new Queue<string>();
            Queue<double> queueRatio = new Queue<double>();

            queue.Enqueue(start);
            queueRatio.Enqueue(1.0); 

            HashSet<string> visited = new();

            while(queue.Count > 0)
            {
                string current = queue.Dequeue();
                double currentRatio = queueRatio.Dequeue();

                if (visited.Contains(current)) continue;

                visited.Add(current);

                if (map.ContainsKey(current))
                {
                    Dictionary<string, double> next = map[current];
                    foreach (string key in next.Keys)
                    {
                        if (!visited.Contains(key))
                        {
                            queue.Enqueue(key);
                            if (key.Equals(end))
                            {
                                return currentRatio * next[key];
                            }
                            queueRatio.Enqueue(currentRatio * next[key]);
                        }
                    }
                }
            }
            return -1;
        }

        //Build the graph relationship between different conversion
        public static Dictionary<string, Dictionary<string, double>> MapData(List<Node> data)
        {
            Dictionary<string, Dictionary<string, double>> map = new();

            foreach (var item in data)
            {
                if (!map.ContainsKey(item.start))
                {
                    map.Add(item.start, new Dictionary<string, double>());
                }
                map[item.start].Add(item.end, item.ratio);

                if (!map.ContainsKey(item.end))
                {
                    map.Add(item.end, new Dictionary<string, double>());
                }
                map[item.end].Add(item.start, 1.0 / item.ratio);
            }

            return map;
        }

        public class Node
        {
            public string start;
            public string end;
            public double ratio;

            public Node(string s, string e, double r)
            {
                start = s;
                end = e;
                ratio = r;
            }
        }
    }
}
