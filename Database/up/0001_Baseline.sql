CREATE SCHEMA Customer;
GO 
CREATE TABLE Customer.Customer
(
	CustomerId int identity(1,1) NOT NULL	
		CONSTRAINT PK_Customer_CustomerId PRIMARY KEY
)