--03.Alter Minions Table
ALTER TABLE [Minions]
ADD [TownId] INT

ALTER TABLE [Minions]
ADD FOREIGN KEY ([TownId]) REFERENCES [Towns]([Id])

SELECT * FROM [Minions]
SELECT * FROM [Towns]