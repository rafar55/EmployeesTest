CREATE TABLE Employees(
	Id int Primary key IDENTITY(1,1),
	FirstName nvarchar(50)  NOT NULL,
	LastName nvarchar(50) NOT NULL,
	Phone nvarchar(12) NULL,
	ZipCode nvarchar(50) NOT NULL,
	HireDate date NOT NULL,
	CreatedAt datetimeoffset NOT NULL DEFAULT(SYSDATETIMEOFFSET()) 
)
