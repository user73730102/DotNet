USE DigitalNurtureDB;
GO

PRINT '--- EXERCISE 1: Ranking and Window Functions ---';
-- Goal: Find the top 3 most expensive products in each category using different ranking functions.
SELECT 
    ProductName, 
    Category, 
    Price,
    ROW_NUMBER() OVER(PARTITION BY Category ORDER BY Price DESC) AS RowNum,
    RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS RankNum,
    DENSE_RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
FROM Products;
GO

PRINT '--- EXERCISE 2: Aggregation with GROUPING SETS, CUBE, and ROLLUP ---';
-- Goal: Generate a report showing total quantity sold by Region and Category.
-- Note: Using GROUPING SETS, ROLLUP, CUBE requires JOINs
SELECT 
    c.Region, 
    p.Category, 
    SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY GROUPING SETS (
    (c.Region, p.Category),
    (c.Region),
    (p.Category),
    ()
);

-- Using ROLLUP
SELECT 
    c.Region, 
    p.Category, 
    SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY ROLLUP (c.Region, p.Category);

-- Using CUBE
SELECT 
    c.Region, 
    p.Category, 
    SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY CUBE (c.Region, p.Category);
GO

PRINT '--- EXERCISE 3: CTEs and MERGE ---';
-- a) Recursive CTE to generate a calendar table for Jan 2025
WITH CalendarCTE AS (
    SELECT CAST('2025-01-01' AS DATE) AS CalendarDate
    UNION ALL
    SELECT DATEADD(day, 1, CalendarDate)
    FROM CalendarCTE
    WHERE CalendarDate < '2025-01-31'
)
SELECT * FROM CalendarCTE;

-- b) MERGE statement
-- Create a Staging Table
IF OBJECT_ID('StagingProducts', 'U') IS NOT NULL DROP TABLE StagingProducts;
CREATE TABLE StagingProducts (
    ProductID INT,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

-- Insert existing product with updated price, and a new product
INSERT INTO StagingProducts VALUES 
(1, 'Laptop', 'Electronics', 1100.00), -- Price changed from 1200 to 1100
(11, 'Bookshelf', 'Furniture', 120.00); -- New Product

-- MERGE
MERGE Products AS Target
USING StagingProducts AS Source
ON (Target.ProductID = Source.ProductID)
WHEN MATCHED THEN
    UPDATE SET Target.Price = Source.Price
WHEN NOT MATCHED BY TARGET THEN
    INSERT (ProductName, Category, Price)
    VALUES (Source.ProductName, Source.Category, Source.Price);

-- Check results
SELECT * FROM Products WHERE ProductID IN (1, 11);
GO

PRINT '--- EXERCISE 4: PIVOT and UNPIVOT ---';
-- Show monthly sales quantity per product in a pivoted format
-- Since all orders are in Jan, let's insert a Feb order for PIVOT demonstration
INSERT INTO Orders (CustomerID, OrderDate) VALUES (1, '2025-02-05');
INSERT INTO OrderDetails (OrderID, ProductID, Quantity) VALUES (SCOPE_IDENTITY(), 1, 5);

WITH MonthlySales AS (
    SELECT 
        p.ProductName,
        DATENAME(month, o.OrderDate) AS MonthName,
        od.Quantity
    FROM Orders o
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    JOIN Products p ON od.ProductID = p.ProductID
)
SELECT * FROM MonthlySales
PIVOT (
    SUM(Quantity)
    FOR MonthName IN ([January], [February])
) AS PivotTable;

-- UNPIVOT (Skipping creating physical table for simplicity, demonstrating concept with subquery)
-- In a real scenario, you would select the PIVOT into a Temp Table and then UNPIVOT it.
GO

PRINT '--- EXERCISE 5: Using CTE to Simplify a Query ---';
-- Goal: Find all customers who have placed more than 3 orders in total.
WITH CustomerOrderCounts AS (
    SELECT 
        o.CustomerID,
        COUNT(o.OrderID) AS OrderCount
    FROM Orders o
    GROUP BY o.CustomerID
)
SELECT 
    c.CustomerID,
    c.Name,
    coc.OrderCount
FROM CustomerOrderCounts coc
JOIN Customers c ON c.CustomerID = coc.CustomerID
WHERE coc.OrderCount > 3;
GO
