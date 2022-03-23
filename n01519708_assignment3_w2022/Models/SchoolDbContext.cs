using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n01519708_assignment3_w2022.Models
{
    public class SchoolDbContext
    {
        //assign values to create connection
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "schooldb"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        //create connection string by appending values
        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password
                    + "; convert zero datetime = True";
            }
        }

        /// <summary>
        /// Returns a connection to the blog database.
        /// </summary>
        /// <returns>A MySqlConnection Object</returns>
        public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}