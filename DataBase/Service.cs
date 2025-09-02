using System;
using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class Service
    {
        public int id { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public DateTime entryTime { get; set; }
        public DateTime departureTime { get; set; }
        public double numberOfOvertimeHours { get; set; }
        public string abatementDate { get; set; }
        public double numberOfHoursTaken { get; set; }
        public bool dayOffCompleted { get; set; }
        public int employeesId { get; set; }

        public void Save()
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                connection.Open();
                string sql = id == 0
                ? $"INSERT INTO Services (description, date, employee_id,  entry_time, departure_time, number_of_overtime_hours, day_off_completed, abatement_date, number_of_hours_taken) VALUES (@description, @date, @employee_id, @entry_time, @departure_time, @number_of_overtime_hours, @day_off_completed, {(string.IsNullOrEmpty(abatementDate) ? "NULL" : "@abatement_date")}, {(string.IsNullOrEmpty(abatementDate) ? "NULL" : "@number_of_hours_taken")}); SELECT @@identity"
                : $"UPDATE Services SET description = @description, date = @date, employee_id = @employee_id, entry_time = @entry_time, departure_time = @departure_time, number_of_overtime_hours = @number_of_overtime_hours, abatement_date = {(string.IsNullOrEmpty(abatementDate) ? "NULL" : "@abatement_date")}, day_off_completed = @day_off_completed, number_of_hours_taken = {(string.IsNullOrEmpty(abatementDate) ? "NULL" : "@number_of_hours_taken")} WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@entry_time", entryTime.ToString("HH:mm:ss"));
                command.Parameters.AddWithValue("@departure_time", departureTime.ToString("HH:mm:ss"));
                command.Parameters.AddWithValue("@number_of_overtime_hours", numberOfOvertimeHours);
                if(!string.IsNullOrEmpty(abatementDate))
                    command.Parameters.AddWithValue("@abatement_date", abatementDate);
                command.Parameters.AddWithValue("@day_off_completed", dayOffCompleted);
                if(!string.IsNullOrEmpty(abatementDate))
                    command.Parameters.AddWithValue("@number_of_hours_taken", numberOfHoursTaken);
                command.Parameters.AddWithValue("@date", date.ToShortDateString());
                command.Parameters.AddWithValue("@employee_id", employeesId);
                command.CommandText = sql;
                try
                {
                    if (id == 0)
                        id = Convert.ToInt32(command.ExecuteScalar());
                    else
                        command.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }

        static public DataTable FindByEmployeeId(int employee_id, int page, double quantRows)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT id, description, CONVERT(VARCHAR, date, 103) AS date, entry_time, departure_time, employee_id, number_of_overtime_hours, CONVERT(VARCHAR, abatement_date, 103) AS abatement_date, day_off_completed, number_of_hours_taken FROM Services WHERE employee_id = {employee_id} ORDER BY CONVERT(DATE, date, 103) DESC, CONVERT(Time, entry_time, 103) DESC OFFSET {page} ROWS FETCH  NEXT {quantRows} ROWS ONLY";
                    var adapter = new SqlDataAdapter(sql, connection);
                    adapter.SelectCommand.CommandText = sql;
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

        static public DataTable FindByYearAndMonth(int year, string month, int page = 1, double quantRows = 1)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT Services.description, CONVERT(VARCHAR, Services.date, 103) AS date, Services.entry_time, Services.departure_time, Services.number_of_overtime_hours, CONVERT(VARCHAR,Services.abatement_date, 103) AS abatement_date, Services.day_off_completed, Services.number_of_hours_taken, Employees.name FROM Services INNER JOIN Employees ON Employees.id = Services.employee_id WHERE CONVERT(VARCHAR, date, 103) LIKE '%{month}/{year}%' ORDER BY CONVERT(DATE, Services.date, 103) DESC, CONVERT(Time, Services.entry_time, 103) DESC OFFSET {page} ROWS FETCH  NEXT {quantRows} ROWS ONLY";
                    var adapter = new SqlDataAdapter(sql, connection);
                    adapter.SelectCommand.CommandText = sql;
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

        static public DataTable FindByYear(int year, int page = 1, double quantRows = 1)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string sql = $"SELECT Services.description, CONVERT(VARCHAR, Services.date, 103) AS date, Services.entry_time, Services.departure_time, Services.number_of_overtime_hours, CONVERT(VARCHAR,Services.abatement_date, 103) AS abatement_date, Services.day_off_completed, Services.number_of_hours_taken, Employees.name FROM Services INNER JOIN Employees ON Employees.id = Services.employee_id WHERE date LIKE '%{year}%' ORDER BY CONVERT(DATE, Services.date, 103) DESC, CONVERT(Time, Services.entry_time, 103) DESC OFFSET {page} ROWS FETCH  NEXT {quantRows} ROWS ONLY";
                    var adapter = new SqlDataAdapter(sql, connection);
                    adapter.SelectCommand.CommandText = sql;
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

        static public int CountQuantityServicesByEmployeeId(int EmployeesId)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    connection.Open();
                    string sql = $"SELECT COUNT(id) AS quantity FROM Services WHERE employee_id = {EmployeesId}";
                    var command = new SqlCommand(sql, connection);
                    command.CommandText = sql;

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch
            {
                throw;
            }
        }

        static public int CountQuantityServicesByYear(string year)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    connection.Open();
                    string sql = $"SELECT COUNT(id) AS quantity FROM Services WHERE CONVERT(VARCHAR, date, 103) LIKE '%{year}%'";
                    var command = new SqlCommand(sql, connection);
                    command.CommandText = sql;

                    return Convert.ToInt32(command.ExecuteScalar());
                }
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
                string sql = "DELETE FROM Services WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                command.CommandText = sql;
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
    }
}
