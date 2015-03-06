CREATE TABLE [dbo].[TempratureStatistics]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	ObservationDate DATETIME NOT NULL,
	IndoorTemprature INT NOT NULL,
	OutdoorTemprature INT NOT NULL,
	IndoorHumidity INT NULL,
	OutdoorHumidity INT NULL
)
