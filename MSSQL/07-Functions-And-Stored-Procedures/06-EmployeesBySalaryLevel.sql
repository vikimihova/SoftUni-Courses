--06.Employees by salary level

CREATE PROC usp_EmployeesBySalaryLevel (@LevelOfSalary NVARCHAR(10))
         AS
      BEGIN
                SELECT [FirstName] AS [First Name]
                     , [LastName] AS [Last Name]
                  FROM [Employees]
                 WHERE @LevelOfSalary = dbo.ufn_GetSalaryLevel([Salary])
        END

GO

EXEC usp_EmployeesBySalaryLevel 'High'