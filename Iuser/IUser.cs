using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


interface IUser
{
    string FIO { get; set; }
    int RoleId { get; set; }
    bool login();
    void editProfile();
    void changePass();

}

