using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Student
{
    public class Student: IUser
    {
        public string FIO { get; set; }
        public int RoleId { get; set; }
        public bool login()
        {
            return true;
        }
        public void editProfile()
        {

        }
        public void changePass()
        {

        }
        public void showCV() { }
        public void showAttendance() { }//просмотр посещений компаниями
        public void sendCV() { }//отправка cv COPу

    }
}
