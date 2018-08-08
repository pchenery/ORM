using Dapper.Contrib.Extensions;

namespace ConsoleAppORM.Models
{
    public class JobPosition
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
