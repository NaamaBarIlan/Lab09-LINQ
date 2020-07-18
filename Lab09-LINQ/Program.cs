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
            Console.WriteLine("Welcome to LINQ in Manhattan!");
            OutputAll();
            FilterData();
        }

        static public Root DeserializeJson()
        {
            string rawData = File.ReadAllText("../../../Data.JSON");

            // From the newtonsoft docs:
            // Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
            Root JsonData = JsonConvert.DeserializeObject<Root>(rawData);

            return JsonData;
        }

        static public void OutputAll()
        {
            Root JsonData = DeserializeJson();
            int counter = 1;

            Console.WriteLine("All of the neighborhoods in the data list:");

            var allNeighborhoods = from place in JsonData.features
                                   select place.properties.neighborhood;


            foreach (var neighborhood in allNeighborhoods)
            {
                Console.WriteLine($"{counter}. {neighborhood}");
                counter++;
            }

        }


        static public void FilterData()
        {
            Root JsonData = DeserializeJson();
            int counter = 1;

            Console.WriteLine("All of the neighborhoods that have names:");


            var allNeighborhoods = from place in JsonData.features
                                   where place.properties.neighborhood != ""
                                   select place.properties.neighborhood;

            foreach (var neighborhood in allNeighborhoods)
            {
                Console.WriteLine($"{counter}. {neighborhood}");
                counter++;
            }


        }
    }
}
