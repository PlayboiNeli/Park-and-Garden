using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_and_Garden.Model
{
    class Product
    {
        private string _name;
        private int _cost;
        private int _stock;
        private string _url;
        public Product(string name, int cost, int stock, string url)
        {
            Name = name;
            Cost = cost;
            Stock = stock;
            Url = url;
        }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Stock { get; set; }
        public string Url { get; set; }
    }
}
