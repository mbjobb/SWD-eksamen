using Microsoft.Data.Sqlite;
using Shipping_Management_Application.BuisnessLogic.User;

namespace Shipping_Management_Application.Data

{

    public class DatabaseHandler
    {
        private readonly DbConfig _dbConfig;
        private SqliteConnection _connection;


        public DatabaseHandler(DbConfig dbConfig)
        {
            _dbConfig = dbConfig;
            _connection = new SqliteConnection(GetConnectionString());
        }

        private string GetConnectionString()
        {
            return new SqliteConnectionStringBuilder { DataSource = _dbConfig.DatabasePath }.ConnectionString;
        }

        public void OpenConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        public void CreateTables()
        {
            OpenConnection();

            try
            { 
            string userTable = @"CREATE TABLE IF NOT EXISTS User (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                        Username TEXT, 
                                        Password TEXT )";

            //string orderTable = @"CREATE TABLE IF NOT EXISTS Orders (
            //                            Id INTEGER PRIMARY KEY AUTOINCREMENT, 
            //                            UserId INTEGER, 
            //                            Details TEXT, 
            //                            Weight REAL, 
            //                            DeliveryMethod TEXT, 
            //                            Price REAL, 
            //                            FOREIGN KEY(UserId) REFERENCES Users(Id))";
           
            using (var command = new SqliteCommand(userTable, _connection))
            {
                command.ExecuteNonQuery();
            }

            }
            finally
            {
            CloseConnection();
                
            }


        }
        
         
        public void CreateAdmin(Admin user)
        {
            using (var connection = new SqliteConnection(GetConnectionString()))
            {

                string query = "SELECT COUNT(1) FROM User WHERE UserName = @UserName";
                SqliteCommand command = new SqliteCommand(@query, connection);
                command.Parameters.AddWithValue("@UserName", user);
                try
                {
                connection.Open();
                    int count = (int)command.ExecuteScalar();
                    if (count > 0) { Console.WriteLine("it lives!"); } else { Console.WriteLine("it does not live =("); }

                }catch (Exception ex) { Console.WriteLine("error and stuff" + ex.Message); }


                //string query = "INSERT INTO User ( UserName, Password) " + "VALUES (@UserName, @Password)";

            }

            
        }


