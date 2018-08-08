using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppORM.Models;

namespace ConsoleAppORM
{
    class Program
    {
        static void Main(string[] args) 
        {
            GetEmployeesDirect();
            GetEmployeesORM();
            Console.ReadLine();
        }

        private static void GetEmployeesDirect()
        {
            var directAccess = new DirectAccess();

            Console.WriteLine("Employees");
            Console.WriteLine("---------");

            foreach (string employee in directAccess.GetAllEmployees())
            {
                Console.WriteLine(employee);
            }
        }

        private static void GetEmployeesORM()
        {
            var ormAccess = new ORMAccess();
            Console.WriteLine();
            Console.WriteLine("Employees");
            Console.WriteLine("---------");

            foreach (Employee employee in ormAccess.GetAllEmployees())
            {
                Console.WriteLine($"{employee.Id}: {employee.FirstName}, {employee.LastName}, {employee.Salary}");
            }
        }
    }
}
