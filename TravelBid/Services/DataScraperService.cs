using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace TravelBid.Services
    {
        public class DataScraperService
        {
        /*
            public static void Scrape(SqlConnection connection)
            {
                string serviceUrl = "https://www.datakick.org/api/items";

                //string serviceUrl = "http://www.ctabustracker.com/bustime/api/v2/getroutes?key=[APIKEY]&format=json";
                System.Net.WebRequest req = System.Net.WebRequest.Create(serviceUrl);
                System.Net.WebResponse response = req.GetResponse();
                System.IO.Stream s = response.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(s);
                Newtonsoft.Json.JsonTextReader jsonTextReader = new Newtonsoft.Json.JsonTextReader(sr);
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

                //DataKickObject[] result = serializer.Deserialize<DataKickObject[]>(jsonTextReader);
                
                connection.Open();
                var formats = result.Where(x => x.format != null).Select(x => x.format).Distinct();
                foreach (var format in formats)
                {
                    var scalarCommand = connection.CreateCommand();
                    scalarCommand.CommandText = "SELECT COUNT(*) FROM Categories WHERE Name = '" + format + "'";
                    int categoryCount = (int)scalarCommand.ExecuteScalar();
                    if (categoryCount == 0)
                    {
                        var categoryCommand = connection.CreateCommand();
                        categoryCommand.CommandText = "INSERT INTO Categories(Name) VALUES ('" + format + "')";
                        categoryCommand.ExecuteNonQuery();
                    }
                }

                foreach (var datakickObject in result)
                {
                    var command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO Products(Name, Price, Description) VALUES ('" + (datakickObject.name ?? "").Replace("'", "''") + "'," + 0.00m + ", '" + (datakickObject.author ?? "").Replace("'", "''") + "');SELECT SCOPE_IDENTITY();";
                    decimal newId = (decimal)command.ExecuteScalar();

                    if (datakickObject.format != null)
                    {
                        var productCategoryCommand = connection.CreateCommand();
                        productCategoryCommand.CommandText = "INSERT INTO ProductsCategories(ProductID, CategoryName) VALUES (" + newId + ", '" + datakickObject.format + "')";
                        productCategoryCommand.ExecuteNonQuery();
                    }
                }

                connection.Close();



            }
            */
        }
        
}
