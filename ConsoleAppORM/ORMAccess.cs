using System.Collections.Generic;
using System.Data.SqlClient;
using ConsoleAppORM.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Mapper;
using System.Data;

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

        public IEnumerable<Financial> GetFinancialDataForAllEmployees()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Financial>(
                    @"SELECT e.FirstName,
                        e.LastName,
                        jp.Title AS JobTitle,
                        e.Salary,
                        p.AmountContributed AS PensionFundTotal
                        FROM Employee e
                        JOIN PensionFund p
                        ON e.Id = p.EmployeeId
                        JOIN JobPosition jp
                        ON e.JobPositionId = jp.Id");
            }
        }

        public IEnumerable<Employee> GetEmployeeNoSql()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.GetAll<Employee>();
            }
        }

        public void IncreasePensionContributions()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("sp_AddPensionContribution", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
