select * from company where CompanyName like '%Wex%'
select * from position where Company_Key = 109
select * from Contact where Position_Key = 115

Begin transaction

Insert Into [EmpSearch].[dbo].[Contact] (Position_Key, Person_Key, ContactDate, ContactMethod, Description) 
       values (115,0,CAST(GETDATE() AS DATE),'Email','Rejection Received');

update Position set Status = 'Closed', StatusDate = CAST(GETDATE() as DATE) where Position_Key = 115;

Rollback
commit