--19. People table with detailed age

CREATE TABLE [People]
(
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	[Birthday] DATETIME2 NOT NULL
)

INSERT INTO [People] ([Name], [Birthday])
VALUES ('Viktoria', '1989-07-18')

SELECT [Name],
	   DATEDIFF(YEAR, [Birthday], GETDATE())
	AS [Age in Years],
	   DATEDIFF(MONTH, [Birthday], GETDATE())
	AS [Age in Months],
	   DATEDIFF(DAY, [Birthday], GETDATE())
	AS [Age in Days],
	   DATEDIFF(MINUTE, [Birthday], GETDATE())
	AS [Age in Minutes]
  FROM [People]