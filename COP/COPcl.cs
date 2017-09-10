using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace cop
{
    public class COPcl
    {
        string name { get; set; }
        string surname { get; set; }
        int age { get; set; }
        int RoleId { get; set; }
        public bool login(string pass) { return true; }
        public void editProfile() { }
        public void changePass() { }
        
        public void showAttendance() { }//посмотреть уведомление о посещении
        public void sendAttendance()
        {
            string path = Directory.GetCurrentDirectory() + "\\XML\\student.xml";

            XmlDocument xdoc = new XmlDocument();

            xdoc.Load(path);
            XmlElement xRoot = xdoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                Console.WriteLine("{0}: {1}", xnode.Attributes[0].Name, xnode.Attributes[0].Value);
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "Name")
                        Console.WriteLine("{0}: {1}", childnode.Name, childnode.InnerText);
                    if (childnode.Name == "Surname")
                        Console.WriteLine("{0}: {1}", childnode.Name, childnode.InnerText);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Введите ID студента");
            string id = Console.ReadLine();


            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes[0].Value == id)
                {
                    if (xnode.SelectSingleNode("//Inbox") == null)
                    {
                        XmlElement inbox = xdoc.CreateElement("Inbox");
                        inbox.SetAttribute("InboxEmails", "0");
                        xnode.AppendChild(inbox);
                        xdoc.Save(path);
                    }
                    int emails = Convert.ToInt32(xnode.SelectSingleNode("//Inbox").Attributes[0].Value) + 1;
                    xnode.SelectSingleNode("//Inbox").Attributes[0].Value = Convert.ToString(emails);
                    XmlElement email = xdoc.CreateElement("Email");
                    Console.WriteLine("Введите текст уведомления");
                    email.InnerText = Console.ReadLine();
                    email.SetAttribute("Inboxfrom", "COP");
                    xnode.SelectSingleNode("//Inbox").AppendChild(email);
                }
                Console.WriteLine();
            }
            xdoc.Save(path);

        }//отправить это уведомление студенту
        public void selectStudent() { }//выбор студента для компании(bool)
        public void sendNotification()
        {
            string path = Directory.GetCurrentDirectory() + "\\XML\\student.xml";

            XmlDocument xdoc = new XmlDocument();

            xdoc.Load(path);
            XmlElement xRoot = xdoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                Console.WriteLine("{0}: {1}", xnode.Attributes[0].Name, xnode.Attributes[0].Value);
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "Name")
                        Console.WriteLine("{0}: {1}", childnode.Name, childnode.InnerText);
                    if (childnode.Name == "Surname")
                        Console.WriteLine("{0}: {1}", childnode.Name, childnode.InnerText);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Введите ID студента");
            string id = Console.ReadLine();

            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes[0].Value == id)
                {
                    if (xnode.SelectSingleNode("//Inbox") == null)
                    {
                        XmlElement inbox = xdoc.CreateElement("Inbox");
                        inbox.SetAttribute("InboxEmails", "0");
                        xnode.AppendChild(inbox);
                        xdoc.Save(path);
                    }
                    int emails = Convert.ToInt32(xnode.SelectSingleNode("//Inbox").Attributes[0].Value) + 1;
                    xnode.SelectSingleNode("//Inbox").Attributes[0].Value = Convert.ToString(emails);
                    XmlElement email = xdoc.CreateElement("Email");
                    Console.WriteLine("Введите текст уведомления");
                    email.InnerText = Console.ReadLine();
                    email.SetAttribute("Inboxfrom", "COP");
                    xnode.SelectSingleNode("//Inbox").AppendChild(email);
                }
                Console.WriteLine();
            }
            xdoc.Save(path);

        }//отправка уведомления студенту

    }
}
