CREATE TABLE [dbo].[TempratureStatistics]
(
	[Id] INT NOT NULL PRIMARY KEY,
	ObservationDate DATETIME NOT NULL,
	IndoorTemprature FLOAT NOT NULL,
	OutdoorTemprature FLOAT NOT NULL,
	IndoorHumidity FLOAT NULL,
	OutdoorHumidity FLOAT NULL
)
