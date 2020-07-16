using System;
using System.Collections.Generic;
using System.Text;

namespace Lab09_LINQ.Classes
{
    class Neighborhood
    {
        public string Name { get; set; }
        public string Borough { get; set; }
        public int Zip { get; set; }

        public Neighborhood(string name, int zip)
        {
            Name = name;
            Zip = zip;
        }

    }
}