        public void AddUser(IUserEntity user)
        {
            using (var connection = new SqliteConnection(GetConnectionString()))
            {
                connection.Open();

                string query = "INSERT INTO User (UserName, Password) " +
                               "VALUES (@UserName, @Password, )";

                using (var command = new SqliteCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    //command.Parameters.AddWithValue("@LastName", user.LastName);
                    //command.Parameters.AddWithValue("@Email", user.Email);
                    //command.Parameters.AddWithValue("@Country", user.Country);
                    //command.Parameters.AddWithValue("@Region", user.Region);
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    //command.Parameters.AddWithValue("@CreditBalance", user.CreditBalance);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        //public IUserEntity GetUser(string username)
        //{
        //    IUserEntity user = null;

        //    using (var connection = new SqliteConnection(GetConnectionString()))
        //    {
        //        connection.Open();

        //        string query = "SELECT * FROM Users WHERE Username = @Username";

        //        using (var command = new SqliteCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@Username", username);

        //            using (var reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    user = new User
        //                    {
        //                        // Assuming these fields exist in your User class
        //                        FirstName = reader["FirstName"].ToString(),
        //                        LastName = reader["LastName"].ToString(),
        //                        Email = reader["Email"].ToString(),
        //                        Country = reader["Country"].ToString(),
        //                        Region = reader["Region"].ToString(),
        //                        Username = reader["Username"].ToString(),
        //                        Password = reader["Password"].ToString(),
        //                        CreditBalance = Convert.ToDouble(reader["CreditBalance"])
        //                    };
        //                }
        //            }
        //        }

        //        connection.Close();
        //    }

        //    return user;
        //}
        // Method to update user credit
        //public bool UpdateCredit(string username, double newCredit)
        //{
        //    using (var connection = new SqliteConnection(GetConnectionString()))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            string query = "UPDATE Users SET CreditBalance = @CreditBalance WHERE Username = @Username";

        //            using (var cmd = new SqliteCommand(query, connection))
        //            {
        //                cmd.Parameters.AddWithValue("@CreditBalance", newCredit);
        //                cmd.Parameters.AddWithValue("@Username", username);

        //                int affectedRows = cmd.ExecuteNonQuery();

        //                if (affectedRows > 0)
        //                {
        //                    // Successfully updated the user's credit
        //                    return true;
        //                }
        //                else
        //                {
        //                    // No rows were updated, which usually means the user was not found
        //                    return false;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Log the exception or handle it as per your application's needs
        //            Console.WriteLine("An error occurred while updating credit: " + ex.Message);
        //            return false;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //}

        public bool UserExists(int userId)
        {
            using (var connection = new SqliteConnection(GetConnectionString()))
            {
                connection.Open();

                string query = "SELECT COUNT(1) FROM Users WHERE Id = @UserId";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    int userCount = Convert.ToInt32(command.ExecuteScalar());
                    return userCount > 0;
                }
            }
        }
        //public void AddOrder(Order order)
        //{
        //    if (!UserExists(order.UserId))
        //    {
        //        throw new Exception("Cannot add order for non-existent user.");
        //    }
        //    try
        //    {
        //        using (var connection = new SqliteConnection(GetConnectionString()))
        //        {
        //            connection.Open();

        //            string query = "INSERT INTO Orders (UserId, Details, Weight, DeliveryMethod, Price) " +
        //                           "VALUES (@UserId, @Details, @Weight, @DeliveryMethod, @Price)";

        //            using (var command = new SqliteCommand(query, connection))
        //            {
        //                command.Parameters.Add(new SqliteParameter("@UserId", order.UserId));
        //                command.Parameters.Add(new SqliteParameter("@Details", order.Details ?? (object)DBNull.Value));
        //                command.Parameters.Add(new SqliteParameter("@Weight", order.Weight));
        //                command.Parameters.Add(new SqliteParameter("@DeliveryMethod", order.DeliveryMethod ?? (object)DBNull.Value));
        //                command.Parameters.Add(new SqliteParameter("@Price", order.Price));

        //                int result = command.ExecuteNonQuery();

        //                if (result <= 0)
        //                {
        //                    throw new Exception("The order was not added to the database.");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred while adding the order: " + ex.Message);
        //        throw;
        //    }
        //}



        //public List<Order> GetAllOrders()
        //{
        //    List<Order> orders = new List<Order>();

        //    using (var connection = new SqliteConnection(GetConnectionString()))
        //    {
        //        connection.Open();

        //        string query = "SELECT * FROM Orders";

        //        //using (var command = new SqliteCommand(query, connection))
        //        //{
        //        //    using (var reader = command.ExecuteReader())
        //        //    {
        //        //        while (reader.Read())
        //        //        {
        //        //            Order order = new Order
        //        //            {
        //        //                // Assuming these fields exist in your Order class
        //        //                UserId = Convert.ToInt32(reader["UserId"]),
        //        //                Details = reader["Details"].ToString(),
        //        //                Weight = Convert.ToDouble(reader["Weight"]),
        //        //                DeliveryMethod = reader["DeliveryMethod"].ToString(),
        //        //                Price = Convert.ToDouble(reader["Price"])
        //        //            };
        //        //            orders.Add(order);
        //        //        }
        //        //    }
        //        //}

        //        connection.Close();
        //    }

        //    return orders;
        //}

        //public List<Order> GetOrdersByUser(int userId)
        //{
        //    List<Order> orders = new List<Order>();

        //    //using (var connection = new SqliteConnection(GetConnectionString()))
        //    //{
        //    //    connection.Open();

        //    //    string query = "SELECT * FROM Orders WHERE UserId = @UserId";

        //    //    using (var command = new SqliteCommand(query, connection))
        //    //    {
        //    //        command.Parameters.AddWithValue("@UserId", userId);

        //    //        using (var reader = command.ExecuteReader())
        //    //        {
        //    //            while (reader.Read())
        //    //            {
        //    //                Order order = new Order
        //    //                {
        //    //                    // Assuming these fields exist in your Order class
        //    //                    UserId = Convert.ToInt32(reader["UserId"]),
        //    //                    Details = reader["Details"].ToString(),
        //    //                    Weight = Convert.ToDouble(reader["Weight"]),
        //    //                    DeliveryMethod = reader["DeliveryMethod"].ToString(),
        //    //                    Price = Convert.ToDouble(reader["Price"])
        //    //                };
        //    //                orders.Add(order);
        //    //            }
        //    //        }
        //    //    }

        //    //    connection.Close();
        //    //}

        //    return orders;
        //}

        //public bool UpdateUserCredit(string username, double newCredit)
        //{
        //    OpenConnection();
        //    using (var transaction = _connection.BeginTransaction())
        //    {
        //        try
        //        {
        //            string query = @"UPDATE Users SET CreditBalance = @CreditBalance WHERE Username = @Username";

        //            using (var command = new SqliteCommand(query, _connection, transaction))
        //            {
        //                command.Parameters.AddWithValue("@CreditBalance", newCredit);
        //                command.Parameters.AddWithValue("@Username", username);

        //                int affectedRows = command.ExecuteNonQuery();
        //                transaction.Commit();

        //                return affectedRows > 0;
        //            }
        //        }
        //        catch
        //        {
        //            transaction.Rollback();
        //            throw;
        //        }
        //        finally
        //        {
        //            CloseConnection();
        //        }
        //    }
        //}


        internal bool UpdateUserCredit(IUserEntity user)
        {
            throw new NotImplementedException();
        }


    }
}


