USE DigitalNurtureDB;
GO

PRINT '========================================='
PRINT '        PART 1: FUNCTIONS                '
PRINT '========================================='

PRINT '--- EXERCISE 1: Create a Scalar Function ---';
GO
CREATE OR ALTER FUNCTION fn_CalculateAnnualSalary (@Salary DECIMAL(10,2))
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 12;
END;
GO

PRINT '--- EXERCISE 2: Create a Table-Valued Function ---';
GO
CREATE OR ALTER FUNCTION fn_GetEmployeesByDepartment (@DepartmentID INT)
RETURNS TABLE
AS
RETURN (
    SELECT EmployeeID, FirstName, LastName, Salary 
    FROM Employees 
    WHERE DepartmentID = @DepartmentID
);
GO

PRINT '--- EXERCISE 3 & 4: Create and Modify a User-Defined Function ---';
GO
CREATE OR ALTER FUNCTION fn_CalculateBonus (@Salary DECIMAL(10,2))
RETURNS DECIMAL(10,2)
AS
BEGIN
    -- Modified to 15% as per Exercise 4
    RETURN @Salary * 0.15;
END;
GO

PRINT '--- EXERCISE 6 & 7: Execute a Scalar Function ---';
-- For all employees
SELECT FirstName, Salary, dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary FROM Employees;
-- For EmployeeID = 1
SELECT dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary FROM Employees WHERE EmployeeID = 1;
GO

PRINT '--- EXERCISE 8: Return Data from a Table-Valued Function ---';
SELECT * FROM dbo.fn_GetEmployeesByDepartment(3);
GO

PRINT '--- EXERCISE 9 & 10: Create and Modify a Nested User-Defined Function ---';
GO
CREATE OR ALTER FUNCTION fn_CalculateTotalCompensation (@Salary DECIMAL(10,2))
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN dbo.fn_CalculateAnnualSalary(@Salary) + dbo.fn_CalculateBonus(@Salary);
END;
GO
SELECT FirstName, dbo.fn_CalculateTotalCompensation(Salary) AS TotalCompensation FROM Employees;
GO

PRINT '--- EXERCISE 5: Delete a User-Defined Function ---';
DROP FUNCTION fn_CalculateBonus;
GO

PRINT '========================================='
PRINT '        PART 2: TRIGGERS                 '
PRINT '========================================='

PRINT '--- EXERCISE 1: Create an After Trigger ---';
-- Create Audit Table first
IF OBJECT_ID('EmployeeChanges', 'U') IS NOT NULL DROP TABLE EmployeeChanges;
CREATE TABLE EmployeeChanges (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT,
    OldSalary DECIMAL(10,2),
    NewSalary DECIMAL(10,2),
    ChangeDate DATETIME DEFAULT GETDATE()
);
GO

CREATE OR ALTER TRIGGER trg_AfterSalaryUpdate
ON Employees
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Salary)
    BEGIN
        INSERT INTO EmployeeChanges (EmployeeID, OldSalary, NewSalary)
        SELECT i.EmployeeID, d.Salary, i.Salary
        FROM inserted i
        JOIN deleted d ON i.EmployeeID = d.EmployeeID
        WHERE i.Salary <> d.Salary;
    END
END;
GO
-- Test the Trigger
UPDATE Employees SET Salary = 5500.00 WHERE EmployeeID = 1;
SELECT * FROM EmployeeChanges;
GO

PRINT '--- EXERCISE 2: Create an Instead of Trigger ---';
GO
CREATE OR ALTER TRIGGER trg_PreventEmployeeDeletion
ON Employees
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR ('Deletions from the Employees table are not allowed.', 16, 1);
    -- Rollback not strictly needed since it's INSTEAD OF, meaning the delete never happens.
END;
GO
-- Test it (Should raise error and not delete)
BEGIN TRY
    DELETE FROM Employees WHERE EmployeeID = 2;
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
END CATCH;
GO

PRINT '--- EXERCISE 3: Create a Logon Trigger ---';
-- Skipped actual execution to avoid locking out the LocalDB instance, but here is the script:
/*
CREATE TRIGGER trg_RestrictMaintenanceLogin
ON ALL SERVER
FOR LOGON
AS
BEGIN
    DECLARE @CurrentHour INT = DATEPART(HOUR, GETDATE());
    IF @CurrentHour BETWEEN 2 AND 3
    BEGIN
        ROLLBACK; -- Denies the login
    END
END;
*/
PRINT 'Logon Trigger script provided as a comment to prevent lockout.';
GO

PRINT '--- EXERCISE 4 & 5: Modify and Delete a Trigger ---';
-- Modifying is just using ALTER TRIGGER.
-- Let's delete the INSTEAD OF DELETE trigger.
DROP TRIGGER trg_PreventEmployeeDeletion ON Employees;
GO

PRINT '--- EXERCISE 6: Create a Trigger to Update a Computed Column ---';
-- Add the AnnualSalary column
IF COL_LENGTH('Employees', 'AnnualSalary') IS NULL
BEGIN
    ALTER TABLE Employees ADD AnnualSalary DECIMAL(10,2);
END
GO
-- Update existing rows
UPDATE Employees SET AnnualSalary = Salary * 12;
GO

CREATE OR ALTER TRIGGER trg_UpdateAnnualSalary
ON Employees
AFTER UPDATE
AS
BEGIN
    -- Prevent recursive triggers if needed, but since we update AnnualSalary it's fine
    IF UPDATE(Salary)
    BEGIN
        -- Disable the trigger temporarily to prevent recursion or just update directly
        -- SQL Server handles this gracefully unless recursive triggers are enabled at DB level
        UPDATE e
        SET e.AnnualSalary = i.Salary * 12
        FROM Employees e
        JOIN inserted i ON e.EmployeeID = i.EmployeeID;
    END
END;
GO
-- Test it
UPDATE Employees SET Salary = 8000.00 WHERE EmployeeID = 2;
SELECT FirstName, Salary, AnnualSalary FROM Employees WHERE EmployeeID = 2;
GO
