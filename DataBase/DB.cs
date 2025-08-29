using System.Data.SqlClient;

namespace DataBase
{
    public class DB
    {
        static public bool ExistsDataBase()
        {
            bool existsDataBase = false;

            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionStringMaster))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Sys.Databases WHERE name = 'dbSocialPromotions'", connection);
                try
                {
                    connection.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.Read())
                    {
                        existsDataBase = true;
                    }

                }
                catch
                {
                    throw;
                }
            }

            return existsDataBase;
        }

        static public void CreateTables()
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                string sql = "CREATE TABLE [dbo].[Employees] (" +
                "    [id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), " +
                "    [name] VARCHAR(200) NULL, " +
                "    [CPF] VARCHAR(MAX) NULL, " +
                "    [address] VARCHAR(200) NULL," +
                "    [phone] VARCHAR(20) NULL);" +

                "     CREATE TABLE [dbo].[Services] [id] INT IDENTITY (1, 1) NOT NULL," +
                "     [description] VARCHAR (MAX) NULL, " +
                "     [date] DATE NULL, " +
                "     [entry_time] TIME NULL, " +
                "     [departure_time] TIME NULL," +
                "     [number_of_overtime_hours] decimal(18,2) NULL, " +
                "     [abatement_date] DATE NULL, " +
                "     [number_of_hours_taken] decimal(18,2) NULL, " +
                "     [day_off_completed] TINYINT NULL, " +
                "     [employee_id] INT NOT NULL," +
                "     PRIMARY KEY CLUSTERED ([id] ASC)," +
                "     FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employees] ([id]) ON DELETE  CASCADE);";

                SqlCommand command = new SqlCommand(sql, connection);
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

        static public void CreateDatabase()
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionStringMaster))
            {
                string sql = "CREATE DATABASE dbSocialPromotions";
                SqlCommand command = new SqlCommand(sql, connection);
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