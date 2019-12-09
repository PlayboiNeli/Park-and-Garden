using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Park_and_Garden.Model;
using Park_and_Garden.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using Windows.Networking.NetworkOperators;
using Windows.UI.Xaml.Controls;
using Park_and_Garden.Annotations;
using Newtonsoft.Json;

namespace Park_and_Garden.ViewModel 
{
    [Serializable]
    class HomeViewModel :INotifyPropertyChanged
    {
        private Product _product;
        private const string ProductsData = "products.dat";
        private readonly StorageFolder _storageFolder = ApplicationData.Current.LocalFolder;
        private ObservableCollection<Product> _goods = new ObservableCollection<Product>()
        {
            new Product("Gift-box", 1500, 15, "/Pictures/gift-box.png"),
            new Product("Gift-box-Smaller", 1100, 19, "/Pictures/gift-box.png")
        };

        private ObservableCollection<Product> _pots = new ObservableCollection<Product>()
        {
            new Pot("Big Red Pot", 400, 3, "/Pictures/008-cactus.png", "Red", "XXL")
        };

        private ObservableCollection<Product> _plants = new ObservableCollection<Product>()
        {
            new Plant("Palm Tree", 25000, 5, "/Pictures/010-palm-tree-1.png","Large"),
            new Plant("Baobab", 37000, 2, "/Pictures/029-baobab.png","Small"),

        };
        private ObservableCollection<Product> _flowers = new ObservableCollection<Product>()
        {
        new Flower("Tulip", 300, 450, "/Pictures/041-tulip.png", "Red", "Big"),
        new Flower("Calla", 1100, 70, "/Pictures/031-calla.png", "White", "Medium"),
        new Flower("Rose", 450, 45, "/Pictures/001-rose.png", "Purple", "Pink")

        };




        private Dictionary<string, ObservableCollection<Product>> _products = new Dictionary<string, ObservableCollection<Product>>()
        {
        };

        public HomeViewModel()
        {
            

            Products.Add("Goods", Goods);
            Products.Add("Pots", Pots);
            Products.Add("Plants", Plants);
            Products.Add("Flowers", Flowers);
            

        }

        public Dictionary<string, ObservableCollection<Product>> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public ObservableCollection<Product> Goods
        {
            get { return _goods;}
            set { _goods = value; }
        } 
        public ObservableCollection<Product> Pots
        {
            get { return _pots;}
            set { _pots = value; }
        }
        public ObservableCollection<Product> Plants
        {
            get { return _plants;}
            set { _plants = value; }
        }

        public ObservableCollection<Product> Flowers
        {
            get { return _flowers;}
            set { _flowers = value; }
        }


        private KeyValuePair<string, ObservableCollection<Product>> _selectedProductDictionary;
        public KeyValuePair<string, ObservableCollection<Product>> SelectedProductDictionary
        {
            get { return _selectedProductDictionary; }
            set { _selectedProductDictionary = value; OnPropertyChanged(); }
        }

        private Product _selecetedProduct;
        public Product SelectedProduct
        {
            get { return _selecetedProduct; }
            set { _selecetedProduct = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
