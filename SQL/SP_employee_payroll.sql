--create procedure
use payroll_services
create procedure sp_AddPayRoleServices
(
 @Name varchar (150),
 @Salary float,
 @Startdate Date,
 @gender char(1),
 @phoneNo bigint,
 @department varchar (50),
 @officeAddress varchar (50),
 @Basic_Pay float,
 @deductions float,
 @taxable_pay float,
 @income_tax float,
 @net_pay float,
 @dept_id int
)
as 
begin TRY 
  Insert into employee_payroll values( @Name, @Salary, @Startdate, @gender, @phoneNo, @department, @officeAddress, @Basic_Pay, @deductions,@taxable_pay, @income_tax ,@net_pay , @dept_id)
End TRY
BEGIN CATCH
SELECT
ERROR_NUMBER() AS ERRORNumber,
ERROR_STATE() AS ERRORState,
ERROR_PROCEDURE() AS ERRORProcedure,
ERROR_LINE() AS ERRORLine,
ERROR_MESSAGE() AS ERRORMessage;
END CATCH




-----delete------------
create procedure DeletePayRoleService
(
 @id int
)
as 
begin TRY 
delete from employee_payroll where id = @id
End TRY
BEGIN CATCH
SELECT
ERROR_NUMBER() AS ERRORNumber,
ERROR_STATE() AS ERRORState,
ERROR_PROCEDURE() AS ERRORProcedure,
ERROR_LINE() AS ERRORLine,
ERROR_MESSAGE() AS ERRORMessage;
END CATCH

select * from employee_payroll

exec DeletePayRoleService 1

------------------------------------------
create procedure GetPayRoleService
(
@id int
)
as 
begin TRY 
select * from employee_payroll
End TRY
BEGIN CATCH
SELECT
ERROR_NUMBER() AS ERRORNumber,
ERROR_STATE() AS ERRORState,
ERROR_PROCEDURE() AS ERRORProcedure,
ERROR_LINE() AS ERRORLine,
ERROR_MESSAGE() AS ERRORMessage;
END CATCH

exec GetPayRoleService 1

------update--------
 create procedure UpdatePayRoleServices
(
@Name varchar (150),
 @Salary float
)
as 
begin TRY 
Update employee_payroll set Name = @Name, Salary=@Salary where id = '@id'
 End TRY
BEGIN CATCH
SELECT
ERROR_NUMBER() AS ERRORNumber,
ERROR_STATE() AS ERRORState,
ERROR_PROCEDURE() AS ERRORProcedure,
ERROR_LINE() AS ERRORLine,
ERROR_MESSAGE() AS ERRORMessage;
END CATCH