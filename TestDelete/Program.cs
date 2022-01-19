using System;
using System.Collections.Generic;

namespace TestDelete
{
    public static class Globals
    {
        public static void Main()
        {
            int n;
            int sum = 0;
            n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));

            List<int> v = new List<int>(new int[n]);
            for (int i = 0; i < n; ++i)
            {
                v[i] = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                sum += v[i];
            }

            if (sum % 3 != 0)
            {
                Console.Write(0);
                return;
            }

            sum /= 3;

            List<List<int>> dp = VectorHelper.NestedList<int>(n + 1, sum + 1);

            for (int i = 1; i <= n; ++i)
            {
                for (int j = 1; j <= sum; ++j)
                {
                    dp[i][j] = dp[i - 1][j];
                    if (j >= v[i - 1])
                    {
                        dp[i][j] = Math.Max(dp[i][j], dp[i - 1][j - v[i - 1]] + v[i - 1]);
                    }
                }
            }

            if (dp[n][sum] != sum)
            {
                Console.Write(0);
            }

            int temp1 = n;
            int temp2 = sum;

            List<int> ans = new List<int>();

            while (true)
            {

                if (temp1 == temp2 && temp1 == 0)
                {
                    break;
                }

                if (dp[temp1 - 1][temp2] != dp[temp1][temp2])
                {
                    ans.Add(temp1);
                    temp2 -= v[temp1 - 1];
                }

                --temp1;
            }

            Console.Write(ans.Count);
            Console.Write("\n");
            for (int i = 0; i < ans.Count; ++i)
            {
                Console.Write(ans[i]);
                Console.Write(' ');
            }
        }
    }
}