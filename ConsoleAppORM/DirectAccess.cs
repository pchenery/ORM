using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleAppORM
{
    public class DirectAccess
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee;Integrated Security=True";

        public IEnumerable<string> GetFinancialDataForAllEmployees()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(@"SELECT e.FirstName + ' ' + e.LastName AS EmployeeName,
                                            jp.Title,
                                            CAST(salary AS VARCHAR) AS Salary,
                                            CAST(p.AmountContributed AS VARCHAR) AS FundSize
                                            FROM Employee e
                                            JOIN PensionFund p
                                            ON e.Id = p.EmployeeId
                                            JOIN JobPosition jp
                                            ON p.ProviderId = jp.Id", connection);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return reader.GetString(0);
                }

                reader.Close();
            }
        }
    }
}
