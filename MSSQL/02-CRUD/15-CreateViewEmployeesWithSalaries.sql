--15.Create view employees with salaries

GO

CREATE VIEW v_EmployeesSalaries 
		 AS 
	 SELECT [FirstName], [LastName], [Salary]
	   FROM [Employees]

GO

SELECT *
  FROM v_EmployeesSalaries 