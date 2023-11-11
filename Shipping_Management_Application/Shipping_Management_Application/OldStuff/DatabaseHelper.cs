/**using Microsoft.Data.Sqlite;

namespace Shipping_Management_Application.Data
{
    public class DatabaseHelper
    {
        private static string _dbFilePath = @".\Data\database.db";
        private static string _connectionString = $"Data Source={_dbFilePath};Version=3;";

        public void InitializeDatabase()
        {
            try
            {
                if (!File.Exists(_dbFilePath))
                {
                    File.Create(_dbFilePath).Close();  // Create an empty file

                    using (var connection = new SqliteConnection(_connectionString))
                    {
                        connection.Open();
                        string createAdminsTableQuery = @"
                            CREATE TABLE IF NOT EXISTS admin (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            userName TEXT NOT NULL,
                            password TEXT NOT NULL
                            );";
                        using (var command = new SqliteCommand(createAdminsTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
**/