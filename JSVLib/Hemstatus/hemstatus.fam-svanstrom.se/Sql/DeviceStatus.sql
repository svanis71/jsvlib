CREATE TABLE [dbo].[DeviceStatus]
(
	[Id] INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(30) NOT NULL,
	Status INT NOT NULL CONSTRAINT CK_DeviceStatus_Status CHECK(Status IN (0, 1))
)
