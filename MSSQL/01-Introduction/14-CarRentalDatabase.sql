--14.Car Rental Database
CREATE DATABASE CarRental
USE CarRental;

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL(4,2) NOT NULL,
	WeeklyRate DECIMAL(4,2) NOT NULL,
	MonthlyRate DECIMAL(4,2) NOT NULL,
	WeekendRate DECIMAL(4,2)
)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	PlateNumber NVARCHAR(10) NOT NULL,
	Manufacturer NVARCHAR(20) NOT NULL,
	Model NVARCHAR(20) NOT NULL,
	CarYear INT,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors INT,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(10) NOT NULL,
	Available BIT NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	City NVARCHAR(100) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel DECIMAL(5,2),
	KilometrageStart DECIMAL(6,2),
	KilometrageEnd DECIMAL(6,2),
	TotalKilometrage DECIMAL(6,2),
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NOT NULL,
	TotalDays INT,
	RateApplied NVARCHAR(20) NOT NULL,
	TaxRate NVARCHAR(20),
	OrderStatus NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate)
VALUES 
('Diesel', 20.05, 10.50, 9.00),
('Electric', 20.05, 10.50, 9.00),
('Gas', 20.05, 10.50, 9.00)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CategoryId, Condition, Available)
VALUES
('N430403', 'Toyota', 'Quattro', 2, 'Good', 1),
('N430403', 'Toyota', 'Quattro', 1, 'Good', 0),
('N430403', 'Toyota', 'Quattro', 3, 'Good', 1)

INSERT INTO Employees (FirstName, LastName, Title)
VALUES
('Tom', 'Riddle', 'Dark Lord'),
('Albus', 'Dumbledore', 'Warlock'),
('Harry', 'Potter', 'Student')

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode)
VALUES
(284694, 'Luna Lovegood', 'ul. Dubrovnik', 'Varna', 9000),
(284694, 'Neville Longbottom', 'ul. Krakra', 'Varna', 9000),
(284694, 'Colin Creevey', 'ul. Joan Ekzarh', 'Varna', 9000)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, StartDate, EndDate, RateApplied, OrderStatus)
VALUES
(2, 1, 3, '2024-05-20', '2024-05-23', 'Daily', 'Confirmed'),
(3, 2, 1, '2024-05-20', '2024-05-23', 'Daily', 'Cancelled'),
(1, 3, 2, '2024-05-20', '2024-05-23', 'Daily', 'Pending')