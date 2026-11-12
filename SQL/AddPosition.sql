--Company columns
declare  @company nchar(50), @companyKey int, @phone nchar(13), @link nvarchar(max), @address1 nchar(50), @address2 nchar(50), @city nchar(30), @state nchar(2), @zip nchar(10), @companyNote nvarchar(max), @positionkey int, @jobtitle nchar(200), @positionnote nvarchar(max), @positionlink nvarchar(max), @payrate nchar(25), @positionstatus nchar(10);

set @company = 'OrthoFi';
set @phone = '';
set @link = '';
set @address1 = '';
set @address2 = '';
set @city = 'Remote';
set @state = '';
set @zip = '';
set @jobtitle = 'Senior Software Engineer';

set @positionnote = 'At OrthoFi, we are looking for a talented, full stack Senior Software Engineer to drive technical execution and tackle complex challenges in our Insurance domain. This role requires a deep understanding of building scalable, modern applications while navigating the complexities of an industry with strict regulations, high data integrity requirements, and intricate workflows.

As a Senior Engineer, you will serve as a critical technical problem-solver— who takes extreme ownership of building scalable, highly reliable software systems in an agile environment. In this role, you will navigate the technical and regulatory complexities of insurance eligibility, claims processing, and remittance workflows. You will work closely with domain experts, product managers, and engineering peers to modernize legacy systems, design service-based architectures, and deliver high-impact software.

Success in this role is measured by your ability to evolve our core systems with a relentless focus on Business ROI and long-term technical health. Beyond writing exceptional code, you will champion the integration and adoption of AI tools, agentic workflows, and other efficiency drivers to fundamentally reshape how we develop software.

What You Will Do
As a Senior Software Engineer your core responsibilities include:

Design & System Evolution: Decompose complex business scenarios into clean, service-based architectures and distributed systems. Modernize legacy platforms with a focus on simplicity, maintainability, and long-term ROI.
Domain Alignment: Translate complex orthodontic insurance rules (claims, eligibility, remittance) into clean, high-performing technical solutions.
Epic Ownership: Own the delivery of Epics end-to-end, actively managing risks, dependencies, and team-level DORA KPIs while ensuring system performance and delivery reliability.
Full-Stack Development: Write clean, robust, and maintainable code across the stack, leveraging modern JavaScript frameworks (React) on the frontend and .NET Core/.NET Framework on the backend.
AI-Assisted Engineering: Champion responsible, AI-assisted development. Actively integrate AI tools (e.g., Claude, GitHub Copilot) to automate design, test generation, and code reviews, and build agentic workflows to drive team efficiency.
Software Design & Quality: Set rigorous standards for code quality through constructive code reviews, comprehensive automated testing (including AI-driven test suites), and continuous integration/delivery (CI/CD).
Technical Leadership & Mentorship: Guide junior and mid-level engineers on software design patterns, debug cross-module issues, and act as a professional stakeholder manager who can navigate technical disagreements constructively ("disagree and commit").
What You Will Bring

Education & Core Experience

Education: 4-year Bachelor’s degree in a STEM (Science, Technology, Engineering, Mathematics) major or a Masters degree in Technology or Computer Science or related field.
Professional Experience: 10+ years of professional software development experience, with a minimum of 4+ years in a Senior Software Engineer role (or equivalent).
Core Technical Expertise
Backend Ecosystem: Strong, hands-on experience with the .NET Ecosystem (.NET Core / .NET Framework) and robust relational database design using SQL Server (including query optimization).
Frontend Ecosystem: Extensive experience building highly responsive, scalable user interfaces using modern JavaScript frameworks—specifically React and/or Angular (Required).
Architecture & Design: Practical experience applying Domain-Driven Design (DDD) principles and building service-based or distributed architectures.
Cloud & DevOps: Strong proficiency with AWS services (or other major cloud architectures), CI/CD pipelines and infrastructure provisioning.
Batch & Data Processing: Familiarity with high-volume batch processing, background automated jobs, and handling complex data streams.
Preferred Technical Pluses
Experience with Infrastructure as Code (IaC) using Terraform.
Familiarity with event-driven architectures and system monitoring/APM tools (e.g., Datadog).
Prior domain knowledge in orthodontic/dental billing, medical insurance, or healthcare fintech.
Experience designing and querying APIs with GraphQL.
Experience with search and analytics engines, specifically ElasticSearch.
AI & Automation Mindset
Demonstrated experience or active experimentation leveraging modern AI coding assistants (e.g., Cursor, Claude, GitHub Copilot) to optimize development velocity.
Familiarity with Gen AI and Enterprise agentic workflows or utilizing Model Context Protocols (MCPs) to automate engineering workflows.
Experience with automated testing frameworks (such as Playwright or equivalent) driven by AI agents.
How You Will Work
Engineering Persona: The Site Manager. You focus on building highly structured systems and show extreme ownership and systems thinking over your domain’s codebase.
Delivery: You roadmap large tracks of work, identify non-functional requirements (NFRs) for Epics, and maintain high execution integrity without needing close supervision.
Problem Solving: You define the scope of open-ended, ambiguous problems and independently offer thoughtful, data-driven analysis to drive continuous process improvement.
Communication: You deliver persuasive, concise, and fact-backed technical communications tailored to both engineering teams and non-technical stakeholders.
Leadership: You raise the bar for code quality, manage stakeholder expectations, and proactively identify cross-team dependencies.
Code Fluency: You design reusable, modular components that adapt to changing business needs, prioritizing long-term maintainability over speed-first "copy-pasting."

