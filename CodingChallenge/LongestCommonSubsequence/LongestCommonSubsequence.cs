using System;

namespace LongestCommonSubsequence
{
    public class Program
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
//            return 0;

            int[,] memo = new int[text1.Length+1, text2.Length+1];
            
            for(int i=text1.Length-1; i>=0; i--)
            {
                for(int j=text2.Length-1; j>=0; j--)
                {
                    if (text1[i] != text2[j])
                        memo[i, j] = Math.Max(memo[i+1, j], memo[i, j+1]);
                    else
                        memo[i, j] = 1 + memo[i+1, j+1];
                }
            }
            return memo[0,0];
        }    
    }
}
