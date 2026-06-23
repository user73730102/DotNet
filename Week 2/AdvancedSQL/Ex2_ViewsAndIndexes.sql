USE DigitalNurtureDB;
GO

PRINT '--- EXERCISE 2: Indexes ---';

-- Exercise 1: Creating a Non-Clustered Index
PRINT 'Step 1: Create a non-clustered index on ProductName';
IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_Products_ProductName')
    CREATE NONCLUSTERED INDEX IX_Products_ProductName ON Products(ProductName);

SELECT * FROM Products WHERE ProductName = 'Laptop';
GO

-- Exercise 2: Creating a Clustered Index
PRINT 'Creating Non-Clustered Index on OrderDate instead of Clustered (since PK is clustered)';
IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_Orders_OrderDate')
    CREATE NONCLUSTERED INDEX IX_Orders_OrderDate ON Orders(OrderDate);

SELECT * FROM Orders WHERE OrderDate = '2025-01-15';
GO

-- Exercise 3: Creating a Composite Index
PRINT 'Step 3: Create a composite index on CustomerID and OrderDate';
IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_Orders_CustomerID_OrderDate')
    CREATE NONCLUSTERED INDEX IX_Orders_CustomerID_OrderDate ON Orders(CustomerID, OrderDate);

SELECT * FROM Orders WHERE CustomerID = 1 AND OrderDate = '2025-01-15';
GO

-- Also View Exercise
PRINT '--- EXERCISE: Creating Views ---';
GO

CREATE OR ALTER VIEW vw_CustomerOrders AS
SELECT 
    c.Name,
    o.OrderDate,
    p.ProductName,
    od.Quantity,
    (p.Price * od.Quantity) AS TotalAmount
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID;
GO

SELECT * FROM vw_CustomerOrders;
GO
