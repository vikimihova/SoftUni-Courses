--09.Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07982F0727

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY(Id, Username)