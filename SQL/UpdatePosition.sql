
select 'Company' as TableName,* from company where CompanyName like '%rta%' order by CompanyName Desc
select 'Position' as TableName,* from position where Company_Key in (1741) order by ApplicationDate desc
select 'Contact' as TableName,* from Contact where Position_Key in (9554)

Begin transaction

declare  @positionKey int

set @positionKey = 8466

Insert Into [EmpSearch].[dbo].[Contact] (Position_Key, Person_Key, ContactDate, ContactMethod, Description) 
--       values (@positionKey,0,CAST(GETDATE() AS DATE),'eMail','Position Closed');
       values (@positionKey,0,CAST(GETDATE() AS DATE),'eMail','Rejection Received');
--       values (@positionKey,0,CAST(GETDATE() AS DATE),'eMail','Application Submitted');
--       values (@positionKey,0,CAST(GETDATE() AS DATE),'Inded','Not Selected by employer');


update Position set Status = 'Rejected', LastContactDate = CAST(GETDATE() as DATE), StatusDate = CAST(GETDATE() as DATE) where Position_Key = @positionKey;




-- Existing Company; New Position

declare @note nvarchar(max)
set @note = 'Pay Range 

USD $79,872.00 - USD $98,003.00 /Yr.

 STAR Bonus % (At Risk Maximum) 

5.00 - Salaried Non-Management except pharmacists

Work Schedule Description (e.g. M-F 8am To 5pm)

M-F 8am to 5pm

 Remote Work Notification 

ATTENTION: Navitus is unable to offer remote work to residents of Alaska, Hawaii, Maine, Mississippi, New Hampshire, New Mexico, North Dakota, Rhode Island, South Carolina, South Dakota, West Virginia, and Wyoming.

Overview

Navitus Health Solutions is seeking a Software Developer II to join our team!

The Software Developer II ensures efforts are in alignment with the Information Technology team to support customer-focused objectives and the IT Vision, a collaborative partner delivering innovative ideas, solutions, and services to simplify people’s lives. The Software Developer IIs role is to define, develop, test, analyze, and maintain new and existing software applications in support of the achievement of business requirements. This includes designing, documenting, coding, testing, and analyzing software programs and applications. The Software Developer II will also research, design, document, and modify software specifications throughout the production life cycle.

Is this you? Find out more below!

Responsibilities

How do I make an impact on my team?

Define, develop, and document software business requirements, objectives, deliverables, and specifications on a project-by-project basis in collaboration with internal users and departments
Design, develop, document, and implement new applications and application enhancements according to business and technical requirements
Consistently write, translate, and code software programs and applications according to specifications
Write new and modify existing programming scripts to enhance functionality and/or performance of company applications as necessary
Design, run and monitor software performance tests on new and existing programs for the purposes of correcting errors, isolating areas for improvement, and general debugging
Generate statistics and write reports for management and/or team members on the status of the programming process
Train end users to operate new or modified programs
Utilize Unix/Linux shell scripting, Informatica/Talend, C# and .NET(required), React (required), AWS Cloud Development, CDK, Oracle, Telerik, MS SQL, PostgreSQL or other noSQL database development experience, and Visual Studio/Team Foundation Studio
On -call availability and some travel may be required
Other duties as assigned

Qualifications

What our team expects from you? 

College diploma or university degree in the field of Computer Science, Information Systems, or Software Engineering, and/or 6 years equivalent experience
Minimum two years of experience required
Experience interviewing end-users for insight on functionality, interface, problems, and/or usability issues
Hands-on experience developing test cases and test plans
Experience with agile methodologies and Agile project management tools such as Jira, Azure DevOps, etc
Experience with cloud-first, API-first and microservice architecture and or strategies is a plus
Experience with CI/CD pipelines and DevOps practices is a plus
Experience building cloud-native applications in AWS. 
Excellent understanding of coding methods and best practices
Working knowledge or experience with source control tools such as TFS and GitHub
healthcare industry practices and HIPAA knowledge would be a plus
Knowledge of applicable data privacy practices and laws
Participate in, adhere to, and support compliance program objectives
The ability to consistently interact cooperatively and respectfully with other employees

 What can you expect from Navitus? 

 Top of the industry benefits for Health, Dental, and Vision insurance 
 20 days paid time off 
 4 weeks paid parental leave 
 9 paid holidays 
 401K company match of up to 5% - No vesting requirement 
 Adoption Assistance Program 
 Flexible Spending Account 
 Educational Assistance Plan and Professional Membership assistance 
 Referral Bonus Program – up to $750! 

 Location : Address 

Remote

 Location : Country 

US
'
--Update Company set Comment = @note where Company_Key = 158

Insert Into Position (Company_Key, Position, Note, Rate,Link, ApplicationDate, LastContactDate, Status, StatusDate)
       values (1741, 'Software Developer II', @note, '79-98K', 'https://www.linkedin.com/jobs/view/4451005356/?trk=eml-email_job_alert_digest_01-primary_job_list-0-jobcard_body_3_jobid_4451005356_ssid_14583149764_fmid_mw6pip~mthj7h2l~cv&refId=I0Ad2sKZk70d8vKkTanFSg%3D%3D&trackingId=lUIBRIsxal7a%2F6GNxOQJQw%3D%3D'
	          ,CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE) ,'Open',CAST(GETDATE() AS DATE));

Declare @pos_key int;
set @pos_key = (select max(Position_key) from Position);

Insert Into [EmpSearch].[dbo].[Contact] (Position_Key, Person_Key, ContactDate, ContactMethod, Description) 
       values (@pos_key,0,CAST(GETDATE() AS DATE),'Site','Application Submitted');


--Begin transaction

--update position set status = 'Closed' where Position_Key = 2240

-- Duplicate Position
--------------------------
declare  @pos int
set @pos = 1553

delete Position where Position_Key = @Pos
delete Contact where Position_Key = @Pos

-- Duplicate Company
--------------------
--update position set Company_Key = 1367 where Company_Key = 1395
--update position set Company_Key = 1297 where Company_Key = 1684
--delete company where company_key in (1395)


--update position set Position = 'C# Developer (Remote - Atlanta)' where Position_Key = 157

--Update company set CompanyName = 'Capgemini' where Company_Key = 154

--delete contact where Contact_Key in (3594,3596,3597,3598)

--select * from position where position like '%Technology%'

--update position set Status = 'Closed', StatusDate = CAST(GETDATE() AS DATE) where Position_Key = 9554
--delete Contact where Position_Key = 1580
--delete Position where Position_Key = 1580

Insert Into [EmpSearch].[dbo].[Contact] (Position_Key, Person_Key, ContactDate, ContactMethod, Description) 
       values (9554,0,CAST(GETDATE() AS DATE),'Phone','Had a good call, but realized as she was going over the job description that she was recruiting for Timken.  As I have already applied directly to Timken there was no reason to contine the interview.  I asked to be kept in mind for any other positions that they come across');


Rollback
--commit


