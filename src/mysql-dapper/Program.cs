using System;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;

namespace mysql_dapper
{
    class Program
    {
        const string mysql_password = "my-secret-pw";

        static async Task Main(string[] args)
        {
            using (var connection = new MySqlConnection($"Server=172.17.0.2;User ID=root;Password={mysql_password};Database=mysql"))
            {
                var date = await connection.QueryFirstAsync<MySqlDatabaseTime>("SELECT UTC_TIMESTAMP() AS UtcNow, NOW()+1 AS Now;");
                Console.WriteLine($"{date.Now} - {date.UtcNow}");
            }
        }
    }

    public class MySqlDatabaseTime
    {
        public long Now { get; set; }
        public DateTimeOffset UtcNow { get; set; }
    }
}
