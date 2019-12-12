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
using Park_and_Garden.View;

namespace Park_and_Garden.ViewModel
{
    public class UsersViewModel :INotifyPropertyChanged
    {
        private User _domainObject;
        private UsersCatalog _userCatalog;
        private User _selectedUser;
        private DeleteCommand _deletionCommand;
        private string _searchQuery;
        

        public UsersViewModel()
        {
            
               _userCatalog = new UsersCatalog();
               _selectedUser = null;
          //  LogInCommand = new RelayCommand(Login);
            AddContactCommand = new RelayCommand(AddContact);
            _deletionCommand = new DeleteCommand(_userCatalog, this);
        }
      //  public ICommand LogInCommand { get; set; }
        public ICommand AddContactCommand { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string Name { get; set; }
        public bool IsLogedIn { get; set; }
        public static bool IsAdmin { get; set; }

        public User SelectedContact
        {
            get => _selectedUser;

            set
            {
                _selectedUser = value;
                OnPropertyChanged();
                _deletionCommand.RaiseCanExecuteChanged();
            }
        }

        public string Search
        {
            get
            {
               var result = UsersCollection.FirstOrDefault(u => u.Name == _searchQuery);
               if (result !=null)
               {
                    return result.Name;
               }

               return "Search";
            }
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        public void AddContact()
        {
            _userCatalog.AddUser(new User(Name, Username, Password, PhoneNumber));
        }

        public bool Login(string username, string password)
        {

            //search for user in the list
            //if user exists then
            var contact = _userCatalog.Users.FirstOrDefault(c => c.Username == username);
            if (contact == null)
                IsLogedIn = false;
            else
            {
                IsLogedIn = contact.Password == password;

                IsAdmin = contact.IsAdmin;
            }

            return IsLogedIn;

        }

        


        public DeleteCommand DeletionCommand => _deletionCommand;

        public ObservableCollection<User> UsersCollection => _userCatalog.Users;


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
