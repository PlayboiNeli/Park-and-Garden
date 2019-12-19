using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;

namespace Park_and_Garden.Model
{
    public class UsersCatalog
    {
        //Made by Andreea Vasiliu

        private static ObservableCollection<User> _users = new ObservableCollection<User>()
        {
            new User("Dominik", "dominik3000", "1234", 25693),
            new Admin("Andreea", "anndreeaagml", "givemelove", 91624580),
            new User ("Leon", "neli", "neli", 91990473)
        };

        public ObservableCollection<User> Users => _users;

        public void AddUser(User c)
        {
            _users.Add(c);
        }

        public void Delete(string name)
        {
            var user = _users.FirstOrDefault(c => c.Name == name);
            _users.Remove(user);
        }
    }
}
