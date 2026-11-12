USE [EmpSearch]
GO

/****** Object:  StoredProcedure [dbo].[GetPositionStats]    Script Date: 11/4/2026 2:02:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UpdatePositionStatus]
	@PositionID INT,    -- Key of the Position being updated
	@NewStatus char(10) -- Status Update

AS
BEGIN

	Declare @StatusMsg nchar(30) = ''

	if @NewStatus = 'Closed'
		Set @StatusMsg = 'Position Closed'
	else
		Set @StatusMsg = 'Rejection Received'

	Insert Into [EmpSearch].[dbo].[Contact] (Position_Key, Person_Key, ContactDate, ContactMethod, Description) 
       values (@PositionID,0,CAST(GETDATE() AS DATE),'Email',@StatusMsg);


	Update dbo.Position 
	Set Status = @NewStatus, StatusDate = CAST(GETDATE() AS DATE), LastContactDate = CAST(GETDATE() as DATE)
	Where Position_Key = @PositionID;


end;

GO


