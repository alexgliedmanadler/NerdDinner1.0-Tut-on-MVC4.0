CREATE TABLE [dbo].[Dinners]
(
	[DinnerID] INT NOT NULL IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL,
	[EventDate] datetime NOT NULL,
	[Description] NVARCHAR(50) NOT NULL,
	[HostedBy] NVARCHAR(50) NOT NULL,
	[ContactPhone] NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(50) NOT NULL,
	[Country] NVARCHAR(30) NOT NULL,
	[Latitude] float NOT NULL,
	[Longitude] float NOT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([DinnerID])
)
