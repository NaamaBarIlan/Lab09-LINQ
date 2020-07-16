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
            DeserializeJson();
        }

        static public void DeserializeJson()
        {
            string rawData = File.ReadAllText("../../../Data.JSON");

            // From the newtonsoft docs:
            // Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
            JsonData = JsonConvert.DeserializeObject<Root>(rawData);
            int counter = 1;

            Console.WriteLine("All of the neighborhoods in the data list:");
            foreach (var item in JsonData.features)
            {
                Console.WriteLine($"{counter}. {item.properties.neighborhood}");
                counter++;
            }
        }
    }
 
}
