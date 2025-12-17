use ITI;
--1.Create a scalar function that takes date and returns Month name of that date.
create FUNCTION getMonth(@inpDate date)
returns varchar(20)
begin
	declare @month varchar(20)
	select @month=FORMAT(@inpDate, 'MMMM')
	return @month
end
-- call
select dbo.getMonth(getdate());

--Create a multi-statements table-valued function that takes
--2 integers and returns the values between them.
create function getRange(@num1 int, @num2 int)
returns @t table(num int)
as
	begin
		while @num1 < @num2 - 1
		begin
			set @num1 += 1
			insert into @t values(@num1)
		end
		return
	end
-- call
select * from getRange(1, 5);

--3. Create inline function that takes Student No and returns
--Department Name with Student full name.
create function getStudent(@st_no int)
returns table as
	return
		(select s.St_Fname+' '+s.St_Lname as FullName, d.Dept_Name
		from Student s, Department d
		where @st_no = s.St_Id and s.Dept_Id = d.Dept_Id
		)

-- call
select * from getStudent(1);

--4.Create a scalar function that takes Student ID and returns a message to user 
--a.If first name and Last name are null then display 'First name & last name are null'
--b.If First name is null then display 'first name is null'
--c.If Last name is null then display 'last name is null'
--d.Else display 'First name & last name are not null'
alter function checkName(@stud_id int)
returns varchar(50)
begin
	declare @Fname varchar(20)
	select @Fname = St_Fname from Student where @stud_id=St_Id
	declare @Lname varchar(20)
	select @Lname = St_Lname from Student where @stud_id=St_Id
	if @Fname IS NULL and @Lname IS NULL
		return 'First name & last name are null'
	else if @Fname IS NULL
		return 'first name is null'
	else if @Lname IS NULL
		return 'last name is null'
	return 'First name & last name are not null';
end
--call
select dbo.checkName(2);
select dbo.checkName(13);
select dbo.checkName(14);

--5.Create inline function that takes integer which represents
--manager ID and displays department name, Manager Name and hiring date 
alter function getManager(@manager_id int)
returns table as
	return
	(select Dept_Name, Ins_Name, Manager_hiredate
	from Department d, Instructor i
	where @manager_id = d.Dept_Manager and i.Ins_Id = d.Dept_Manager
	)
--call
select * from dbo.getManager(4);

--6.Create multi-statements table-valued function that takes a string
--If string='first name' returns student first name
--If string='last name' returns student last name 
--If string='full name' returns Full Name from student table 
--Note: Use “ISNULL” function
create function getName(@req varchar(20))
returns @t table(stName varchar(50)) as
begin
	if @req = 'first name'
		insert into @t
		select ISNULL(St_Fname, '') from Student
	else if @req = 'last name'
		insert into @t
		select ISNULL(St_Lname, '') from Student
	else if @req = 'full name'
		insert into @t
		select ISNULL(St_Fname, '')+' '+ISNULL(St_Lname, '') from Student
	return
end
--call
select * from getName('first name');

--7.Write a query that returns the Student No and Student
--first name without the last char
SELECT St_Id, SUBSTRING(St_Fname, 1, LEN(St_Fname) - 1)
AS NewName FROM Student;

--8.Wirte query to delete all grades for the students Located in SD Department
UPDATE SC SET Grade = NULL
FROM Stud_Course SC
INNER JOIN Student S ON SC.St_Id = S.St_Id
INNER JOIN Department D ON S.Dept_Id = D.Dept_Id
WHERE D.Dept_Name = 'SD';

--Bonus:
--1.Give an example for hierarchyid Data type
-- 1. Create the table
CREATE TABLE CompanyOrg (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(50),
    OrgNode HIERARCHYID -- HierarchyID data type
);

-- 2. Insert Data (CEO and employees)
-- Root node (CEO) - represented by '/'
INSERT INTO CompanyOrg VALUES (1, 'CEO Big Boss', '/');

-- Direct reports to CEO
INSERT INTO CompanyOrg VALUES (2, 'Manager Ali', '/1/');  -- First branch
INSERT INTO CompanyOrg VALUES (3, 'Manager Mona', '/2/'); -- Second branch

-- Employees reporting to "Manager Ali" (Node /1/)
INSERT INTO CompanyOrg VALUES (4, 'Employee Ahmed', '/1/1/');
INSERT INTO CompanyOrg VALUES (5, 'Employee Sara', '/1/2/');

-- 3. Display Data
-- Use ToString() to convert the binary value to a readable string path
-- Use GetLevel() to show the hierarchy level (0 is Root/CEO)
SELECT 
    EmpName, 
    OrgNode.ToString() AS PathString, 
    OrgNode.GetLevel() AS Level       
FROM CompanyOrg;

--2.Create a batch that inserts 3000 rows in the student
--table(ITI database). The values of the st_id column
--should be unique and between 3000 and 6000.
--All values of the columns st_fname, st_lname,
--should be set to 'Jane', ' Smith' respectively.

declare @num int=3000;
while @num <= 6000
begin
	insert into Student(St_Id, St_Fname, St_Lname)
	values(@num, 'Jane', 'Smith')
	set @num += 1
end
