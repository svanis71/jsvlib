CREATE PROCEDURE [dbo].[UpdateDevice]
	@Id int,
	@Name nvarchar(30),
	@Status int
AS
	if exists (select top 1 Name from DeviceStatus where Id = @Id) 
	begin
		update DeviceStatus
		set Name = @Name, Status = @Status
		where Id = @Id
	end
	else
	begin
		insert into DeviceStatus values (@Id, @Name, @Status)
	end

RETURN 1
