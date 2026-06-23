USE DigitalNurtureDB;
GO

PRINT '========================================='
PRINT '        PART 1: CURSORS                  '
PRINT '========================================='

PRINT '--- EXERCISE 1: Create a Cursor ---';
GO
DECLARE @EmpID INT, @FName VARCHAR(50), @LName VARCHAR(50), @Sal DECIMAL(10,2);
DECLARE emp_cursor CURSOR FOR
SELECT EmployeeID, FirstName, LastName, Salary FROM Employees;

OPEN emp_cursor;
FETCH NEXT FROM emp_cursor INTO @EmpID, @FName, @LName, @Sal;

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Employee: ' + @FName + ' ' + @LName + ' - Salary: ' + CAST(@Sal AS VARCHAR);
    FETCH NEXT FROM emp_cursor INTO @EmpID, @FName, @LName, @Sal;
END

CLOSE emp_cursor;
DEALLOCATE emp_cursor;
GO

PRINT '--- EXERCISE 2: Types of Cursors ---';
-- Static Cursor
DECLARE static_cursor CURSOR STATIC FOR SELECT EmployeeID FROM Employees;
-- Dynamic Cursor
DECLARE dynamic_cursor CURSOR DYNAMIC FOR SELECT EmployeeID FROM Employees;
-- Forward-Only Cursor
DECLARE forward_cursor CURSOR FORWARD_ONLY FOR SELECT EmployeeID FROM Employees;
-- Keyset-Driven Cursor
DECLARE keyset_cursor CURSOR KEYSET FOR SELECT EmployeeID FROM Employees;

-- Clean up
DEALLOCATE static_cursor;
DEALLOCATE dynamic_cursor;
DEALLOCATE forward_cursor;
DEALLOCATE keyset_cursor;
PRINT 'Cursor types declared successfully.';
GO


PRINT '========================================='
PRINT '        PART 2: EXCEPTION HANDLING       '
PRINT '========================================='

-- Setup schema for Exceptions
IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = N'Email' AND Object_ID = Object_ID(N'Employees'))
BEGIN
    ALTER TABLE Employees ADD Email VARCHAR(100) UNIQUE;
END
GO
IF OBJECT_ID('AuditLog', 'U') IS NOT NULL DROP TABLE AuditLog;
CREATE TABLE AuditLog (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    Action VARCHAR(100),
    ErrorMessage VARCHAR(4000),
    ActionDate DATETIME DEFAULT GETDATE()
);
GO
-- Update existing employees with emails to prevent NULL constraint issues if we make it unique
UPDATE Employees SET Email = 'employee' + CAST(EmployeeID AS VARCHAR) + '@company.com' WHERE Email IS NULL;
GO

PRINT '--- EXERCISE 1 & 2 & 3 & 6: Basic TRY...CATCH, THROW, RAISERROR ---';
GO
CREATE OR ALTER PROCEDURE AddEmployee_ExceptionHandling
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @DepartmentID INT,
    @Salary DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY
        -- Ex 3 & 6: Custom Error with RAISERROR
        IF @Salary < 0
        BEGIN
            RAISERROR ('Salary cannot be negative.', 16, 1);
            RETURN;
        END
        IF @Salary < 1000
        BEGIN
            RAISERROR ('Warning: Salary is below minimum wage.', 10, 1);
        END

        DECLARE @NewID INT = ISNULL((SELECT MAX(EmployeeID) FROM Employees), 0) + 1;
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, DepartmentID, Salary, JoinDate)
        VALUES (@NewID, @FirstName, @LastName, @Email, @DepartmentID, @Salary, GETDATE());
        
        PRINT 'Employee Added Successfully';
    END TRY
    BEGIN CATCH
        -- Ex 1: Log to AuditLog
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('AddEmployee', ERROR_MESSAGE());

        PRINT 'Error occurred and logged to AuditLog.';

        -- Ex 2: Re-raise the error
        THROW;
    END CATCH
END;
GO
-- Test Ex 1: Duplicate Email
BEGIN TRY
    EXEC AddEmployee_ExceptionHandling 'Test', 'User', 'employee1@company.com', 1, 5000.00;
END TRY
BEGIN CATCH
    PRINT 'Caught Duplicate Email Error.';
END CATCH
GO

PRINT '--- EXERCISE 4: Nested TRY...CATCH with RAISERROR ---';
GO
CREATE OR ALTER PROCEDURE TransferEmployee
    @EmployeeID INT,
    @NewDepartmentID INT
AS
BEGIN
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM Departments WHERE DepartmentID = @NewDepartmentID)
        BEGIN
            RAISERROR ('Target department does not exist.', 16, 1);
        END

        BEGIN TRY
            UPDATE Employees SET DepartmentID = @NewDepartmentID WHERE EmployeeID = @EmployeeID;
        END TRY
        BEGIN CATCH
            INSERT INTO AuditLog (Action, ErrorMessage) VALUES ('TransferEmployee - Update', ERROR_MESSAGE());
            THROW;
        END CATCH

    END TRY
    BEGIN CATCH
        INSERT INTO AuditLog (Action, ErrorMessage) VALUES ('TransferEmployee - Validation', ERROR_MESSAGE());
        PRINT 'Transfer Failed: ' + ERROR_MESSAGE();
    END CATCH
END;
GO
-- Test Ex 4: Non-existent department
EXEC TransferEmployee 1, 999;
GO

PRINT '--- EXERCISE 5: Logging All Errors in a Transaction ---';
GO
CREATE OR ALTER PROCEDURE BatchInsertEmployees
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        DECLARE @NewID1 INT = ISNULL((SELECT MAX(EmployeeID) FROM Employees), 0) + 1;
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, DepartmentID, Salary, JoinDate)
        VALUES (@NewID1, 'Batch1', 'User', 'batch1@company.com', 1, 4000.00, GETDATE());

        DECLARE @NewID2 INT = @NewID1 + 1;
        -- Intentional error: Duplicate email
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, DepartmentID, Salary, JoinDate)
        VALUES (@NewID2, 'Batch2', 'User', 'batch1@company.com', 1, 4000.00, GETDATE());

        COMMIT TRANSACTION;
        PRINT 'Batch Insert Successful';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        INSERT INTO AuditLog (Action, ErrorMessage) VALUES ('BatchInsert', ERROR_MESSAGE());
        PRINT 'Batch Insert Failed and Rolled Back.';
    END CATCH
END;
GO
EXEC BatchInsertEmployees;
SELECT * FROM AuditLog;
GO
