USE DigitalNurtureDB;
GO

-- Database Schema & Sample Data
IF OBJECT_ID('Employees', 'U') IS NOT NULL DROP TABLE Employees;
IF OBJECT_ID('Departments', 'U') IS NOT NULL DROP TABLE Departments;

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05');
GO

PRINT '--- EXERCISE 1: Create a Stored Procedure ---';
GO
CREATE OR ALTER PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    -- Added logic to generate a new EmployeeID
    DECLARE @NewID INT = ISNULL((SELECT MAX(EmployeeID) FROM Employees), 0) + 1;

    INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@NewID, @FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;
GO

PRINT '--- EXERCISE 2: Modify a Stored Procedure ---';
-- The exercise says "Modify the stored procedure to include employee salary in the result."
-- Wait, the previous one was INSERT. Let's create one that SELECTs.
GO
CREATE OR ALTER PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT FirstName, LastName, Salary FROM Employees WHERE DepartmentID = @DepartmentID;
END;
GO

PRINT '--- EXERCISE 3: Delete a Stored Procedure ---';
-- Write the SQL command to delete the stored procedure created in Exercise 1.
DROP PROCEDURE sp_InsertEmployee;
GO

PRINT '--- EXERCISE 4: Execute a Stored Procedure ---';
EXEC sp_GetEmployeesByDepartment @DepartmentID = 1;
GO

PRINT '--- EXERCISE 5: Return Data from a Stored Procedure ---';
GO
CREATE OR ALTER PROCEDURE sp_CountEmployeesInDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT COUNT(*) AS EmployeeCount FROM Employees WHERE DepartmentID = @DepartmentID;
END;
GO
EXEC sp_CountEmployeesInDepartment @DepartmentID = 3;
GO

PRINT '--- EXERCISE 6: Use Output Parameters in a Stored Procedure ---';
GO
CREATE OR ALTER PROCEDURE sp_GetTotalSalaryByDepartment
    @DepartmentID INT,
    @TotalSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SELECT @TotalSalary = SUM(Salary) FROM Employees WHERE DepartmentID = @DepartmentID;
END;
GO
DECLARE @OutputSalary DECIMAL(10,2);
EXEC sp_GetTotalSalaryByDepartment @DepartmentID = 4, @TotalSalary = @OutputSalary OUTPUT;
PRINT 'Total Salary for Dept 4: ' + CAST(@OutputSalary AS VARCHAR);
GO

PRINT '--- EXERCISE 7: Create a Stored Procedure with Multiple Parameters ---';
GO
CREATE OR ALTER PROCEDURE sp_UpdateEmployeeSalary
    @EmployeeID INT,
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    UPDATE Employees SET Salary = @NewSalary WHERE EmployeeID = @EmployeeID;
END;
GO
EXEC sp_UpdateEmployeeSalary 1, 5500.00;
GO

PRINT '--- EXERCISE 8: Create a Stored Procedure with Conditional Logic ---';
GO
CREATE OR ALTER PROCEDURE sp_GiveBonus
    @DepartmentID INT,
    @BonusAmount DECIMAL(10,2)
AS
BEGIN
    IF @DepartmentID = 3
    BEGIN
        UPDATE Employees SET Salary = Salary + @BonusAmount WHERE DepartmentID = @DepartmentID;
        PRINT 'Bonus given to IT Department';
    END
    ELSE
    BEGIN
        PRINT 'No bonus for this department';
    END
END;
GO
EXEC sp_GiveBonus 3, 500.00;
GO

PRINT '--- EXERCISE 9: Use Transactions in a Stored Procedure ---';
GO
CREATE OR ALTER PROCEDURE sp_UpdateSalaryWithTransaction
    @EmployeeID INT,
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE Employees SET Salary = @NewSalary WHERE EmployeeID = @EmployeeID;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Transaction Rolled Back due to an error.';
    END CATCH
END;
GO
EXEC sp_UpdateSalaryWithTransaction 2, 6500.00;
GO

PRINT '--- EXERCISE 10: Use Dynamic SQL in a Stored Procedure ---';
GO
CREATE OR ALTER PROCEDURE sp_GetEmployeesDynamic
    @FilterColumn VARCHAR(50),
    @FilterValue VARCHAR(100)
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);
    SET @SQL = 'SELECT * FROM Employees WHERE ' + QUOTENAME(@FilterColumn) + ' = @Value';
    
    -- Using sp_executesql is safer than concatenating values
    EXEC sp_executesql @SQL, N'@Value VARCHAR(100)', @FilterValue;
END;
GO
EXEC sp_GetEmployeesDynamic 'LastName', 'Smith';
GO

PRINT '--- EXERCISE 11: Handle Errors in a Stored Procedure ---';
GO
CREATE OR ALTER PROCEDURE sp_SafeUpdateSalary
    @EmployeeID INT,
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY
        -- Intentionally cause an error if Salary < 0
        IF @NewSalary < 0
            THROW 50001, 'Salary cannot be negative.', 1;

        UPDATE Employees SET Salary = @NewSalary WHERE EmployeeID = @EmployeeID;
    END TRY
    BEGIN CATCH
        SELECT 
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO
EXEC sp_SafeUpdateSalary 4, -1000.00; -- Will hit the CATCH block
GO
