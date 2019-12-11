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
using System.Windows.Input;
using Windows.Networking.NetworkOperators;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Exe2009.Common;
using Park_and_Garden.Annotations;
using Newtonsoft.Json;

namespace Park_and_Garden.ViewModel 
{
    [Serializable]
     class HomeViewModel :INotifyPropertyChanged
    {
        private ProductsCatalog _productsCatalog;
        private Product _product;

        public HomeViewModel()
        {
            AddCommand = new RelayCommand(AddNewProduct);
            _productsCatalog = ProductsCatalog.Instance;
            IncreaseCommand = new RelayCommand(IncreaseProductStock);
            // Products.Add("Pots",Pots);
            // Products.Add("Goods", Goods);
            //  Products.Add("Plants", Plants);
            // Products.Add("Flowers", Flowers);

            /*AddToPoductDictionary("Goods");
             AddToPoductDictionary("Plants");
             AddToPoductDictionary("Pots");
             AddToPoductDictionary("Flowers");*/
        }


        public ICommand AddCommand { get; set; }
        public ICommand IncreaseCommand { get; set; }
        public ICommand DecreaseCommand { get; set; }

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


        private ObservableCollection<string> _optionForSize = new ObservableCollection<string>()
        {
            "Extra Small","Small","Medium", "Large", "Extra Large"
        };
        public ObservableCollection<string> optionForSize
        {
            get { return _optionForSize; }
            set { _optionForSize = value; }
        }

        private ObservableCollection<string> _optionForPicture = new ObservableCollection<string>()
        {
            "lily", "rose","lotus","aloe-vera", "anemone", "anthurium"
        };
        public ObservableCollection<string> optionForPicture
        {
            get { return _optionForPicture; }
            set { _optionForPicture = value; }
        }
        public string addproductname { get; set; }
        public string addproducttype { get; set; }
        public string addproductcost { get; set; }
        public string addproductstock { get; set; }
        public string addproductcolor { get; set; }
        public string addproductsize { get; set; }
        private string _addproducturl;

        public Dictionary<string, ObservableCollection<Product>> Products
        {
            get { return _productsCatalog.Products; }
            set { _productsCatalog.Products = value; }
        }

        public string addproducturl
        {
            get { return _addproducturl;}
            set { _addproducturl = "/Pictures/" + value + ".png"; OnPropertyChanged();}
        }

        public async void AddNewProduct()
        {
           await _productsCatalog.AddNewProduct(addproducturl,addproductname,addproductcost,addproducttype,addproductstock,addproductcolor,addproductsize);
        }

        public void IncreaseProductStock()
        {
            SelectedProduct.Stock++;
            OnPropertyChanged();
        }
       
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /*public void AddToPoductDictionary(string key)
        {
            foreach (var p in _products )
            {
                if (p.Key == key)
                {
                    Products.Add(key, p.Value);
                }
            }
        }*/
        
}
}
