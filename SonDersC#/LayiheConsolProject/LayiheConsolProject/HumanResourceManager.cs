using System;
using System.Collections.Generic;
using System.Text;

namespace LayiheConsolProject
{
    internal class HumanResourceManager: IHumanResourceManager
    {
        List<Employee> _employees = new List<Employee>();
        public List<Employee> Employees { get { return _employees; } }
        static int PersoncountforDepartment = 10;
        private int Itpersoncount => GetPerDepartamentCount(x => x.Department == EmployeeDepartment.It);
        private int Maliyyepersoncount => GetPerDepartamentCount(x => x.Department == EmployeeDepartment.Maliyye);
        private int Idareetmepersoncount => GetPerDepartamentCount(x => x.Department == EmployeeDepartment.Idareetme);
        public void AddEmployee(Employee employee)
        {


            if (employee.Department == EmployeeDepartment.It)
            {
                if (Itpersoncount <= PersoncountforDepartment)
                {
                    _employees.Add(employee);

                }


            }
            else if (employee.Department == EmployeeDepartment.Maliyye)
            {
                if (Maliyyepersoncount <= PersoncountforDepartment)
                {
                    _employees.Add(employee);
                }

            }
            else
            {

                if (Idareetmepersoncount <= PersoncountforDepartment)
                {
                    _employees.Add(employee);
                }
            }







        }
        private int GetPerDepartamentCount(Predicate<Employee> predicate)
        {

            int count = 0;
            foreach (var item in _employees)
            {
                if (predicate(item))
                {
                    count++;
                }

            }
            return count;


        }







        public void RemoveEmploye(string no)
        {
            foreach (var item in _employees)
            {

                if (item.No == no)
                {

                    _employees.Remove(item);
                }
            }

        }
        public void EditEmployee(string no, int salary, string position)
        {

            foreach (var item in _employees)
            {


                if (item.No == no)
                {
                    item.Salary = salary;
                    item.Position = position;

                }
            }
        }
        public List<Employee> Search(string value)
        {
            List<Employee> list = new List<Employee>();

            foreach (var item in _employees)
            {
                if (item.FullName.Contains(value))
                {
                    list.Add(item);
                }

            }
            return list;


        }




        public void ShowEmployee()
        {
            foreach (var item in _employees)
            {

                Console.WriteLine(item);
            }

        }


    }
}
