using System;
using System.Collections.Generic;
using System.Text;

namespace Wpf_Classes
{
    class Toy
    {
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        private string Aisle;

        public Toy()
        {
            Manufacturer = string.Empty;
            Name = string.Empty;
            Price = 0;
            Image = string.Empty;
        }

        public string GetAisle()
        {
            string firstLetter;
            firstLetter = Manufacturer[0].ToString().ToUpper();
            string newPrice;
            newPrice = Price.ToString().Replace(".","").Replace("$","").Replace(",","");

            string aisle;
            aisle = firstLetter + newPrice;
            return aisle;

        }

        public override string ToString()
        {   
            return $"{Manufacturer} - {Name}";
        }
    }
}
