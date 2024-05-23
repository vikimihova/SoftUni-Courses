--05.Find email of each employee


SELECT [FirstName] + '.' + [LastName] + '@softuni.bg'
    AS [Full Email Address]
  FROM [Employees]