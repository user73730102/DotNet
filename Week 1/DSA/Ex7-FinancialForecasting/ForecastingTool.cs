using System;
using System.Collections.Generic;

namespace Ex7_FinancialForecasting
{
    public class ForecastingTool
    {
        // Simple Recursive Approach: O(2^N) or O(N) depending on implementation
        // For straightforward compound interest: FutureValue = PresentValue * (1 + rate)^periods
        // Recursively: CalculateFutureValue(PV, rate, periods) = CalculateFutureValue(PV * (1 + rate), rate, periods - 1)
        
        public static decimal CalculateFutureValue(decimal presentValue, decimal growthRate, int periods)
        {
            // Base Case: No more periods to grow
            if (periods <= 0)
            {
                return presentValue;
            }

            // Recursive Step
            decimal nextValue = presentValue * (1 + growthRate);
            return CalculateFutureValue(nextValue, growthRate, periods - 1);
        }

        // Optimization: Memoization (Storing calculated results to avoid redundant recursive calls)
        // This is particularly useful for Fibonacci-like recursion, but for simple compounding it prevents re-calculating the same (PV, period) state.
        private static Dictionary<int, decimal> memo = new Dictionary<int, decimal>();

        public static decimal CalculateFutureValueMemoized(decimal presentValue, decimal growthRate, int periods)
        {
            if (periods <= 0)
            {
                return presentValue;
            }

            if (memo.ContainsKey(periods))
            {
                return memo[periods];
            }

            decimal nextValue = presentValue * (1 + growthRate);
            decimal result = CalculateFutureValueMemoized(nextValue, growthRate, periods - 1);
            
            memo[periods] = result;
            return result;
        }
    }
}
