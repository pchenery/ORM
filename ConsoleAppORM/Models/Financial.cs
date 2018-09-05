using System;
using Dapper.Contrib.Extensions;

namespace ConsoleAppORM.Models
{
    public class Financial
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string JobTitle { get; set; }
        public decimal PensionFundTotal { get; set; }

    }
}
