using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace CPReferenceBuilder
{
    public class final
    {
        public List<category> categories { get; set; }
        public List<brand> brands { get; set; }

        public final()
        {
            categories = new List<category>();
            brands = new List<brand>();
        }
    }


    public class brand
    {
        public int d { get; set; }
        public string r { get; set; }
        public List<string> m { get; set; }

        public brand()
        {
            m = new List<string>();
        }
    }

    public class category
    {
        public int d { get; set; }
        public string r { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SqlCommand command, subcommand;
            SqlDataReader reader, subreader;
            SqlConnection connection, subconnection;
            
            using (connection =
                 new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            {
                command = new SqlCommand("SELECT * FROM Categories", connection);
                connection.Open();

                reader = command.ExecuteReader();

                List<category> categories = new List<category>();
                categories.Add(new category { d = -1, r = "-- select category --" });

                while (reader.Read())
                {
                    categories.Add(new category { d = int.Parse(reader["Id"].ToString()), r = reader["Name"].ToString() });
                }

                reader.Close();


                command = new SqlCommand("SELECT * FROM Brands", connection);
                
                reader = command.ExecuteReader();

                List<brand> brands = new List<brand>();

                brands.Add(new brand { d = -1, r = "-- select brand --" });

                while (reader.Read())
                {
                    List<string> models = new List<string>();
                    models.Add("-- select model --");
                    using (subconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
                    {
                        subcommand = new SqlCommand("SELECT * FROM Models WHERE BrandId = " + reader["Id"].ToString(), subconnection);
                        subconnection.Open();
                        subreader = subcommand.ExecuteReader();

                        while (subreader.Read())
                        {
                            models.Add(subreader["Name"].ToString());
                        }

                        subreader.Close();
                    }                    
                    
                                       
                    brands.Add(new brand { d = int.Parse(reader["Id"].ToString()), r = reader["Name"].ToString(), m = models  });
                }

                reader.Close();



                File.WriteAllText(ConfigurationManager.AppSettings["file"], JsonConvert.SerializeObject(new final {
                    categories = categories,
                    brands = brands
                }));


                connection.Close();


               
            }
        }
    }
}
