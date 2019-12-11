using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.WebUI;
using Windows.UI.Xaml.Controls;
using Exe2009.Common;
using Park_and_Garden.Annotations;
using Park_and_Garden.Model;

namespace Park_and_Garden.ViewModel
{
    public class UsersViewModel :INotifyPropertyChanged
    {
        private User _domainObject;
        private UsersCatalog _userCatalog;
        private User _selectedUser;
        private DeleteCommand _deletionCommand;
        

        public UsersViewModel()
        {
            
               _userCatalog = new UsersCatalog();
               _selectedUser = null;
            LogInCommand = new RelayCommand(Login);
            _deletionCommand = new DeleteCommand(_userCatalog, this);
        }
        public ICommand LogInCommand { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public static bool IsLogedIn { get; set; }

        public User SelectedContact
        {
            get
            {
                return _selectedUser;
            }

            set
            {
                _selectedUser = value;
                OnPropertyChanged();
                _deletionCommand.RaiseCanExecuteChanged();
            }
        }

        public void Login()
        {

            //search for user in the list
            //if user exists then
            var contact = _userCatalog.Users.FirstOrDefault(c => c.Username == Username);
            if (contact == null)
                IsLogedIn = false;
            else {
                if (contact.Password == Password)
                    IsLogedIn = true;
                else IsLogedIn = false;

            }

        }


        public DeleteCommand DeletionCommand
        {
            get { return _deletionCommand; }
        }

        public ObservableCollection<User> ContactsCollection
        {
            get { return _userCatalog.Users; }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
