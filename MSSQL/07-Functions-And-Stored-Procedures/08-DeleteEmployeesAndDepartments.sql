--08.Delete employees and departments

CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
BEGIN
--
    DECLARE @EmployeesToDelete TABLE (Id INT)
     INSERT INTO @EmployeesToDelete
     SELECT [EmployeeId]
       FROM [Employees]
      WHERE [DepartmentID] = @departmentId
    --
    DELETE FROM [EmployeesProjects]
     WHERE [EmployeeID] IN (SELECT * FROM @EmployeesToDelete)

    --
     ALTER TABLE [Departments]
    ALTER COLUMN [ManagerID] INT NULL

    UPDATE [Departments]
       SET [ManagerID] = NULL
     WHERE [ManagerID] IN (SELECT * FROM @EmployeesToDelete)
    --

    UPDATE [Employees]
       SET [ManagerID] = NULL
     WHERE [ManagerID] IN (SELECT * FROM @EmployeesToDelete)
    --

    DELETE FROM [Employees]
     WHERE [DepartmentID] = @departmentId

    DELETE FROM [Departments]
     WHERE [DepartmentID] = @departmentId

    SELECT COUNT(*)
      FROM [Employees]
     WHERE [DepartmentID] = @departmentId

END

GO

EXEC dbo.usp_DeleteEmployeesFromDepartment 2