using System;

namespace DecodeWays
{
    public class Program
    {
        public int NumDecodings(string s)
        {
            int[] dp = new int[s.Length];

            for (int i=s.Length-1; i>= 0; i--)
            {
                int num = 0;
                int digit = s[i] - '0';  
                              
                if (digit > 0)
                {
                    //  evaluate as a single-digit number
                    if (i == s.Length - 1) 
                        num += 1;    //  end of the string
                    else
                        num += dp[i + 1];
                    
                    //  evaluate as a two-digit number
                    if (i <= s.Length - 2)
                    {
                        int nextDigit = s[i + 1] - '0';
                        int twoDigitNum = digit * 10 + nextDigit;
                        
                        if (twoDigitNum <= 26)
                        {
                            if (i == s.Length - 2)
                                num += 1; // end of the string
                            else
                                num += dp[i + 2];
                        }
                    }                    
                }

                dp[i] = num;
            }

            return dp[0];
        }    
    }
}
