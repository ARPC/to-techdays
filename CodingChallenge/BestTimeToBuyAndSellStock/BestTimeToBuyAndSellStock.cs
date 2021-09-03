using System;

namespace BestTimeToBuyAndSellStock
{
    public class Program
    {
        public int MaxProfit(int[] prices)
        {
            //return 0;

            int profit = 0;
        
            for (int i = 1; i < prices.Length; i++)
            {
                int diff = prices[i] - prices[i - 1];
                if (diff > 0)
                    profit += diff;
            }
            
            return profit;
        }
    }
}
