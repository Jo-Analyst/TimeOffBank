using System;
using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string CPF { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

        public int Save()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = id == 0
                        ? "INSERT INTO Employees (name, CPF, address, phone) VALUES (@name, @CPF, @address, @phone); SELECT @@identity"
                        : "UPDATE Employees SET name = @name, CPF = @CPF, address = @address, phone = @phone WHERE id = @id";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@CPF", CPF);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@phone", phone);
                    if (id == 0)
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                    else
                    {
                        command.ExecuteNonQuery();
                    }
                }

                return 0;
            }
            catch
            {
                throw;
            }
        }

        static public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                string query = "DELETE FROM Employees WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.CommandText = query;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }


        static public DataTable FindById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT * FROM Employees WHERE Employees.id = {id}";
                    var adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.CommandText = query;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByCPF(string CPF)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT * FROM Employees WHERE CPF = '{CPF}'";
                    var adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.CommandText = query;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        }

        static public DataTable FindByCpfForEmployee(string CPF, int id)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT * FROM Employees WHERE CPF = '{CPF}' AND id <> {id}";
                    var adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.CommandText = query;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        }

        static public DataTable FindAll(int page = 0, double quantRows = 5)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT * FROM Employees ORDER BY name OFFSET {page} ROWS FETCH  NEXT {quantRows} ROWS ONLY";
                    var adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.CommandText = query;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        }

        static public DataTable FindByName(string name, int page = 0, double quantRows = 5)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT * FROM Employees WHERE name LIKE '%{name}%' ORDER BY name OFFSET {page} ROWS FETCH  NEXT {quantRows} ROWS ONLY";
                    var adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.CommandText = query;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        }

        public static double CountQuantityEmployees()
        {
            using (var connection = new SqlConnection(DbConnectionString.connectionString))
            {
                connection.Open();
                string query = $"SELECT COUNT(id) FROM Employees";
                var command = new SqlCommand(query, connection);
                command.CommandText = query;

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count;
            }
        }

        public static double CountQuantityEmployeesByName(string name)
        {
            using (var connection = new SqlConnection(DbConnectionString.connectionString))
            {
                connection.Open();
                string query = $"SELECT COUNT(id) FROM Employees WHERE name LIKE '%{name}%'";
                var command = new SqlCommand(query, connection);
                command.CommandText = query;

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count;
            }
        }
    }
}