using System;
using System.Collections.Generic;
using System.Text;

namespace LayiheConsolProject
{
    internal class Employee
    {
        static int Totalcount = 1000;
        public string No { get { return _no; } }

        private string _no;
        public string FullName;
        public string Position;
        public int Salary;
        public DateTime StartDate;
        public EmployeeDepartment  Department;


        public Employee(EmployeeDepartment dpt)
        {
            this.Department = dpt;
            if (Department == EmployeeDepartment.It)
            {
                _no = "IT" + Totalcount++;
            }
            else if (Department == EmployeeDepartment.Idareetme)
            {
                _no = "ID" + Totalcount++;
            }
            else
            {
                _no = "MA" + Totalcount++;
            }

        }






        public override string ToString()
        {
            return $"No : {No} -- FullName : {FullName} -- Department : {Department} -- Salary : {Salary} -- Position : {Position} -- Startddate : {StartDate.ToString("dd-MM-yyyy")}";


        }
    }
}
