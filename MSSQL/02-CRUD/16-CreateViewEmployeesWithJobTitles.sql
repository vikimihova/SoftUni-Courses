--16.Create view employees with job titles

CREATE OR ALTER VIEW V_EmployeeNameJobTitle 
				  AS
			  SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName])
				  AS [Full Name],
					 [JobTitle]
				FROM [Employees]
				

GO

CREATE OR ALTER VIEW V_EmployeeNameJobTitle2
				  AS
			  SELECT CONCAT([FirstName], ' ', ISNULL([MiddleName], ' '), [LastName])
				  AS [Full Name],
					 [JobTitle]
				FROM [Employees]
				

GO

CREATE VIEW V_EmployeeNameJobTitle3
				  AS
			  SELECT CONCAT([FirstName], ' ', [MiddleName] + ' ', [LastName])
				  AS [Full Name],
					 [JobTitle]
				FROM [Employees]
				

GO

SELECT * FROM V_EmployeeNameJobTitle