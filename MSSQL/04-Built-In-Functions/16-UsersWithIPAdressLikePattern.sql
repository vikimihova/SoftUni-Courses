--16.User with IP address like pattern

SELECT [Username]
     , [IpAddress] AS [IP Address]
  FROM [Users]
 WHERE [IpAddress] LIKE '___.1_%._%.___'
 ORDER BY [Username]