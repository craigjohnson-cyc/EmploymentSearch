select * from company where CompanyName like '%ancestry%'
select * from position where Company_Key = 104
select * from Contact where Position_Key = 108

Begin transaction

declare  @positionKey int

set @positionKey = 108

Insert Into [EmpSearch].[dbo].[Contact] (Position_Key, Person_Key, ContactDate, ContactMethod, Description) 
       values (@positionKey,0,CAST(GETDATE() AS DATE),'Email','Rejection Received');

update Position set Status = 'Closed', StatusDate = CAST(GETDATE() as DATE) where Position_Key = @positionKey;

Rollback
commit