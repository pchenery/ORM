using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleAppORM
{
    public class DirectAccess
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee;Integrated Security=True";

        public IEnumerable<string> GetAllEmployees()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT FirstName FROM Employee", connection);

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
