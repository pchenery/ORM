using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppORM.Models
{
    public class PensionFund
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal AmountContributed { get; set; }
        public int ProviderId { get; set; }
        public DateTime LastContributionDate { get; set; }
    }
}
