--Company columns
declare  @company nchar(50), @companyKey int, @phone nchar(13), @link nvarchar(max), @address1 nchar(50), @address2 nchar(50), @city nchar(30), @state nchar(2), @zip nchar(10), @companyNote nvarchar(max), @positionkey int, @jobtitle nchar(200), @positionnote nvarchar(max), @positionlink nvarchar(max), @payrate nchar(25), @positionstatus nchar(10);

set @company = 'Emerald Resource Group';
set @phone = '440-922-9000';
set @link = 'https://www.emeraldresourcegroup.com/';
set @address1 = '1 Eagle Valley Court';
set @address2 = '';
set @city = 'Broadview Heights';
set @state = 'OH';
set @zip = '44147';
set @jobtitle = 'Software Engineer';
set @positionnote = ' The Opportunity

This role is ideal for a hands-on .NET Web Developer who enjoys working across the full software development lifecycle and contributing to business-critical systems. You will join a collaborative development team responsible for building, enhancing, and supporting high-traffic ecommerce and internal applications that directly impact the business.


What You Will Do

Design, develop, test, and maintain applications using C# and .NET
Execute full lifecycle software development from requirements through deployment
Write clean, efficient, and well-documented code
Collaborate with cross-functional teams to assess technical feasibility and system design
Integrate software components into scalable, fully functional systems
Develop and execute software verification and quality assurance procedures
Create and maintain technical documentation including specifications and workflows
Serve as a technical resource and mentor for other developers
Recommend improvements to tools, processes, and development standards
Stay current with modern development tools and best practices


Required Qualifications

Bachelor’s degree in Computer Science, Engineering, Information Technology, or a related field
4 or more years of professional software development experience
Strong hands-on experience with C# and .NET
Solid understanding of object-oriented programming principles
Experience working with relational databases and SQL Server
Experience with full software development lifecycle methodologies
Must be legally authorized to work in the United States without sponsorship


Nice to Have

Experience with front-end technologies such as React, Angular, Vue, JavaScript, HTML, CSS, or jQuery
Exposure to Unix or Linux environments
Experience supporting or modernizing legacy systems
Knowledge of data communications or socket-based integrations


Work Environment

100% remote role
U.S.-based candidates only
No visa sponsorship available
';
--******************************************************************
set @positionlink = 'https://www.linkedin.com/jobs/view/4368883033/?trackingId=0NBmSPAYS8KWhnIGvCFIAg%3D%3D&refId=DmFYtittSAip%2FdB6NwGmcg%3D%3D&eBP=NOT_ELIGIBLE_FOR_CHARGING&midToken=AQE_3XQkBAKpjA&midSig=3KWtRLsCcdcY81&trk=eml-jobs_jymbii_digest-job_card-0-jobcard_body_4368883033&trkEmail=eml-jobs_jymbii_digest-job_card-0-jobcard_body_4368883033-null-mw6pip~ml8srjvh~k9-null-null&eid=mw6pip-ml8srjvh-k9&otpToken=MTMwNjE2ZTQxMTJmY2ZjMWJkMmQwZmViNDExOWU3YjY4YWM4ZDE0ODkxYTk4YjY4N2JkYTAyNmU0ODVlNTlmMGZlZDRkY2ViMThkMGQzZjI3NGJhZjJiMjFkZWQzMDE3YjgzZGM5ZTNlZTM4ZDNhYjVlZjU5Zjc2MjUsMSwx';
set @payrate = 'Up 2 125k';
set @companyNote = 'Our client is a privately held, highly profitable ecommerce organization with approximately $800 million in annual revenue. Based in the Columbus, Ohio area, the company has built a strong national presence and long-term stability while continuing to invest heavily in technology, scalability, and modern development practices.
';

Begin Transaction;
insert into [dbo].[company] (CompanyName, Phone, Link, Address1, Address2, City, State, Zip, Comment)
       values (@company, @phone,@link,@address1,@address2,@city,@state,@zip,@companyNote);

set @companykey = (select Company_Key from [dbo].[company] where companyName = @company);


--Insert Position
insert into [dbo].[Position] (Company_Key,Position,Note,Rate,Link,ApplicationDate,LastContactDate,Status,StatusDate) 
       values (@companykey,@jobtitle,@positionnote,@payrate,@positionlink,CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE) ,'Open',CAST(GETDATE() AS DATE));

set @positionkey = (select Position_Key from [dbo].[Position] where Company_Key = @companykey);

--Insert Contact
Insert Into [EmpSearch].[dbo].[Contact] (Position_Key, Person_Key, ContactDate, ContactMethod, Description) 
       values (@positionkey,0,CAST(GETDATE() AS DATE),'Email','Application Submitted');


--select max(position_key) from position
select * from position where position_key = @positionkey
select * from company where company_key = @companyKey
select * from contact where Position_Key = @positionkey

--delete from position where position_key = 169
--delete from company where Company_Key = 168


--commit;