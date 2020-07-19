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
            RemoveData();
        }

        /// <summary>
        /// This method brings in data from the external JSON file and deserializes it using the newtonsoft JsonConvert.
        /// </summary>
        /// <returns>A root object of converted data in C# format</returns>
        static public Root DeserializeJson()
        {
            string rawData = File.ReadAllText("../../../Data.JSON");

            // From the newtonsoft docs:
            // Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
            Root JsonData = JsonConvert.DeserializeObject<Root>(rawData);

            return JsonData;
        }

        /// <summary>
        /// This method uses the output of the DeserializeJson method and a LINQ Query 
        /// to output to the console the names of all of the Manhattan neighborhoods in the external JSON file. 
        /// </summary>
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
            Console.WriteLine("^ That was all of the neighborhoods in the data list");
        }

        /// <summary>
        /// This method uses the output of the DeserializeJson method and a LINQ Query 
        /// to filter the data and output to the console only the Manhattan neighborhoods
        /// that have names in the external JSON file.
        /// </summary>
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
            Console.WriteLine("^ That was all of the neighborhoods that have names");

        }

        /// <summary>
        /// This method uses the output of the DeserializeJson method and a LINQ Query 
        /// to remove any duplicates from the data and output to the console only 
        /// the unique Manhattan neighborhood in the external JSON file.
        /// </summary>
        static public void RemoveData()
        {
            Root JsonData = DeserializeJson();
            int counter = 1;

            Console.WriteLine("Removed duplicates from all of the neighborhoods that have names:");

            var allNeighborhoods = (from place in JsonData.features
                                   where place.properties.neighborhood != ""
                                   select place.properties.neighborhood).Distinct();

            foreach (var neighborhood in allNeighborhoods)
            {
                Console.WriteLine($"{counter}. {neighborhood}");
                counter++;
            }
            Console.WriteLine("^ That was the filtered data without the duplicates");
        }

        static public void ReadFilterAndRemove()
        {
            Root JsonData = DeserializeJson();
            int counter = 1;

            Console.WriteLine("Removed duplicates from all of the neighborhoods that have names:");

            var allNeighborhoods = (from place in JsonData.features
                                    where place.properties.neighborhood != ""
                                    select place.properties.neighborhood).Distinct();

            foreach (var neighborhood in allNeighborhoods)
            {
                Console.WriteLine($"{counter}. {neighborhood}");
                counter++;
            }
            Console.WriteLine("^ That was the filtered data without the duplicates");
        }
    }
}
