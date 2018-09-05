using System;
using ConsoleAppORM.Models;

namespace ConsoleAppORM
{
    class Program
    {
        static void Main(string[] args) 
        {
            GetEmployeesORM();
            //GetEmployeesNoSQL();
            IncreasePensionContributions();

            Console.ReadLine();
        }

        private static void GetEmployeesORM()
        {
            var ormAccess = new ORMAccess();
            Console.WriteLine(); 
            Console.WriteLine("FirstName, LastName, Job Role, Salary, PensionFundBalance");
            Console.WriteLine("---------------------------------------------------------");

            foreach (Financial emp in ormAccess.GetFinancialDataForAllEmployees())
            {
                Console.WriteLine($"{emp.FirstName + ' ' + emp.LastName}, {emp.JobTitle}, {emp.Salary}, {emp.PensionFundTotal}");
            }
        }

        private static void IncreasePensionContributions()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to increase Employees Pension Funds by 5% of salary?");
            var answer = Console.ReadLine();

            if (answer != null && answer.ToUpper().Equals("Y"))
            {
                var ormAccess = new ORMAccess();
                ormAccess.IncreasePensionContributions();
                Console.WriteLine("Updated!");
            }
        }

        private static void GetEmployeesNoSQL()
        {
            var ormAccess = new ORMAccess();
            Console.WriteLine();
            Console.WriteLine("EmployeesNoSQL");
            Console.WriteLine("---------");

            foreach (Employee employee in ormAccess.GetEmployeeNoSql())
            {
                Console.WriteLine($"{employee.Id}: {employee.FirstName}, {employee.LastName}, {employee.Salary}");
            }
        }
    }
}
