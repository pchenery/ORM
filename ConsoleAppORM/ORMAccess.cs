using System.Collections.Generic;
using System.Data.SqlClient;
using ConsoleAppORM.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Mapper;

namespace ConsoleAppORM
{
    public class ORMAccess
    {
        private readonly string connectionString =
            new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                IntegratedSecurity = true,
                InitialCatalog = "Employee"
            }.ConnectionString;

        public IEnumerable<Employee> GetAllEmployees()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Employee>("SELECT * FROM Employee");
                //return connection.Query<Employee, JobPosition>("SELECT * FROM Employee JOIN JobPosition ON Employee.JobPositionId = JobPosition.Id");
            }
        }
    }
}
