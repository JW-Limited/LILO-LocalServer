using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace srvlocal_gui.LAB.HELPER.SQL
{
    internal class Handler
    {
        public Handler(string dataBase,string connectionSTR = "") 
        {
            if(connectionSTR != "") connectionString = connectionSTR;

            if (!File.Exists(dataBase))
            {
                CreateDatabaseIfNotExists(dataBase);
                CreateCustomersTableIfNotExists();
            }
        }

        public delegate void DatabaseDelegate();


        static string connectionString = "Data Source=C:\\Users\\joeva\\Documents\\GitHub\\LILO-LocalServer\\srvlocal\\srvlocalDB.db;Version=3;";

        static void CreateDatabaseIfNotExists(string dbFilePath)
        {
            if (!File.Exists(dbFilePath))
            {
                SQLiteConnection.CreateFile(dbFilePath);
                Console.WriteLine($"Database file created: {dbFilePath}");
            }
            else
            {
                Console.WriteLine($"Database file already exists: {dbFilePath}");
            }
        }

        static void CreateCustomersTableIfNotExists()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = @"CREATE TABLE IF NOT EXISTS customers (
                            Id INTEGER NOT NULL,
                            name TEXT NOT NULL,
                            email TEXT NULL,
                            password_hash TEXT NOT NULL,
                            password_unhashed TEXT,
                            CONSTRAINT PK_customers PRIMARY KEY (Id))"
                ;

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Customers table created or already exists.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }

        static bool InsertDataIntoCustomersTable(string log)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = @"INSERT INTO customers (Id, name, email, password_hash, password_unhashed)
                            VALUES (1, 'admin', 'ceo@jwlmt.com', 'd033e22ae348aeb5660fc2140aec35850c4da997', 'admin')"
                ;

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        log = ($"Rows affected: {rowsAffected}");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        log = ($"Error: {ex.Message}");
                        return false;
                    }
                }
            }
        }
    }
}
