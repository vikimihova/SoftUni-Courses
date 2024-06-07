--03.Longest magic wand per deposit group

  SELECT DepositGroup
       , MAX(MagicWandSize) AS [LongestMagicWand]
    FROM WizzardDeposits
GROUP BY DepositGroup