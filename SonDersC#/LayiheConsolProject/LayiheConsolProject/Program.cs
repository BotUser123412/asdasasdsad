using System;
using System.Collections.Generic;
using System.Linq;

namespace LayiheConsolProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager hrm = new HumanResourceManager();

            string opr;

            do
            {
                Console.WriteLine("1.Sistemdeki iscilerin siyahisini goster");
                Console.WriteLine("2.Departamentdeki iscilerin siyahisini gostermek");
                Console.WriteLine("3.Sistemde isci elave et");
                Console.WriteLine("4.Isci melumatlarini deyiwdirmek ");
                Console.WriteLine("5.Iscinin sistemden silinmesi");
                Console.WriteLine("6.Isciler uzre axtaris et");
                Console.WriteLine("7.Daxil edilmiw tarix araliginda ise baslayan iscilerin siyahisina baxmaq");
                Console.WriteLine("8.Iscilerin Maas ortalamasina baxmaq");
                Console.WriteLine("0. Sistemden cixiw");
                opr = Console.ReadLine();
                switch (opr)
                {
                    case "1":

                        foreach (var item in hrm.Employees)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case "2":
                        Console.WriteLine("Department : ");
                        foreach (var item in Enum.GetValues(typeof(EmployeeDepartment)))
                            Console.WriteLine($"{(byte)item}-{item}");

                        string typeStr = Console.ReadLine();
                        byte typeByte = Convert.ToByte(typeStr);
                        EmployeeDepartment type = (EmployeeDepartment)typeByte;

                        foreach (var item in hrm.Employees)
                        {
                            if (item.Department == type)
                            {
                                Console.WriteLine(type);
                            }
                        }
                        break;

                    case "3":


                        Console.WriteLine("FullName daxil edin : ");
                        string fullname;
                        do
                        {
                            fullname = Console.ReadLine();


                        } while (!MakeFullname(fullname));
                        Console.WriteLine("Position daxil edin :  ");
                        string position;
                        do
                        {
                            position = Console.ReadLine();

                        } while (!MakePosition(position));
                        Console.WriteLine("Startdate daxil edin : ");
                        DateTime startdate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Department : ");
                        foreach (var item in Enum.GetValues(typeof(EmployeeDepartment)))
                            Console.WriteLine($"{(byte)item}-{item}");

                        string typeStr1 = Console.ReadLine();
                        byte typeByte1 = Convert.ToByte(typeStr1);
                        EmployeeDepartment department = (EmployeeDepartment)typeByte1;
                        Console.WriteLine("Salary daxil edin");
                        int salary;
                        do
                        {
                            salary = Convert.ToInt32(Console.ReadLine());

                        } while (!MakeSalary(salary));

                        Employee employee = new Employee(department)
                        {

                            Salary = salary,
                            StartDate = startdate,
                            FullName = fullname,
                            Position = position,

                        };

                        hrm.AddEmployee(employee);
                        break;
                    case "4":
                        static void EditEmployee(string no, int salary, string position)
                        {

                            foreach (var item in hrm.Employees)
                            {


                                if (item.No == no)
                                {
                                    item.Salary = salary;
                                    item.Position = position;

                                }
                            }
                        }
                        break;
                    case "5":
                        bool trueorfalse = false;
                        do
                        {
                            Console.WriteLine("Silmek istediyiniz Emploee daxil edin");
                            string No = Console.ReadLine();
                            var emploee = hrm.Employees.FirstOrDefault(x => x.No == No);
                            if (emploee is null)
                            {
                                trueorfalse = false;
                                Console.WriteLine("Bu nomrede emploee yoxdur");


                            }
                            else
                            {
                                trueorfalse = true;
                                string responseMessage = $"Removed {emploee.FullName}";
                                responseMessage = hrm.Employees.Remove(emploee) ? responseMessage : "Isci sistemden siline bilmedi";
                                Console.WriteLine(responseMessage);


                            }

                        } while (!trueorfalse);



                        break;

                }







            } while (opr != "0");


        }
        static bool MakeFullname(string fullname)
        {
            if (string.IsNullOrWhiteSpace(fullname))
            {

                return false;
            }
            var result = fullname.Split(' ');
            List<string> names = new List<string>();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != "")
                {
                    names.Add(result[i]);

                }

            }
            if (names.Count != 2)
            {
                return false;
            }
            if (!char.IsUpper(names[0][0]) && !char.IsUpper(names[1][0]))
            {

                return false;
            }
            for (int i = 1; i < names[0].Length; i++)
            {
                if (!char.IsLower(names[0][i]))
                {
                    return false;
                }

            }
            for (int i = 1; i < names[1].Length; i++)
            {
                if (!char.IsLower(names[1][i]))
                {
                    return false;
                }

            }
            return true;


        }
        static bool MakePosition(string position)
        {
            if (string.IsNullOrWhiteSpace(position))
            {
                return false;

            }
            for (int i = 0; i < position.Length; i++)
            {

                if (!char.IsUpper(position[0]))
                {
                    return false;

                }
            }
            for (int i = 1; i < position.Length; i++)
            {

                if (!char.IsLower(position[i]))
                {

                    return false;
                }
            }
            for (int i = 0; i < position.Length; i++)
            {

                if (!char.IsLetter(position[i]))
                {
                    return false;
                }
            }
            return true;

        }
        static bool MakeSalary(int salary)
        {
            if (salary! > 500)
            {
                return false;

            }
            return true;


        }
    
    }
}
