using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    interface IUser
    {
        string name { get; set; }
        string criteria1 { get; set; }
        int criteria2 { get; set; }
        bool criteria3 { get; set; }
        bool login(int id, int pass);
        void editProfile();
        void changePass();
    }
}
