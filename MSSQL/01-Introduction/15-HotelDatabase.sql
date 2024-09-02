--15.Hotel Database
CREATE DATABASE [Hotel]
USE [Hotel];

CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY(1,1)
  ,	[FirstName] NVARCHAR(50) NOT NULL
  ,	[LastName] NVARCHAR(50) NOT NULL
  ,	[Title] NVARCHAR(50) NOT NULL
  ,	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees] ([FirstName], [LastName], [Title])
VALUES ('Tom', 'Riddle', 'Dark Lord')
     , ('Albus', 'Dumbledore', 'Hogwarts Headmaster')
     , ('Minerva', 'McGonagoll', 'Hogwarts Deputy Headmistress')

CREATE TABLE [Customers]
(
	[AccountNumber] INT PRIMARY KEY
  ,	[FirstName] NVARCHAR(50) NOT NULL
  ,	[LastName] NVARCHAR(50) NOT NULL
  ,	[PhoneNumber] INT NOT NULL
  ,	[EmergencyName] NVARCHAR(50)
  ,	[EmergencyNumber] INT
  ,	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Customers] ([AccountNumber], [FirstName], [LastName], [PhoneNumber])
VALUES (777, 'Luna', 'Lovegood', 0899178782)
     , (333, 'Neville', 'Longbottom', 0899178782)
     , (111, 'Ginny', 'Weasley', 0899178782)

CREATE TABLE [RoomStatus]
(
	[RoomStatus] NVARCHAR(15) PRIMARY KEY
  ,	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [RoomTypes]
(
	[RoomType] NVARCHAR(15) PRIMARY KEY
  ,	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [BedTypes]
(
	[BedType] NVARCHAR(15) PRIMARY KEY
  ,	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Rooms]
(
	[RoomNumber] INT PRIMARY KEY
  ,	[RoomType] NVARCHAR(15) FOREIGN KEY REFERENCES [RoomTypes]([RoomType]) NOT NULL
  ,	[BedType] NVARCHAR(15) FOREIGN KEY REFERENCES [BedTypes]([BedType]) NOT NULL
  ,	[Rate] DECIMAL(4,2) NOT NULL
  ,	[RoomStatus] NVARCHAR(15) FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]) NOT NULL
  ,	[Notes] NVARCHAR(MAX)
)

INSERT INTO [RoomStatus] ([RoomStatus])
VALUES ('Available')
     , ('Occupied')
     , ('In Renovation')

INSERT INTO [RoomTypes] ([RoomType])
VALUES ('Economy')
     , ('Suite')
     , ('Business')

INSERT INTO [BedTypes] ([BedType])
VALUES ('Single')
     , ('Double')
     , ('Child')

INSERT INTO [Rooms] ([RoomNumber], [RoomType], [BedType], [Rate], [RoomStatus])
VALUES (343, 'Economy', 'Single', 33.00, 'Available')
     , (344, 'Business', 'Single', 73.00, 'Occupied')
     , (345, 'Economy', 'Double', 53.00, 'Available')

CREATE TABLE [Payments]
(
	[Id] INT PRIMARY KEY IDENTITY(1,1)
  ,	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL
  , [PaymentDate] DATETIME2 NOT NULL
  ,	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL
  ,	[FirstDateOccupied] DATETIME2 NOT NULL
  , [LastDateOccupied] DATETIME2 NOT NULL
  , [TotalDays] INT
  , [AmountCharged] DECIMAL(5,2)
  , [TaxRate] DECIMAL(7,5) DEFAULT 10.00000
  , [TaxAmount] DECIMAL(5,2)
  , [PaymentTotal] DECIMAL(5,2)
  , [Notes] NVARCHAR(MAX)
)

INSERT INTO [Payments] ([EmployeeId], [PaymentDate], [AccountNumber], [FirstDateOccupied], [LastDateOccupied], [PaymentTotal])
VALUES (2, '2024-03-12', 777, '2024-04-12', '2024-04-14', 48.35)
     , (3, '2024-03-12', 111, '2024-04-12', '2024-04-14', 48.35)
     , (1, '2024-03-12', 333, '2024-04-12', '2024-04-14', 48.35)

CREATE TABLE [Occupancies]
(
	[Id] INT PRIMARY KEY IDENTITY(1,1)
  ,	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL
  ,	[DateOccupied] DATETIME2 NOT NULL
  ,	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL
  ,	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms]([RoomNumber]) NOT NULL
  ,	[RateApplied] DECIMAL(4,2)
  ,	[PhoneCharge] DECIMAL(5,2)
  ,	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Occupancies]([EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber])
VALUES (2, '2024-04-12', 777, 343)
     , (3, '2024-04-12', 111, 344)
     , (1, '2024-04-12', 333, 345)










