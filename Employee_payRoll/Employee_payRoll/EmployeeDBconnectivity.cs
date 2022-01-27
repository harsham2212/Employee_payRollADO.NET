using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Employee_payRoll
{
    public class EmployeeDBconnectivity
    {
            public List<EmployeeInfo> EmpList = new List<EmployeeInfo>();
            public SqlConnection con;
            public void Connection()
            {               
            string connectionString = @"Data Source=FRIDAY\BARCA;Initial Catalog=payroll_services;Integrated Security=True";

            con = new SqlConnection(connectionString);
            }
            public EmployeeInfo AddEmployee(EmployeeInfo obj)
            {
                try
                {
                    Connection();
                    SqlCommand com = new SqlCommand("sp_AddPayRoleServices", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", obj.Name);
                com.Parameters.AddWithValue("@Salary", obj.Salary);
                com.Parameters.AddWithValue("@gender", obj.gender);
                com.Parameters.AddWithValue("@Startdate", obj.Startdate);
                com.Parameters.AddWithValue("@phoneNo", obj.phoneNo);
                com.Parameters.AddWithValue("@department", obj.department);
                com.Parameters.AddWithValue("@officeaddress", obj.officeAddress);
                com.Parameters.AddWithValue("@Basic_Pay", obj.Basic_Pay);
                com.Parameters.AddWithValue("@deductions", obj.deductions);
                com.Parameters.AddWithValue("@taxable_pay", obj.taxable_pay);
                com.Parameters.AddWithValue("@income_tax", obj.income_tax);
                com.Parameters.AddWithValue("@net_pay", obj.net_pay);
                com.Parameters.AddWithValue("@dept_id", obj.dept_id);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();


                return obj;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
 }
