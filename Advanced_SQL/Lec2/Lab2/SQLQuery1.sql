--Create a new user data type named loc with the following Criteria:
--nchar(2)
--default:NY 
--create a rule for this Datatype :values in (NY,DS,KW)) and associate it to the
 
 --1) create user data type loc
sp_Addtype loc, 'nchar(2)';
--2) create default value
CREATE DEFAULT def1 as 'NY';

--3) create rule
create rule r1 as @x in ('NY', 'DS', 'KW');
--4) bind default and rule
sp_bindrule r1, 'loc';
sp_bindefault def1, 'loc';

--5) create table Department
CREATE table Department (
DeptNo Varchar(2) primary key,
DeptName Varchar(20),
Location loc
);

INSERT INTO Department values('d1', 'Research', 'NY');
INSERT INTO Department values('d2', 'Accounting', 'DS');
INSERT INTO Department values('d3', 'Markiting', 'KW');

/*1-Create it by code
2-PK constraint on EmpNo
3-FK constraint on DeptNo
4-Unique constraint on Salary
5-EmpFname, EmpLname don’t accept null values
6-Create a rule on Salary column to ensure that it is less than 6000 */
CREATE TABLE Employee(
EmpNo INT PRIMARY KEY,
EmpFname VARCHAR(15) not null,
EmpLname VARCHAR(15) not null,
DeptNo VARCHAR(2) FOREIGN KEY REFERENCES Department(DeptNo),
Salary Smallint UNIQUE
);

CREATE RULE r2 as @x<6000;
sp_bindrule r2, 'Employee.Salary'

INSERT INTO Employee values(25348, 'Mathew', 'Smith', 'd3', 2500);
INSERT INTO Employee values(10102, 'Ann', 'Jones', 'd3', 3000);

-- Project Table
/*1-Create it using wizard
2-ProjectName can't contain null values
3-Budget allow null*/

--Testing Referential Integrity
--1-Add new employee with EmpNo =11111 In the works_on table [what will happen]
INSERT INTO Works_on VALUES (11111, 'p1', 'Tester', GETDATE());

--2-Change the employee number 10102  to 11111  in the works on table [what will happen]
UPDATE Works_on SET EmpNo = 11111 WHERE EmpNo = 10102;

--3-Modify the employee number 10102 in the employee table to 22222. [what will happen]
UPDATE Employee SET EmpNo = 22222 WHERE EmpNo = 10102;

--4-Delete the employee with id 10102
DELETE FROM Employee WHERE EmpNo = 10102;

--Table modification	
--1-Add  TelephoneNumber column to the employee table[programmatically]
ALTER TABLE Employee ADD TelephoneNumber VARCHAR(20);
--2-drop this column[programmatically]
ALTER TABLE Employee DROP COLUMN TelephoneNumber;
--3-Bulid A diagram to show Relations between tables

/*2.Create the following schema and transfer the following tables to it 
a.Company Schema 
i.Department table (Programmatically)
ii.Project table (using wizard)
b.Human Resource Schema
i.  Employee table (Programmatically)*/

CREATE SCHEMA Company;
-- 2. Transfer Department table to Company Schema
ALTER SCHEMA Company TRANSFER dbo.Department;

CREATE SCHEMA [Human Resource];
ALTER SCHEMA [Human Resource] TRANSFER dbo.Employee;

--3. Write query to display the constraints for the Employee table.
EXEC sp_helpconstraint '[Human Resource].Employee';

--4.Create Synonym for table Employee as Emp and then run the following queries and describe the results
create synonym Emp for [Human Resource].Employee;
--a.Select * from Employee
Select * from Employee;
--b.Select * from [Human Resource].Employee
Select * from [Human Resource].Employee;
--c.Select * from Emp
Select * from Emp;
--d.Select * from [Human Resource].Emp
Select * from [Human Resource].Emp;

--5.Increase the budget of the project where the manager number is 10102 by 10%.
UPDATE Company.Project SET Budget = Budget * 1.1
WHERE ProjectNo IN (
SELECT ProjectNo FROM Works_on WHERE EmpNo = 10102 AND Job = 'Manager'
);
-- With joins
UPDATE p SET p.Budget = p.Budget * 1.1
FROM Company.Project p INNER JOIN Works_on w
ON p.ProjectNo = w.ProjectNo
WHERE w.EmpNo = 10102 AND w.Job = 'Manager';

--6.Change the name of the department for which the employee named James works.
--The new department name is Sales.
UPDATE [Human Resource].Employee SET DeptNo = 
(SELECT DeptNo FROM Company.Department WHERE DeptName = 'Sales'
)
WHERE EmpFname = 'James';
-- With joins
UPDATE E SET DeptNo = D.DeptNo
FROM [Human Resource].Employee E INNER JOIN Company.Department D
ON D.DeptName = 'Sales' 
WHERE E.EmpFname = 'James';

--7.Change the enter date for the projects for those employees who work
--in project p1 and belong to department ‘Sales’. The new date is 12.12.2007.
UPDATE dbo.Works_on SET Enter_Date = '2007-12-12'
WHERE ProjectNo = 'p1'
AND EmpNo IN 
(SELECT e.EmpNo FROM [Human Resource].Employee e
INNER JOIN Company.Department d ON e.DeptNo = d.DeptNo
WHERE d.DeptName = 'Sales');

--with joins
UPDATE W SET W.Enter_Date = '2007-12-12'
FROM dbo.Works_on W INNER JOIN [Human Resource].Employee E
ON W.EmpNo = E.EmpNo
INNER JOIN Company.Department D
ON E.DeptNo = D.DeptNo
WHERE W.ProjectNo = 'p1' and D.DeptName = 'Sales';


--8.Delete the information in the works_on table for all employees 
--who work for the department located in KW.
DELETE FROM Works_on WHERE EmpNo IN
(SELECT e.EmpNo FROM [Human Resource].Employee e
INNER JOIN Company.Department d ON e.DeptNo = d.DeptNo
WHERE d.Location = 'KW');

--with joins
DELETE W
FROM Works_on W
INNER JOIN [Human Resource].Employee E ON W.EmpNo = E.EmpNo
INNER JOIN Company.Department D ON E.DeptNo = D.DeptNo
WHERE D.Location = 'KW';

--9.Try to Create Login Named(ITIStud) who can access Only student and 
--Course tablesfrom ITI DB then allow him to select and insert 
--data into tables and deny Delete and update .(Use ITI DB)