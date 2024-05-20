--08.Create Table Users
CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME2,
	IsDeleted BIT
)

INSERT INTO Users (Username, [Password])
VALUES	('Shterion', '1989-07-18'),
		('Angelina', '1989-05-18'),
		('Lazar', '1989-07-10'),
		('Vladimir', '1989-03-18'),
		('Veronika', '1989-02-11')