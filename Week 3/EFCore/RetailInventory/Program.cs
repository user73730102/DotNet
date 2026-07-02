using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using System.Collections.Generic;

namespace RetailInventory
{
    class Program
    {
        // Lab 13: Compiled Query for Performance
        static readonly Func<AppDbContext, decimal, IAsyncEnumerable<Product>> _expensiveProducts =
            EF.CompileAsyncQuery((AppDbContext ctx, decimal price) =>
                ctx.Products.Where(p => p.Price > price));

        static async Task Main(string[] args)
        {
            Console.WriteLine("Retail Inventory System - Part 2 (Advanced EF Core)\n");

            using var context = new AppDbContext();

            // ==========================================
            // Lab 10: Eager and Explicit Loading
            // ==========================================
            Console.WriteLine("--- Lab 10: Loading Strategies ---");
            
            // Eager Loading
            var eagerProducts = await context.Products
                .Include(p => p.Category)
                .ToListAsync();
            Console.WriteLine($"Eager Loading: Found {eagerProducts.Count} products. First is in Category: {eagerProducts.FirstOrDefault()?.Category?.Name}");

            // Explicit Loading
            var explicitProduct = await context.Products.FirstOrDefaultAsync(p => p.Id == 1);
            if (explicitProduct != null)
            {
                await context.Entry(explicitProduct).Reference(p => p.Category).LoadAsync();
                Console.WriteLine($"Explicit Loading: Loaded Category '{explicitProduct.Category.Name}' for Product '{explicitProduct.Name}'\n");
            }


            // ==========================================
            // Lab 13: Caching and Tracking Behavior
            // ==========================================
            Console.WriteLine("--- Lab 13: AsNoTracking and Compiled Queries ---");
            
            // AsNoTracking (Faster for read-only)
            var noTrackingProducts = await context.Products
                .AsNoTracking()
                .ToListAsync();
            Console.WriteLine($"AsNoTracking: Fetched {noTrackingProducts.Count} products.");

            // Compiled Query
            var compiledResult = await _expensiveProducts(context, 1000).ToListAsync();
            Console.WriteLine($"Compiled Query: Found {compiledResult.Count} expensive products.\n");


            // ==========================================
            // Lab 14: Batch Processing (Bulk Update)
            // ==========================================
            Console.WriteLine("--- Lab 14: Bulk Operations ---");
            
            var allProducts = await context.Products.ToListAsync();
            foreach (var p in allProducts)
            {
                p.StockQuantity += 10; // Give everything 10 more stock
            }
            
            // Bulk Update using EFCore.BulkExtensions
            await context.BulkUpdateAsync(allProducts);
            Console.WriteLine($"Bulk Updated stock for {allProducts.Count} products.\n");


            // ==========================================
            // Lab 15: Handling Concurrency
            // ==========================================
            Console.WriteLine("--- Lab 15: Concurrency Control ---");
            
            var productToUpdate = await context.Products.FirstAsync();
            
            // Simulate another user updating the same product in a different context
            using (var user2Context = new AppDbContext())
            {
                var p2 = await user2Context.Products.FirstAsync();
                p2.Price += 100;
                await user2Context.SaveChangesAsync(); // User 2 saves first!
            }

            try
            {
                // Now User 1 tries to save
                productToUpdate.Price -= 50;
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine("Concurrency conflict detected! Someone else updated the product before you.");
            }

            Console.WriteLine("\nAdvanced EF Core operations completed successfully!");
        }
    }
}
