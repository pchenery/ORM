using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace ConsoleAppORM.Models
{
    public class PensionFund
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal AmountContributed { get; set; }
        public int ProviderId { get; set; }
        public DateTime LastContributionDate { get; set; }
    }
}
