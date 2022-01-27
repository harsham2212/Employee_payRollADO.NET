using System;

namespace Employee_payRoll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wecome to Employee PayRoll Problem using Ado.Net!");
            bool flag = true;
            EmployeeDBconnectivity employeeConfig = new EmployeeDBconnectivity();
            EmployeeInfo data = new EmployeeInfo();
            while (flag)
            {
                Console.WriteLine("Enter your Choice Number to Execute the Program Press. \n 1.Add\n 2.Delete by ID \n 3.Update Employee\n 4.View\n 5-Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    // It Will Add Data to the Table
                    case 1:
                        EmployeeInfo obj = new EmployeeInfo();
                        obj.Name = "Tanya";
                        obj.Salary = 20000.00;
                        obj.Startdate = DateTime.Now;
                        obj.gender = 'F';
                        obj.phoneNo = 9124234334;
                        obj.department = "Account";
                        obj.officeAddress = "kanpur";
                        obj.Basic_Pay = 5000.00;
                        obj.deductions = 1000.00;
                        obj.taxable_pay = 300.00;
                        obj.income_tax = 400.00;
                        obj.net_pay = 25000;
                        obj.dept_id = 3;
                        var result = employeeConfig.AddEmployee(obj);
                        if (result != null)
                        {
                            Console.WriteLine("Data Added Successfully!!");
                        }
                        else
                        {
                            Console.WriteLine("Data not Added!!");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter id to Delete Data:");
                        int num = Convert.ToInt32(Console.ReadLine());
                        employeeConfig.DeleteEmployee(num);
                        Console.WriteLine("Data deleted successfully!!");
                        break;
                    case 3:
                        Console.WriteLine("Enter Id of employee whoes data want to edit:");
                        int employeeid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new name:");
                        string newname = Console.ReadLine();
                        Console.WriteLine("Enter new salary:");
                        string newsalry = Console.ReadLine();
                        bool res = employeeConfig.UpdateEmployee(employeeid, newname, newsalry);
                        if (res != null)
                        {
                            Console.WriteLine("Successfully Added!!");
                        }
                        else
                        {
                            Console.WriteLine("Not Added!!");
                        }
                        break;
                    case 4:
                        employeeConfig.GetAllEmployees();
                        //Console.WriteLine("Enter ID to get Data:");
                        break;
                    case 5:
                        flag = false;
                        break;
                }
            }
        }
    }
}