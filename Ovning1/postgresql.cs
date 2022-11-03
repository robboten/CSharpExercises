using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Ovning1
{
    internal class postgresql
    {
        private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "csharp";
        private static string Password = "***";
        private static string Port = "5432";
        public static void dosql()
        {
            // Build connection string using parameters from portal
            //
            string connString =
            String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", Host, User, DBname, Port, Password);
            using (var conn = new NpgsqlConnection(connString))

            {
                Console.Out.WriteLine("Opening connection");
                conn.Open();

                using (var command = new NpgsqlCommand("DROP TABLE IF EXISTS employees", conn))
                {
                    command.ExecuteNonQuery();
                    Console.Out.WriteLine("Finished dropping table (if existed)");

                }

                using (var command = new NpgsqlCommand("CREATE TABLE employees (id serial PRIMARY KEY, name VARCHAR(50), salary INTEGER)", conn))
                {
                    command.ExecuteNonQuery();
                    Console.Out.WriteLine("Finished creating table");
                }

                using (var command = new NpgsqlCommand("INSERT INTO employees (name, salary) VALUES (@n1, @q1)", conn))
                {
                    command.Parameters.AddWithValue("n1", "Mike");
                    command.Parameters.AddWithValue("q1", 150);

                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
            }

            Console.WriteLine("Press RETURN to exit");
            Console.ReadLine();
        }

    }
}



