using System;
using Lab09_LINQ.Classes;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Lab09_LINQ
{
    class Program
    {
        public static Root JsonData { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            OutputAll();
        }

        static public Root DeserializeJson()
        {
            string rawData = File.ReadAllText("../../../Data.JSON");

            // From the newtonsoft docs:
            // Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
            JsonData = JsonConvert.DeserializeObject<Root>(rawData);

            return JsonData;
        }

        static public void OutputAll()
        {
            JsonData = DeserializeJson();
            int counter = 1;

            Console.WriteLine("All of the neighborhoods in the data list:");

            var allNeighborhoods = from place in JsonData.features
                                   select place.properties.neighborhood;


            foreach (var item in JsonData.features)
            {
                Console.WriteLine($"{counter}. {item.properties.neighborhood}");
                counter++;
            }

        }

        /*
        static public void FilterData()
        {
            JsonData = DeserializeJson();
            // Filtering
            /*
            var filter  = from person in persons
                          where person.Age > 21
                          select new { person.FirstName, person.LastName };

        */
        }
 
}
