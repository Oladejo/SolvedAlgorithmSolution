using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountsMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    //Approach 1: Depth First Search (DFS)
    public class Solution
    {
        HashSet<string> visited = new HashSet<string>();
        Dictionary<string, List<string>> adjacent = new Dictionary<string, List<string>>();

        private void DFS(List<string> mergedAccount, string email)
        {
            visited.Add(email);

            // Add the email that contains the current component's emails
            mergedAccount.Add(email);

            if (adjacent.ContainsKey(email))
            {
                foreach(string neighbor in adjacent.GetValueOrDefault(email))
                {
                    if (!visited.Contains(neighbor))
                    {
                        DFS(mergedAccount, neighbor);
                    }
                }
            }
        }



        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {

            int accountListSize = accounts.Count;

            foreach(IList<string> account in accounts)
            {
                int accountSize = account.Count;

                // Building adjacency list
                // Adding edge between first email to all other emails in the account

                string accountFirstEmail = account[1];

                for(int i = 2; i < accountSize; i++)
                {
                    string accountEmail = account[i];

                    if (!adjacent.ContainsKey(accountFirstEmail))
                    {
                        adjacent.Add(accountFirstEmail, new List<string>());
                    }

                    adjacent.GetValueOrDefault(accountFirstEmail).Add(accountEmail);

                    if (!adjacent.ContainsKey(accountEmail))
                    {
                        adjacent.Add(accountEmail, new List<string>());
                    }

                    adjacent.GetValueOrDefault(accountEmail).Add(accountFirstEmail);
                }

            }


            // Traverse over all the accounts to store components
            List<IList<string>> mergeAccounts = new List<IList<string>>();

            foreach(IList<string> account in accounts)
            {
                string accountName = account[0];
                string accountFirstEmail = account[1];

                // If email is visited, then it's a part of different component
                // Hence perform DFS only if email is not visited yet

                if (!visited.Contains(accountFirstEmail))
                {
                    // Adding account name at the 0th index
                    List<string> mergeAccount = new List<string>
                    {
                        accountName
                    };

                    DFS(mergeAccount, accountFirstEmail);
                    mergeAccount.Sort(StringComparer.Ordinal);
                    mergeAccount.Sort(1, mergeAccount.Count - 1, StringComparer.Ordinal);
                    mergeAccounts.Add(mergeAccount);
                }
            }

            return mergeAccounts;
        }
    }
}
