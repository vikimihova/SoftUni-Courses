--08.Create view of employees hired after 2000

CREATE VIEW V_EmployeesHiredAfter2000 AS
	 SELECT [FirstName]
          , [LastName]
	   FROM [Employees]
	  WHERE YEAR([HireDate]) > 2000