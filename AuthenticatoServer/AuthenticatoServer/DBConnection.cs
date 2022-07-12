using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AuthenticatoServer
{
    public class DBConnection
    {
        public SqlConnection? SQLConn { get; set; }

        public DBConnection()
        {
            try
            {
                SqlConnectionStringBuilder build = new();

                build.UserID = "sa";
                build.Password = "P13rlu1g1!";
                build.DataSource = @"192.168.10.6,1433\sql1";
                //build.IntegratedSecurity = true;
                build.InitialCatalog = "Northwind";

                using (SQLConn = new(build.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example\n");

                    SQLConn.Open();

                    //string sql = "SELECT name, collation_name FROM sys.databases";


                    //using (SqlCommand comm = new(sql, connection))
                    //{
                    //    using (SqlDataReader reader = comm.ExecuteReader())
                    //    {
                    //        while (reader.Read())
                    //        {
                    //            Console.WriteLine($"{reader.GetString(0)} {reader.GetString(1)}");
                    //        }
                    //    }

                    //}
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error {ex.ToString()}");

            }
        }

        public void AddDB(string name)
        {
            string fileName = Path.Combine("/var/opt/mssql/data/",name.ToUpper()+".mdf");
            string fileNameLog = Path.Combine("/var/opt/mssql/data/", name.ToUpper()+"_Log" + ".ldf");
            string logName = name + "log";
            //string databaseString = $"CREATE DATABASE {name} ON PRIMARY (NAME = MYDB, FILENAME = '{fileName}', SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
            //$"LOG ON (NAME=MYDB_LOG, FILENAME='{fileNameLog}', SIZE= 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%)";


            string databaseString = $"CREATE DATABASE {name} ON PRIMARY " +
             $"(NAME = {name+"data"}, " +
             $"FILENAME = '\\{fileName}', " +
             "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
             $"LOG ON (NAME = {logName}, " +
             $"FILENAME = '\\{fileNameLog}', " +
             "SIZE = 1MB, " +
             "MAXSIZE = 5MB, " +
             "FILEGROWTH = 10%)";

            SqlConnectionStringBuilder build = new();

            build.UserID = "sa";
            build.Password = "P13rlu1g1!";
            build.DataSource = @"192.168.10.6,1433\sql1";
            //build.IntegratedSecurity = true;
            build.InitialCatalog = "Northwind";

            SQLConn = new SqlConnection(build.ConnectionString);

            SqlCommand myCmd = new SqlCommand(databaseString, SQLConn);

            try
            {
                SQLConn?.Open();
                myCmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine($"{name} db not created");
            }
            finally
            {
                if(SQLConn.State == System.Data.ConnectionState.Open)
                {
                    SQLConn.Close();
                }
            }
        }

        public bool Stop()
        {
            if(SQLConn != null)
            {
                Console.WriteLine("Closing SQL Connection");

                try
                {
                    SQLConn.Close();
                    return true;
                }
                catch
                {
                    return false;
                }


            }

            return false;
        }
    }
}
