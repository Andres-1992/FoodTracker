using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracker.Models
{
   public class Item
    {
        public IObservable<string> contains { get; set; }
        public string _id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public long ean { get; set; }
        public int energy { get; set; }
        public int carbs { get; set; }
        public int sodium { get; set; }
        public int fat { get; set; }
        public int satfat { get; set; }
        public int salt { get; set; }
        public int sugar { get; set; }
        public bool organic { get; set; }
        public bool fairtrade { get; set; }
        public bool eco { get; set; }
        public bool vegetarian { get; set; }
        public bool vegan { get; set; }
        public string healthnotes { get; set; }
        public int __v { get; set; }
    }
}