What’s in it for you:

Full medical, dental, and vision plans
Flexible PTO
Employer HSA contribution
9 Company Paid holidays
401(k) match, 3% after 90 days of employment
Supportive culture with one-of-a-kind growth opportunities
Ability to work from home
Paid Parental Leave as well as a two-week "ease-back" program that enables parents to return part-time at full pay
Company and team outings
Peer-to-peer recognition program
Vendor discounts

';
--******************************************************************
set @positionlink = 'https://www.glassdoor.com/job-listing/healthcare-software-engineer-patient-centric-solutions-JV_KO0,28_KE29,54.htm?jl=1010241860306&utm_source=jobalert&utm_medium=email&utm_content=ja-jobpos3-age6d-1010241860306&utm_campaign=jobAlertAlert&tgt=GD_JOB_VIEW&src=GD_JOB_AD&uido=7A57A36BECDA9E413E76BB41CD0D8A0B&ao=1136043&jrtk=5-yul1-0-1k1emin7ajn0v800-56d13e7a435ca6f6&cs=1_f318d83f&s=224&t=JA&pos=103&ja=378462087&guid=000001a05d5877c88eafaa213b28b750&jobListingId=1010241860306&ea=1&vt=e&cb=1788273581621&ctt=1788273669584&srs=EMAIL_JOB_ALERT&gdir=1
';
set @payrate = '130-170K';
set @companyNote = 'At OrthoFi, were not just another player in the orthodontic industry – were the driving force that helps orthodontists launch more smiles while ensuring top-tier patient care. Our tech-savvy solutions are the secret sauce that empowers orthodontic practices across the United States. With a track record of supporting over 2,000 practices, and in partnership with OrthoBanc, weve unlocked access to quality, affordable orthodontic care for a whopping 3.2 million patients and counting!


Picture this: Our cutting-edge Patient Acquisition software combined with our expert Revenue Cycle Management solutions propels practices to achieve jaw-dropping 13% year-over-year growth. Plus, when it comes to patient and insurance billing, our collection results leave competitors in the dust.


Behind our mission is a dynamic team of around 300 passionate individuals. Our headquarters is based in Denver, CO, with employees spread across several states. Join us in our quest to transform the orthodontic landscape – where innovation meets dedication, and starting more smiles are just the beginning.


Our purpose is to radically improve the way patients access and pay for quality elective care. Diversity, equity, and inclusion (DEI) ensures we can fulfill our purpose by creating a better, more equitable and inclusive workplace for our community members and healthcare experience for all.


By focusing on DEI, we are working towards our mission of connecting more patients with quality orthodontic and dental care and helping make treatment accessible to over 1 million patients a year by 2025. Equity is core to our mission to serve patients, and DEI is embedded in our core values, especially “seek diversity,” and “do what’s right.”"


OrthoFi is proud to be an equal opportunity workplace and is an affirmative action employer. We are committed to equal employment opportunities regardless of race, color, ancestry, religion, sex, national origin, sexual orientation, age, citizenship, marital status, disability, gender identity or Veteran status.


Roles based outside of our Denver office can sit in any of the following states: Colorado, Florida, Georgia, Louisiana, North Carolina, Ohio, Tennessee, and Texas. Please only apply if you are able to live and work full-time in one of the states listed above.
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
select 'Position' as TableName,* from position where position_key = @positionkey
select 'Company' as TableName,* from company where company_key = @companyKey
select 'Contact' as TableName,* from contact where Position_Key = @positionkey

--delete from position where position_key = 169
--delete from company where Company_Key = 168

--rollback;
--commit;

