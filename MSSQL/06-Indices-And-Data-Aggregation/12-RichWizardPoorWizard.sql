--12.Rich wizard, poor wizard
--self-relation: w - wizard (current row), gw - guest wizard (next row)

SELECT SUM(w.DepositAmount - gw.DepositAmount) AS [SumDifference]
  FROM WizzardDeposits AS [w]
  JOIN WizzardDeposits AS [gw]
    ON w.Id + 1 = gw.Id


