using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Exe2009.Common;
using Newtonsoft.Json;

namespace Park_and_Garden.Model
{
     class ProductsCatalog
    {
        private static ProductsCatalog _instance = null;
        private ObservableCollection<Product> _goods = new ObservableCollection<Product>();
        private ObservableCollection<Product> _pots = new ObservableCollection<Product>();
        private ObservableCollection<Product> _plants = new ObservableCollection<Product>();
        private ObservableCollection<Product> _flowers = new ObservableCollection<Product>();
        private Dictionary<string, ObservableCollection<Product>> _products = new Dictionary<string, ObservableCollection<Product>>();
        private const string ProductsData = "products.dat";
        private readonly StorageFolder _storageFolder = ApplicationData.Current.LocalFolder;


        //If I use singleton it  must be private so nobody can create a new object.
        private ProductsCatalog()
        {
            
        }

        public static ProductsCatalog Instance
        {
            get {
                if (_instance ==null)
                {
                    _instance =new ProductsCatalog();
                }

                return _instance;
            }
        }


        public Dictionary<string, ObservableCollection<Product>> Products
         {
             get { return _products; }
             set { _products = value; }
         }

         public ObservableCollection<Product> Goods
         {
             get { return _goods; }
             set { _goods = value; }
         }
         public ObservableCollection<Product> Pots
         {
             get { return _pots; }
             set { _pots = value; }
         }
         public ObservableCollection<Product> Plants
         {
             get { return _plants; }
             set { _plants = value; }
         }

         public ObservableCollection<Product> Flowers
         {
             get { return _flowers; }
             set { _flowers = value; }
         }




         public async Task AddNewProduct( string addproducturl, string addproductname, string addproductcost, string addproducttype, string addproductstock, string addproductcolor, string addproductsize)
         {
             
             if (addproducttype == "Pots")
             {
                 var product = new Pot(addproductname, Convert.ToInt32(addproductcost), Convert.ToInt32(addproductstock),
                     addproducturl, addproductcolor, addproductsize);
                if (!_products.ContainsKey(addproducttype))
                {
                    _products.Add(addproducttype, Pots);
                }
                else
                {
                    _products[addproducttype].Add(product);
                }

            }
             if (addproducttype == "Flowers")
             {
                var product = new Flower(addproductname, Convert.ToInt32(addproductcost), Convert.ToInt32(addproductstock),
                     addproducturl, addproductcolor, addproductsize);

                if (!_products.ContainsKey(addproducttype))
                {
                    _products.Add(addproducttype, Pots);
                }
                else
                {
                    _products[addproducttype].Add(product);
                }
            }
             if (addproducttype == "Plants")
             {
                 var product = new Plant(addproductname, Convert.ToInt32(addproductcost), Convert.ToInt32(addproductstock),
                     addproducturl, addproductcolor);
                
                 if (!_products.ContainsKey(addproducttype))
                 {
                     _products.Add(addproducttype, Pots);
                 }
                 else
                 {
                     _products[addproducttype].Add(product);
                 }
            }
             if (addproducttype == "Goods")
             { 
                var product = new Product(addproductname, Convert.ToInt32(addproductcost), Convert.ToInt32(addproductstock),
                     addproducturl);
                if (!_products.ContainsKey(addproducttype))
                {
                    _products.Add(addproducttype, Pots);
                }
                else
                {
                    _products[addproducttype].Add(product);
                }
            }

             SaveDomainObjects();
         }

        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }


        public async  Task SaveDomainObjects()
        {
            string json = JsonConvert.SerializeObject(_products);
            await FileIO.WriteTextAsync(await _storageFolder.CreateFileAsync(ProductsData, CreationCollisionOption.OpenIfExists), json);
        }
        public async Task LoadDomainObjects()
        {
            string products = await FileIO.ReadTextAsync(await _storageFolder.CreateFileAsync(ProductsData, CreationCollisionOption.OpenIfExists));
            _products = JsonConvert.DeserializeObject<Dictionary<string, ObservableCollection<Product>>>(products);
        }


        public override string ToString()
       {
           return base.ToString();
       }
    }
}
