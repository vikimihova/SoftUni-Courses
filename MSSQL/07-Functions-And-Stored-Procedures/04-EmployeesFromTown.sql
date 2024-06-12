--04.Employees from town

CREATE PROC usp_GetEmployeesFromTown @TownName NVARCHAR(20)
         AS
      BEGIN
            SELECT e.FirstName AS [First Name]
                 , e.LastName AS [Last Name]
              FROM Towns AS [t]
              JOIN Addresses AS [a]
                ON t.TownID = a.TownID
              JOIN Employees AS [e]
                ON a.AddressID = e.AddressID
             WHERE t.Name = @TownName
        END

GO

EXEC usp_GetEmployeesFromTown 'Sofia'