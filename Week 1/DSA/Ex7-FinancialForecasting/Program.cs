using System;

namespace Ex7_FinancialForecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Financial Forecasting (Recursion)...\n");

            decimal initialInvestment = 1000m;
            decimal annualGrowthRate = 0.05m; // 5%
            int years = 10;

            Console.WriteLine($"Initial Investment: ${initialInvestment}");
            Console.WriteLine($"Annual Growth Rate: {annualGrowthRate * 100}%");
            Console.WriteLine($"Periods (Years): {years}");

            Console.WriteLine("\n--- Calculating via Simple Recursion ---");
            decimal futureValue = ForecastingTool.CalculateFutureValue(initialInvestment, annualGrowthRate, years);
            Console.WriteLine($"Future Value after {years} years: ${Math.Round(futureValue, 2)}");

            Console.WriteLine("\n--- Calculating via Memoized Recursion ---");
            decimal memoizedValue = ForecastingTool.CalculateFutureValueMemoized(initialInvestment, annualGrowthRate, years);
            Console.WriteLine($"Future Value after {years} years: ${Math.Round(memoizedValue, 2)}");

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
