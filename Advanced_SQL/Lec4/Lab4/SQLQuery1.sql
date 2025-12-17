use ITI;

--1. Create a view that displays student full name, course name if the student has a grade more than 50.
create view Stud_data as
	select St_Fname+' '+St_Lname as [Full Name], Crs_Name
	from Student s INNER Join Stud_Course sc on s.St_Id = sc.St_Id
	INNER join Course c on c.Crs_Id = sc.Crs_Id
	WHERE sc.Grade > 50;

select * from Stud_data;

--2. Create an Encrypted view that displays manager names and the topics they teach. 
create view Manager_Topics WITH ENCRYPTION as
	select Ins_Name, Top_Name
	from Instructor i INNER JOIN Department d on i.Ins_Id = d.Dept_Manager
	INNER join Ins_Course ic on ic.Ins_Id = i.Ins_Id
	INNER JOIN Course c on c.Crs_Id = ic.Crs_Id
	INNER JOIN Topic t on t.Top_Id = c.Top_Id;

select * from Manager_Topics;

--3. Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department 
alter view Ins_Deb as
	select Ins_Name, Dept_Name
	from Instructor i INNER JOIN Department d on i.Dept_Id = d.Dept_Id
	WHERE d.Dept_Name IN ('SD', 'Java');

select * from Ins_Deb;

--4. Create a view “V1” that displays student data for student who lives in Alex or Cairo. 
--Note: Prevent the users to run the following query 
--Update V1 set st_address=’tanta’
--Where st_address=’alex’;
create view V1 as
	select * from Student s
	where s.St_Address in ('Alex', 'Cairo')
	with check option;
--test
Update V1 set st_address='tanta' Where st_address='alex';

--5. Create a view that will display the project name and the number of employees work on it.
--“Use SD database”
use SD;
alter view Proj_EmpNum as
	select ProjectName, count(e.EmpNo) as [Number of Employees]
	from Company.Project p INNER JOIN dbo.Works_on wo on p.ProjectNo = wo.ProjectNo
	INNER JOIN [Human Resource].Employee e on wo.EmpNo = e.EmpNo
	group by p.ProjectName;

select * from Proj_EmpNum;

--6.Create index on column (Hiredate) that allow u to cluster the data in table Department.
--What will happen?
use ITI;
create clustered index i2 on Department(Manager_hiredate);

--7.Create index that allow u to enter unique ages in student table. What will happen? 
create unique index i1 on Student(St_Age);

--8.Using Merge statement between the following two tables [User ID, Transaction Amount]
Merge Last_Transc as target
using Daily_Transc as source
on target.User_ID = source.User_ID
-- If UserID exists in both tables -> Update the amount
WHEN MATCHED THEN
    UPDATE SET target.Transc_Amount = source.Transc_Amount
-- If UserID exists in Source but NOT in Target -> Insert new row
WHEN NOT MATCHED BY TARGET THEN
    INSERT (User_ID, Transc_Amount)
    VALUES (source.User_ID, source.Transc_Amount);

select * from Last_Transc;

--Part2: use SD_DB
use SD;
--1)Create view named “v_clerk” that will display employee#,project#,
--the date of hiring of all the jobs of the type 'Clerk'.
alter view v_clerk as
	select EmpNo, ProjectNo, Enter_Date
	from Works_on WHERE Job = 'Clerk';

select * from v_clerk;

--2) Create view named  “v_without_budget” that will display all the projects data without budget
create view v_without_budget as
	select ProjectNo, ProjectName from Company.Project;

--3)Create view named  “v_count “ that will display the project name and the # of jobs in it
create view v_count as
	SELECT ProjectName, COUNT(Job) AS JobCount
    FROM Company.Project p
    INNER JOIN Works_on w ON p.ProjectNo = w.ProjectNo
    GROUP BY p.ProjectName;

--4) Create view named ” v_project_p2” that will display the emp#  for the project# ‘p2’
--use the previously created view  “v_clerk”
create view v_project_p2 as
	select EmpNo from v_clerk vc where ProjectNo = 'p2';

--5)modifey the view named  “v_without_budget”  to display all DATA in project p1 and p2
alter view v_without_budget as
	select * from Company.Project
	where ProjectNo in ('p1', 'p2');

--6)Delete the views  “v_ clerk” and “v_count”
DROP VIEW v_clerk;
DROP VIEW v_count;

--7)Create view that will display the emp# and emp lastname who works on dept# is ‘d2’.
create view v_emp as
	select EmpNo, EmpLname 
	from [Human Resource].Employee where DeptNo = 'd2';

--8)Display the employee lastname that contains letter “J”
--Use the previous view created in Q#7
select EmpLname from v_emp WHERE EmpLname LIKE '%J%';

--9)Create view named “v_dept” that will display the department# and department name.
create view v_dept as
	select DeptNo, DeptName from Company.Department;

--10)using the previous view try enter new department data where dept# is ’d4’
--and dept name is ‘Development’
insert into v_dept values('d4', 'Development');

--11)Create view name “v_2006_check” that will display employee#, the project#
--where he works and the date of joining the project
--which must be from the first of January and the last of December 2006.
create view v_2006_check as
	select EmpNo, ProjectNo, Enter_Date
	FROM Works_on
    WHERE Enter_Date BETWEEN '2006-01-01' AND '2006-12-31'
    with check option;