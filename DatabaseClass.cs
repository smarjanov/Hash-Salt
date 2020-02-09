using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace TestingSM
{
    class DatabaseClass
    {
        string dbTable, conString, server, dbUser, dbPassword;
        SqlConnection con;
        

        public void ConnectToDB()
        {
            try
            {
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
                sqlBuilder.DataSource = "localhost";
                sqlBuilder.UserID = "sa";
                sqlBuilder.Password = "admin";
                sqlBuilder.InitialCatalog = "CRM";
                Console.WriteLine("Trying to connect...");

                using SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString);
                connection.Open();
                Console.WriteLine("Connected!");
            }

            catch(SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        void WriteToDB()
        {
            string custName, custLastName, custCity, custEmail, custPhoneNumber, custOIB;
            string sqlString = "INSERT INTO " + dbTable + "()";
        }
    }
}
