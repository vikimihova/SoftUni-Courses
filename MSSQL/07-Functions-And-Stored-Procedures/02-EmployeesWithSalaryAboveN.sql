--02.Employees with salaries above number

CREATE PROC usp_GetEmployeesSalaryAboveNumber @Amount DECIMAL(18,4)
         AS
      BEGIN
            SELECT [FirstName] AS [First Name]
                 , [LastName] AS [Last Name]
              FROM [Employees]
             WHERE [Salary] >= @Amount
        END

GO

EXEC usp_GetEmployeesSalaryAboveNumber 50000