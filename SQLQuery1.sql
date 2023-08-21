USE master
GO

CREATE DATABASE CompanyFdm;
GO

CREATE TABLE [CompanyFdm].[dbo].departments
(
dept_no INT IDENTITY(1,1) PRIMARY KEY not null,
emp_dept_name VARCHAR(20) not null
)
GO

CREATE TABLE [CompanyFdm].[dbo].employees
(emp_id INT IDENTITY(1,1) PRIMARY KEY not null,
emp_first_name VARCHAR(20) null,
emp_last_name VARCHAR(20) not null,
fk_dept_no INT not null,
FOREIGN KEY (fk_dept_no) REFERENCES departments(dept_no)
)
GO

--DROP TABLE IF EXISTS [DbNba].[dbo].players
--GO

USE EmpDept
GO

INSERT INTO [CompanyFdm].[dbo].departments (emp_dept_name) VALUES ('Academy');
INSERT INTO [CompanyFdm].[dbo].departments (emp_dept_name) VALUES ('Sales');
INSERT INTO [CompanyFdm].[dbo].departments (emp_dept_name) VALUES ('Temporary');


INSERT INTO [CompanyFdm].[dbo].employees (emp_first_name, emp_last_name, fk_dept_no) VALUES ('John', 'Doe', 1);
INSERT INTO [CompanyFdm].[dbo].employees (emp_first_name, emp_last_name, fk_dept_no) VALUES ('Jane', 'Smith', 2);
INSERT INTO [CompanyFdm].[dbo].employees (emp_first_name, emp_last_name, fk_dept_no) VALUES ('Joe', 'Bloggs', 1);
INSERT INTO [CompanyFdm].[dbo].employees (emp_first_name, emp_last_name, fk_dept_no) VALUES ('Joe', 'Schmoe', 3);

GO

-- to run departments
Select * from [CompanyFdm].[dbo].departments;
GO

-- to run employees
Select * from [CompanyFdm].[dbo].employees;
GO

Delete from [CompanyFdm].[dbo].employees where emp_first_name = 'Goku'
GO

Delete from [CompanyFdm].[dbo].departments where emp_dept_name = 'Law'
GO

--Rollback
--GO

