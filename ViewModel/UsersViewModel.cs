using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
            DomainObject();
            _selectedUser = null;
            _deletionCommand = new DeleteCommand(_userCatalog, this);
        }

        public void DomainObject()
        {
            foreach (var c in _userCatalog.Users)
            {
                _domainObject = c;
            }
        }

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
