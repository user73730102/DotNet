USE DigitalNurtureDB;
GO

-- Drop tables if they exist
IF OBJECT_ID('OrderDetails', 'U') IS NOT NULL DROP TABLE OrderDetails;
IF OBJECT_ID('Orders', 'U') IS NOT NULL DROP TABLE Orders;
IF OBJECT_ID('Products', 'U') IS NOT NULL DROP TABLE Products;
IF OBJECT_ID('Customers', 'U') IS NOT NULL DROP TABLE Customers;
GO

-- Create Tables
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Region NVARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    OrderDate DATE
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT
);
GO

-- Insert Sample Data
INSERT INTO Customers (Name, Region) VALUES
('John Doe', 'North'), ('Jane Smith', 'South'), ('Alice Johnson', 'North'), ('Bob Brown', 'East');

INSERT INTO Products (ProductName, Category, Price) VALUES
('Laptop', 'Electronics', 1200.00), ('Smartphone', 'Electronics', 800.00), ('Tablet', 'Electronics', 500.00),
('Headphones', 'Electronics', 150.00), ('Smartwatch', 'Electronics', 200.00),
('Desk', 'Furniture', 300.00), ('Chair', 'Furniture', 150.00), ('Sofa', 'Furniture', 700.00),
('Bed', 'Furniture', 1000.00), ('Lamp', 'Furniture', 50.00);

-- Insert multiple orders to ensure customers have more than 3 for CTE testing
INSERT INTO Orders (CustomerID, OrderDate) VALUES
(1, '2025-01-05'), (1, '2025-01-10'), (1, '2025-01-15'), (1, '2025-01-20'), -- John has 4 orders
(2, '2025-01-06'), (2, '2025-01-12'), -- Jane has 2 orders
(3, '2025-01-08'), (3, '2025-01-14'), (3, '2025-01-22'), (3, '2025-01-28'), -- Alice has 4 orders
(4, '2025-01-10'); -- Bob has 1 order

INSERT INTO OrderDetails (OrderID, ProductID, Quantity) VALUES
(1, 1, 1), (1, 4, 2),
(2, 2, 1), (2, 5, 1),
(3, 3, 2),
(4, 6, 1), (4, 7, 4),
(5, 8, 1),
(6, 9, 1), (6, 10, 2),
(7, 1, 1),
(8, 2, 2),
(9, 4, 3),
(10, 7, 2),
(11, 5, 1);
GO
