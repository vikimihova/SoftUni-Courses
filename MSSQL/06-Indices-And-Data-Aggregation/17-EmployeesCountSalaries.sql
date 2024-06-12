--17.Employees count salaries

SELECT COUNT(Salary) AS [Count]
FROM Employees
WHERE ManagerID IS NULL