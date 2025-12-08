/*select * from Employee;
SELECT Fname, Lname, Salary, Dno FROM Employee;
SELECT Pname, Plocation, Dnum FROM Project;
SELECT Fname + ' ' + Lname as FullName, Salary * 12 * 0.1 as ANNUAL_COMM FROM Employee;
SELECT SSN, Fname + ' ' + Lname as FullName FROM Employee WHERE Salary > 1000;
SELECT SSN, Fname + ' ' + Lname as FullName FROM Employee WHERE Salary*12 > 10000;
SELECT Fname + ' ' + Lname as FullName, Salary FROM Employee WHERE Sex = 'F';
SELECT Dname, DNum FROM Departments WHERE MGRSSN = 968574;
SELECT Pname, Pnumber, Plocation From Project WHERE Dnum = 10;
*/

/* 1. Insert your personal data to the employee table as a new employee in department 
number 30, SSN = 102672, Superssn = 112233.*/
--INSERT INTO Employee(Dno, SSN, Superssn) VALUES(30, 102672, 112233);

/*2. Insert another employee with, personal data your friend as new employee in 
department number 30, SSN = 102660, but don’t enter any value for salary or 
supervisor number to him.*/
--INSERT INTO Employee(Dno, SSN) VALUES(30, 102660);

/*3. In the department table insert new department called "DEPT IT", with id 100,
employee with SSN = 112233 as a manager for this department. The start date for this 
manager is '1-11-2006'*/
--INSERT INTO Departments(Dname, DNum, MGRSSN, [MGRStart Date]) VALUES('DEPT IT', 100, 112233, '1-11-2006');

/*4. Do what is required if you know that: Mrs.Noha Mohamed(SSN=968574) moved to 
be the manager of the new department (id = 100), and they give you (use your SSN 
from question1) her position (Dept. 20 manager)
a. First try to update her record in the department table
b. Update your record to be department 20 manager.
c. Update your friend data (entered in question2) to be in your teamwork 
(supervised by you)
*/
--UPDATE Employee set Dno=100 WHERE SSN=968574;
--UPDATE Departments set MGRSSN=968574 WHERE Dnum=100;
--UPDATE Employee set Dno=20 WHERE SSN=102672;
--UPDATE Departments set MGRSSN=102672 WHERE Dnum=20;
--UPDATE Employee set Superssn=102672 WHERE SSN=102660;

/*5. Unfortunately, the company ended the contract with Mr. Kamel Mohamed 
(SSN=223344) so try to delete his data from your database in case you know that 
your friend will be temporarily in his position.
Hint: (Check if Mr. Kamel has dependents, works as a department manager, 
supervises any employees or works in any projects and handle these cases)
*/
UPDATE Employee set Dno=10, Superssn = 321654 WHERE SSN=102660;
UPDATE Employee set Superssn = 102660 WHERE Superssn=223344;
UPDATE Departments set MGRSSN=102660, [MGRStart Date]='10/10/2025' WHERE MGRSSN=223344;
DELETE FROM Works_for WHERE ESSN=223344;
DELETE FROM Dependent WHERE ESSN=223344;
DELETE FROM Employee WHERE SSN=223344;


/*6. And your salary has been upgraded by 20 percent of its last value.*/
UPDATE Employee set Salary=Salary*1.2 WHERE SSN=102672
select * from Employee;
select * from Departments;