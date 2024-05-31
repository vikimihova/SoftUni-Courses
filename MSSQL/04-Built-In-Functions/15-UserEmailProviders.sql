--15.User email providers

   SELECT [Username],
	      SUBSTRING([Email], CHARINDEX('@', [Email], 1) + 1, LEN([Email]) - CHARINDEX('@', [Email], 1) + 1)
       AS [Email Provider]
     FROM [Users]
    WHERE [Email] IS NOT NULL
 ORDER BY [Email Provider], [Username]