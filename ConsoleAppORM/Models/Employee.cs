using System;
using Dapper.Contrib.Extensions;

namespace ConsoleAppORM.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
        public JobPosition JobPosition { get; set; }

    }
}
