----- Pre-Deployment Script Template							
----------------------------------------------------------------------------------------
---- This file contains SQL statements that will be executed before the build script.				
----------------------------------------------------------------------------------------
USE SmileDirectClubAisenBrenes

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- DROP TABLES
IF OBJECT_ID('Document') IS NOT NULL 
BEGIN
	DROP TABLE IF EXISTS [dbo].[Document]
END 
IF OBJECT_ID('Customer') IS NOT NULL 
BEGIN
	DROP TABLE IF EXISTS [dbo].[Customer]
END 

-- CREATE TABLE Customer
CREATE TABLE [dbo].[Customer] (
	[CustomerId] [INT] IDENTITY(1,1) NOT NULL CONSTRAINT [PK_CustomerId] PRIMARY KEY CLUSTERED, 
	[CustomerName] [NVARCHAR](250) NOT NULL,
	[CustomerAddress] [NVARCHAR](250) NULL,
	[CustomerPhone] [NVARCHAR](250) NULL,
	[CreatedBy] [NVARCHAR](50) NULL,
	[CreatedOn] DATETIME NULL,
	[UpdatedBy] [NVARCHAR](50) NULL,
	[UpdatedOn] DATETIME NULL
)
GO

-- NO CLUSTERED INDEXES
CREATE NONCLUSTERED INDEX IX_Customer_CustomerName
ON [dbo].[Customer] (CustomerName ASC)

-- Insert data into Customer table
INSERT INTO [dbo].[Customer]
VALUES 
(
'Customer Smile Direct Club',
'Alajuela',
'22222222',
'admin',
GETDATE(),
'admin',
GETDATE()
),
(
'Aisen Brenes',
'Curridabat',
'8888888',
'admin',
GETDATE(),
'admin',
GETDATE()
)

-- CREATE TABLE Document
CREATE TABLE [dbo].[Document] (
	[DocumentId] [INT] IDENTITY(1,1) NOT NULL CONSTRAINT [PK_DocumentId] PRIMARY KEY CLUSTERED, 
	[FileName] [NVARCHAR](500) NULL, 
	[FilePath] [NVARCHAR](1000) NULL,
	[CustomerId] [INT] NOT NULL, 
	CONSTRAINT FK_Document_CustomerId FOREIGN KEY (CustomerId) REFERENCES [Customer]([CustomerId]),
	[CreatedBy] [NVARCHAR](50) NULL,
	[CreatedOn] DATETIME NULL,
	[UpdatedBy] [NVARCHAR](50) NULL,
	[UpdatedOn] DATETIME NULL
)
GO
