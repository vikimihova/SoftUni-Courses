--11.Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT DF_CurrentDate DEFAULT GETDATE() FOR LastLoginTime

UPDATE Users
SET LastLoginTime = GETDATE()