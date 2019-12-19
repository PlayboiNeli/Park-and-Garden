using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_and_Garden.Model
{
    //Made by Dominik János Haskó
    class Plant : Product
    {
        private string _size;
            public Plant(string name, int cost, int stock, string url, string size) : base(name, cost, stock,url)
            {

                Size = size;

            }

            public string Size { get; set; }
        
    }
}
