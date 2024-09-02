--15.Employees average salaries

     SELECT *
       INTO [FilteredEmployees]
       FROM [Employees]
      WHERE [Salary] > 30000

DELETE FROM [FilteredEmployees]
      WHERE [ManagerID] = 42

     UPDATE [FilteredEmployees]
        SET [Salary] = [Salary] + 5000
      WHERE [DepartmentID] = 1

     SELECT [DepartmentID]
          , AVG([Salary]) AS [AverageSalary]
       FROM [FilteredEmployees]
      GROUP BY [DepartmentID]
