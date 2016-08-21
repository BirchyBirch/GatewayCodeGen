CREATE SCHEMA Currency;
GO 
CREATE TABLE Currency.CurrencyMaster
(
	CurrencyMasterId int identity(1,1) NOT NULL	
		CONSTRAINT PK_CurrencyMaster_CurrencyMasterId PRIMARY KEY	
)