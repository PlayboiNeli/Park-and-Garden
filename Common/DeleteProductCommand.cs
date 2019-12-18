using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Park_and_Garden.Model;
using Park_and_Garden.ViewModel;

namespace Park_and_Garden.Common
{
    class DeleteProductCommand : ICommand
    {
        //This part is not ready yet.

        private ProductsCatalog _products;
        private HomeViewModel _homeViewModel;

        public DeleteProductCommand(ProductsCatalog products, HomeViewModel homeViewModel)
        {
            _products = products;
            _homeViewModel = homeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           // _products.Delete(_homeViewModel.SelectedProduct.Name, _homeViewModel.SelectedProductDictionary);
            _products.SaveDomainObjects();
            _homeViewModel.SelectedProduct = null;
        }

        public event EventHandler CanExecuteChanged;
    }
}
