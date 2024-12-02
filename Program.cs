using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPostgreSqlConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connString = "Server=localhost; Database=DataCamp_Courses; Port=5432; User Id=postgres; Password=123456";
            using (NpgsqlConnection connect = new NpgsqlConnection(connString))
            {
                connect.Open();
                using (NpgsqlCommand query = new NpgsqlCommand("select * from Learning", connect))
                {
                    using (NpgsqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string course = reader.GetString(1);
                            string instructor = reader.GetString(2);
                            int duration = reader.GetInt32(3);

                            Console.WriteLine($"{id} {course} {instructor} {duration}");
                        }
                    }
                 
                }
            }
  

          
 
        
        }
    }
}
