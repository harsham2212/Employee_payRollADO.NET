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
        //To Delete Employee details    
        public int DeleteEmployee(int id)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("DeletePayRoleService", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {

                    return id;

                }
                else
                {

                    return 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //To Update Employee details 
        public bool UpdateEmployee(int id, string Name, string Salary)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("UpdatePayRoleServices", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@Name", Name);
                com.Parameters.AddWithValue("@Salary", Salary);

                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //To Get Employee details 
        public DataSet GetAllEmployees()
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("GetPayRoleService", con);
                com.CommandType = CommandType.StoredProcedure;
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("GetPayRoleService", this.con);
                adapter.Fill(dataSet, "employee_payroll");
                //con.Open();
                foreach (DataRow dR in dataSet.Tables["employee_payroll"].Rows)
                {
                    Console.WriteLine("\t" + dR["id"] + "  " + dR["Name"] + " " + dR["Salary"] + " " + dR["gender"] + " " + dR["phoneNo"] + " " + dR["department"] + " " + dR["officeAddress"] + " " + dR["Basic_Pay"] + " " + dR["deductions"] + " " + dR["taxable_pay"] + " " + dR["income_tax"] + " " + dR["net_pay"] + " " + dR["dept_id"]);
                }
                con.Close();
                return dataSet;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Display()
        {
            foreach (var item in EmpList)
            {
                Console.WriteLine("\nName\tBasic_Pay\tDate\tgender\n");
                Console.WriteLine(item.Name + "\t" + item.Basic_Pay + "\t" + item.Startdate + "\t" + item.gender);
            }
        }
    }
 }
