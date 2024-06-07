--04.Smallest deposit group per magic wand size

SELECT TOP(2) DepositGroup
  FROM WizzardDeposits
 GROUP BY DepositGroup
 ORDER BY AVG(MagicWandSize)


