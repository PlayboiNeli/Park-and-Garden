using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Park_and_Garden.Model;

namespace Park_and_Garden.ViewModel
{
    //Made by Andreea Vasiliu
    public class DeleteCommand : ICommand
    {

        private UsersCatalog _catalog;
        private UsersViewModel _viewModel;


        public DeleteCommand(UsersCatalog catalog, UsersViewModel viewModel)
        {
            _catalog = catalog;
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.SelectedContact != null;
        }

        public void Execute(object parameter)
        {
            _catalog.Delete(_viewModel.SelectedContact.Name);
            _viewModel.SelectedContact = null;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}
