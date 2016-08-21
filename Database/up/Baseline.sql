CREATE SCHEMA Customer;
GO 
CREATE TABLE Customer.Customer
(
	CustomerId bigint identity(1,1) NOT NULL	
		CONSTRAINT PK_Customer_CustomerId PRIMARY KEY CLUSTERED
	,FirstName nvarchar(100) NOT NULL
	,LastName nvarchar(100) NOT NULL
	,MiddleInitial nvarchar(4) NULL
	,Tile nvarchar(4) NULL
	,Birthdate DateTime NOT NULL
	,ActiveEmailAddress nvarchar(100) NULL
)

GO
Create Table Customer.HistoricalAddresses
(
	HistoricalAdresseslId INT IDENTITY(1,1)
		CONSTRAINT PK_HistoricalAddresses PRIMARY KEY CLUSTERED
	,CustomerId bigint NOT NULL 
		CONSTRAINT FK_HistoricalAddresses_Customer_CustomerId
			FOREIGN KEY REFERENCES Customer.Customer(CustomerId)
	,LineOne nvarchar(100) NOT NULL
	,LineTwo nvarchar(100) NULL
	,City nvarchar(100) NOT NULL
	,[State] nvarchar(100) NULL
	,DateAdded datetime NOT NULL
	,DateInvalidated datetime null
	,IsActive bit NOT NULL
		CONSTRAINT DF_HistoricalAddresses_IsActive_Not DEFAULT (0)
)
GO
CREATE UNIQUE INDEX IX_HistoricalAddresses on Customer.HistoricalAddresses(CustomerId) WHERE IsActive=1