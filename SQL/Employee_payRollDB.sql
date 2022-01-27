--UC1
create database payroll_services;
use payroll_services;

--UC2
create table employee_payroll
(id int identity (1,1) primary key,
 Name varchar(150),
 Salary float,
 Startdate date);

 --UC3
 insert into employee_payroll values
( 'Maynak', 10000.00, '2016-03-08'),
( 'Myra', 70000.00, '2020-12-07'),
( 'Harsh',30000.00, '2018-04-03'),
( 'Shruti', select * from employee_payroll50000.00, '2019-12-18');

--UC4
select * from employee_payroll

--UC5
select Salary from employee_payroll WHERE name  = 'Harsh'

select * from employee_payroll where Startdate Between CAST ('2018-04-03' AS Date) and GETDATE();

--UC6
ALTER TABLE employee_payroll ADD gender CHAR(1);

update employee_payroll set gender = 'M' where name='Maynak';
update employee_payroll set gender = 'F' where name='Myra';
update employee_payroll set gender = 'M' where name='Harsh';
update employee_payroll set gender = 'F' where name='Shruti';
select * from employee_payroll


--UC7
select sum(salary) as sumsalary from employee_payroll where gender ='F' group by gender;
select avg(salary) as avgsalary from employee_payroll where gender ='F' group by gender;
select min(salary) as minsalary from employee_payroll where gender ='M' group by gender;
select max(salary) as maxsalary from employee_payroll where gender ='M' group by gender;
select count(salary) as countsalary from employee_payroll where  gender ='F' group by gender;


--UC8
alter table employee_payroll add phoneNo bigint, 
                                 department varchar(50) not null default 'sales', 
								 officeAddress varchar(50) default 'Delhi';
	
update employee_payroll set officeAddress = 'Delhi' where name = 'Shruti';
insert into employee_payroll (name, salary, Startdate, gender, phoneNo, department)
values ('sanket', 2500000, '2019-09-05', 'M', 9123423427, 'HR');
select * from employee_payroll


--UC9
alter table employee_payroll add Basic_Pay float, deductions float, taxable_pay float, income_tax float, net_pay float;

--UC10
insert into employee_payroll(name, Salary, Startdate, gender , phoneNo, department,officeaddress,Basic_Pay, deductions, taxable_pay, income_tax, net_pay)
values( 'Mukesh', 20000.00, '2020-12-07','M','7645640900','IT','Mumbai','8000','1000','800','800','20000');

select * from employee_payroll;

--UC11
use payroll_services;
create table Department
( id int identity (1,1) primary key, 
DepartmentName varchar(50) not null);

select * from Department;

Alter table employee_payroll ADD dept_id int foreign key references Department(id);

----UC12-----------
insert into Department(DepartmentName)values
	('HR'), 
	('Sales'), 
	('Research'),
	('HR');
Select * from Department;


select e.id,e.Name,e.Salary,d.DepartmentName from employee_payroll e inner join Department d ON  e.id=d.id;
