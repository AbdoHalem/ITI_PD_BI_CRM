--1)1.Retrieve number of students who have a value in their age.
select count(St_Id) from Student where St_Age is not null;

--2)Get all instructors Names without repetition
select Ins_Name from Instructor group by Ins_Name;

--3)Display student with the following Format (use isNull function)
SELECT St_Id AS [Student ID], 
ISNULL(St_Fname, '') + ' ' + ISNULL(St_Lname, '') AS [Student Full Name],
Dept_Name as [Department name] FROM Student s, Department d
Where s.Dept_Id = d.Dept_Id;

--4)Display instructor Name and Department Name
select Ins_Name, Dept_Name from Instructor i LEFT JOIN Department d
ON i.Dept_Id = d.Dept_Id;

--5)Display student full name and the name of the course he is taking
--For only courses which have a grade
select St_Fname+' '+St_Lname as [Student Full Name],
Crs_Name as [Course Name] from Student, Course, Stud_Course
where Student.St_Id = Stud_Course.St_Id
and Stud_Course.Grade is not null;

--6)Display number of courses for each topic name
select Top_Name, count(Crs_Id) as [Number of Courses]
from Course, Topic where Topic.Top_Id = Course.Top_Id
group by Top_Name;

--7)Display max and min salary for instructors
select max(Salary) as Max_Salary, min(Salary) as Min_Salary from Instructor;

--8)Display instructors who have salaries less than the average
--salary of all instructors.
select * from Instructor Where Salary < 
(select AVG(Salary) from Instructor);

--9)Display the Department name that contains the 
--instructor who receives the minimum salary.
select Dept_Name from Department d, Instructor i
where d.Dept_Id = i.Dept_Id and i.Salary = 
(select min(Salary) from Instructor);

--10)Select max two salaries in instructor table
select top(2) Salary from Instructor
Order by Salary Desc;

--11)Select instructor name and his salary but if there is no
--salary display instructor bonus keyword. “use coalesce Function”
SELECT Ins_Name, 
COALESCE(CONVERT(varchar, Salary), 'instructor bonus')
AS Salary_Status
FROM Instructor;

--12)Select Average Salary for instructors
select AVG(Salary) from Instructor;

--13)Select Student first name and the data of his supervisor
select s.St_Fname, Super.* from Student s LEFT JOIN Student Super
ON s.St_super = Super.St_Id;

--14)Write a query to select the highest two salaries in Each
--Department for instructors who have salaries. “using one of Ranking Functions”
select Salary, Dept_Id from
(select *, ROW_NUMBER() over(Partition by Dept_Id order by Salary Desc) as RN
from Instructor) as Stable where RN <= 2 and Salary is not null;

--15)Write a query to select a random student from each department.
--“using one of Ranking Functions”
select * from
(select *, ROW_NUMBER() over(partition by Dept_Id order by NEWID()) as RN
from Student) as Stable Where RN = 1;