-- 1. Display the Department id, name and id and the name of its manager.
SELECT Dname, DNum, SSN, Fname, Lname FROM Employee e INNER JOIN Departments d
ON e.SSN = d.MGRSSN;

-- Display the name of the departments and the name of the projects under its control.
SELECT Dname, Pname FROM Departments d, Project as p WHERE d.Dnum = p.Dnum;

/* 3. Display the full data about all the dependence associated with the name of the 
employee they depend on him/her.*/
SELECT fname+' '+lname as [Emp Name], ESSN, Dependent_name, d.Sex, d.Bdate 
FROM Employee e, Dependent d WHERE e.SSN = d.ESSN;

/*4. Display (Using Union Function)
a. The name and the gender of the dependence that's gender is Female and 
depending on Female Employee.
b. And the male dependence that depends on Male Employee.*/
SELECT Dependent_name, d.Sex FROM Dependent d INNER JOIN Employee e ON d.ESSN = e.SSN
AND d.Sex = 'F' AND e.Sex = 'F'
UNION
SELECT Dependent_name, d.Sex FROM Dependent d INNER JOIN Employee e ON d.ESSN = e.SSN
AND d.Sex = 'M' AND e.Sex = 'M';

-- 5. Display the Id, name and location of the projects in Cairo or Alex city.
SELECT Pnumber, Pname, Plocation FROM Project WHERE City = 'Alex' OR City = 'Cairo';

-- 6. Display the Projects full data of the projects with a name starts with "a" letter.
SELECT * FROM Project WHERE Pname LIKE 'A%';

-- 7. Display all the employees in department 30 whose salary from 1000 to 2000 LE monthly
SELECT fname+' '+lname as [Emp Name] FROM Employee  WHERE Dno = 30 AND Salary BETWEEN 1000 AND 2000;

/* 8. Retrieve the names of all employees in department 10 who works more than or 
equal 10 hours per week on "AL Rabwah" project*/
SELECT fname+' '+lname as [Emp Name] FROM Employee WHERE Dno = 10
AND SSN IN (SELECT ESSN FROM Works_for WHERE Hours >= 10 
AND Pno = (SELECT Pnumber FROM Project WHERE Pname = 'AL Rabwah'));

-- 9. Find the names of the employees who directly supervised with Kamel Mohamed.
SELECT fname+' '+lname as [Emp Name] FROM Employee
WHERE Superssn = (SELECT SSN FROM Employee WHERE Fname='Kamel' and Lname='Mohamed');

/* 10. For each project, list the project name and the total hours per week (for all 
employees) spent on that project.*/
SELECT P.Pname, SUM(W.Hours) AS [Total Hours] FROM Project P
INNER JOIN Works_for W ON P.Pnumber = W.Pno
GROUP BY P.Pname, P.Pnumber;

/*11. Retrieve the names of all employees and the names of the projects they are 
working on, sorted by the project name.*/
SELECT e.fname+' '+e.lname as [Emp Name], p.Pname FROM Employee e, Project p, Works_for w
WHERE e.SSN = w.ESSn AND p.Pnumber = w.Pno ORDER BY p.Pname; 

/* 12. Display the data of the department which has the smallest employee ID over all
employees' ID.*/
/*SELECT * FROM Departments 
WHERE Dnum = (SELECT Dno FROM Employee WHERE SSN = (SELECT MIN(SSN) FROM Employee));*/
SELECT * FROM Departments WHERE Dnum = (SELECT TOP 1 Dno FROM Employee ORDER BY SSN ASC);

/*13. For each department, retrieve the department name and the maximum, minimum 
and average salary of its employees*/
SELECT d.Dname, MAX(e.Salary) as [Max Salary], MIN(Salary) as [Min Salary], 
AVG(e.Salary) as [Avg Salary] FROM Departments d INNER JOIN Employee e ON
d.Dnum = e.Dno GROUP BY d.Dname;

-- 14. List the last name of all managers who have no dependents.
SELECT lname FROM Employee 
WHERE SSN IN (SELECT MGRSSN FROM Departments) AND SSN NOT IN (SELECT ESSN FROM Dependent);

/*15. For each department-- if its average salary is less than the average salary of all 
employees-- display its number, name and number of its employees.*/
SELECT D.DNum, D.Dname, COUNT(E.SSN) AS NumberOfEmployees FROM Departments D
INNER JOIN Employee E ON D.DNum = E.Dno GROUP BY D.DNum, D.Dname
HAVING AVG(E.Salary) < (SELECT AVG(Salary) FROM Employee);

/*16. Retrieve a list of employees and the projects they are working on ordered by 
department and within each department, ordered alphabetically by last name, first 
name.*/
SELECT fname+' '+lname as [Emp Name], p.Pname FROM Employee e, Project p, Works_for w, Departments d
WHERE p.Pnumber = w.Pno AND w.ESSn = e.SSN AND e.Dno = d.Dnum
ORDER BY d.Dname, e.Fname, e.Lname;

/*17. For each project located in Cairo City , find the project number, the controlling 
department name ,the department manager last name ,address and birthdate.*/
SELECT p.Pnumber, d.Dname, e.lname, e.Address, e.Bdate FROM Project p, Departments d, Employee e
WHERE p.City = 'Cairo' AND d.MGRSSN = e.SSN AND p.Dnum = d.Dnum;

