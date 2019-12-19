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
using Park_and_Garden.Common;

namespace Park_and_Garden.ViewModel 
{

    //Made by János Dominik Haskó

    [Serializable]
     class HomeViewModel :INotifyPropertyChanged
    {
        private ProductsCatalog _productsCatalog;
        private Product _product;
        private DeleteProductCommand _deleteCommand;
        public HomeViewModel()
        {
            AddCommand = new RelayCommand(AddNewProduct);
            _productsCatalog = ProductsCatalog.Instance;
            IncreaseCommand = new RelayCommand(IncreaseProductStock);
            DecreaseCommand = new RelayCommand(DecreaseProductStock);
            _deleteCommand = new DeleteProductCommand(_productsCatalog, this);
        }


        public ICommand AddCommand { get; set; }
        public ICommand IncreaseCommand { get; set; }
        public ICommand DecreaseCommand { get; set; }

        public DeleteProductCommand DeleteCommand
        {
            get { return _deleteCommand; }
            set { _deleteCommand = value; }
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
            "lily", "rose","lotus","aloe-vera", "anemone", "anthurium" , "pine","palm-tree","tulip","tree","oak","gift-box","cactus","cactus-2"
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
            _productsCatalog.SaveDomainObjects();
        }
        public void DecreaseProductStock()
        {
            if (SelectedProduct.Stock > 0)
            {
                SelectedProduct.Stock--;
                _productsCatalog.SaveDomainObjects();
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        
}
}
