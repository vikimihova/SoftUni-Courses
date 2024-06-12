--19.Salary challenge

SELECT TOP(10) e.FirstName
             , e.LastName
             , e.DepartmentID
  FROM Employees AS [e]
 WHERE e.Salary > 
       (
            SELECT AVG(emp.Salary) AS [AverageSalary]
              FROM Employees AS [emp]
             GROUP BY emp.DepartmentID
            HAVING emp.DepartmentID = e.DepartmentID
       )
 ORDER BY e.DepartmentID

--Alternative solution

SELECT TOP(10) e.FirstName
             , e.LastName
             , e.DepartmentID
  FROM Employees AS [e]
  JOIN (
            SELECT DepartmentID
                 , AVG(Salary) AS [AverageSalary]
              FROM Employees
             GROUP BY DepartmentID
       ) 
    AS [AverageSalaryPerDepartment]
    ON e.DepartmentID = AverageSalaryPerDepartment.DepartmentID
 WHERE e.Salary > AverageSalaryPerDepartment.AverageSalary
 ORDER BY e.DepartmentID



