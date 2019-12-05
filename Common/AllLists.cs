using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Park_and_Garden.Model;

namespace Park_and_Garden.Common
{
    public class AllLists
    {
        static List<User> _users = new List<User>()
        {
            new User("Dominik", "dominik3000", "1234", 25693),
            new Admin("Andreea", "anndreeaagml", "givemelove", 91624580)
        };

        public static List<User> Users { get; set; }
    }
}
