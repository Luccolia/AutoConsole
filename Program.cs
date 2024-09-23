using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoConsole
{
    public class Program
    {
        public static List<Cars> carlist = new List<Cars>();
        static Connection conn= new Connection();

        public static void feladat1(){
            conn.connection.Open();
            string sql = "SELECT * FROM `cars`";
            MySqlCommand cmd = new MySqlCommand(sql,conn.connection);

            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            
            do
            {
                Cars cars = new Cars();
                    cars.Id = dr.GetInt32(0);
                    cars.Brand = dr.GetString(1);
                    cars.Type = dr.GetString(2);
                    cars.Licence = dr.GetString(3);
                    cars.Date = dr.GetDateTime(4);

                    carlist.Add(cars);
            }
            while (dr.Read());

            dr.Close();
            conn.connection.Close();
        }

        static void Main(string[] args)
        {
            feladat1();
            foreach (var item in carlist)
            {
                Console.WriteLine($"elso feladat {item.Brand}, {item.Licence}");
            }
           
        }
    }
}
