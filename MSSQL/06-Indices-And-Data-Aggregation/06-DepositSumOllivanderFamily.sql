--06.Deposit sum for Ollivander family

  SELECT [DepositGroup]
       , SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]
       , [MagicWandCreator]
  HAVING [MagicWandCreator] = 'Ollivander family'