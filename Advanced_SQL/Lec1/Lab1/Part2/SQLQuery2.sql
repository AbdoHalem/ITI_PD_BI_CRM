--1.Display the SalesOrderID, ShipDate of the SalesOrderHeader
--table (Sales schema) to show SalesOrders that occurred within the period ‘7/28/2002’ and ‘7/29/2014’
select SalesOrderID, ShipDate from Sales.SalesOrderHeader
WHERE OrderDate BETWEEN '7/28/2002' AND '7/29/2014';

--2.Display only Products(Production schema) with a StandardCost below $110.00 (show ProductID, Name only)
select p.ProductID, p.Name from Production.Product p
where p.StandardCost < 110;

--3.Display ProductID, Name if its weight is unknown
select p.ProductID, p.Name from Production.Product p
where  p.Weight IS NULL;

--4.Display all Products with a Silver, Black, or Red Color
select * from Production.Product p where p.Color in ('Silver', 'Black', 'Red');

--5.Display any Product with a Name starting with the letter B
select * from Production.Product p where p.Name like 'B%';

--6.Run the following Query
--UPDATE Production.ProductDescription
--SET Description = 'Chromoly steel_High of defects'
--WHERE ProductDescriptionID = 3
--Then write a query that displays any Product description with underscore value in its description.
UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3

select Description from Production.ProductDescription
where Description like '%[_]%';

--7.Calculate sum of TotalDue for each OrderDate in Sales.SalesOrderHeader table
--for the period between  '7/1/2001' and '7/31/2014'
select OrderDate, SUM(TotalDue) as [Sum of TotalDue] from Sales.SalesOrderHeader
where OrderDate BETWEEN '7/1/2001' and '7/31/2014'
group by OrderDate;

--8.Display the Employees HireDate (note no repeated values are allowed)
select DISTINCT HireDate from HumanResources.Employee;

--9. Calculate the average of the unique ListPrices in the Product table
select AVG(DISTINCT ListPrice) from Production.Product;

--10.Display the Product Name and its ListPrice within the values of 100 and 120 
--the list should has the following format "The [product name] is only! [List price]"
--(the list will be sorted according to its ListPrice value)
select  CONCAT('The ', p.Name, ' is only! ', p.ListPrice) AS ProductDescription
FROM Production.Product p
where p.ListPrice BETWEEN 100 AND 120
ORDER by p.ListPrice;

--11)
--a) Transfer the rowguid ,Name, SalesPersonID, Demographics from Sales.Store table
--in a newly created table named [store_Archive]
SELECT rowguid, Name, SalesPersonID, Demographics
INTO Sales.store_Archive FROM Sales.Store;
--Note: Check your database to see the new table and how many rows in it?
SELECT COUNT(*) FROM Sales.store_Archive;
--b)Try the previous query but without transferring the data?
SELECT rowguid, Name, SalesPersonID, Demographics
INTO Sales.store_Archive_Empty FROM Sales.Store
WHERE 1 = 0;	-- False Condition
SELECT COUNT(*) FROM Sales.store_Archive_Empty;

--12.Using union statement, retrieve the today’s date in different styles using convert or format funtion.
-- 101 = US Style (mm/dd/yyyy)
SELECT CONVERT(varchar, GETDATE(), 101) AS Date_Styles
UNION
-- 103 = British/Egypt Style (dd/mm/yyyy)
SELECT CONVERT(varchar, GETDATE(), 103)
UNION
-- 111 = Japan Style (yyyy/mm/dd)
SELECT CONVERT(varchar, GETDATE(), 111)
UNION
-- Using FORMAT function (dd-MM-yyyy)
SELECT FORMAT(GETDATE(), 'dd-MM-yyyy');