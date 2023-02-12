using System;
using System.Collections.Generic;
using System.Text;

namespace LayiheConsolProject
{
    internal interface IHumanResourceManager
    {
        public abstract void AddEmployee(Employee employee);
        public abstract void RemoveEmploye(string no);
        public abstract void EditEmployee(string no, int salary, string position);
        public abstract List<Employee> Search(string value);
    }
}
