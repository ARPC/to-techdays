using System;

namespace FindTownJudge
{
    public class Program
    {
        public int FindTownJudge(int n, int[,] trust)
        {
            int[] outdegree = new int[n];   //  trusts that many people
            int[] indegree = new int[n];    //  trusted by that many people
            int numberOfTrusts = trust.GetLength(0);

            for (int i = 0; i < numberOfTrusts; i++)
            {
                outdegree[trust[i, 0] - 1] ++;
                indegree[trust[i, 1] - 1] ++;
            }
            
            for (int i = 0; i < n; i++)
            {
                if (outdegree[i] == 0 && indegree[i] == n - 1)
                    return i + 1;
            }
            
            return -1;
        }
    }
}
