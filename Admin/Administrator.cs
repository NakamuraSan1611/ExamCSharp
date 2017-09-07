using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Admin
{
    public class Administrator
    {
        public void createStudent()
        {
            string path = Directory.GetCurrentDirectory() + "\\XML\\student.xml";
            //string temp = Path.Combine(, @"\\XML\\student.xml");
            if (File.Exists(path))
            {
                #region добавляем в существующий
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(path);
                XmlElement rootx = xdoc.DocumentElement;

                Random rand = new Random();

                Console.WriteLine("Введите имя студента");
                string name = Console.ReadLine();
                Console.WriteLine("Введите фамилию студента");
                string sname = Console.ReadLine();
                Console.WriteLine("Введите возраст студента");
                string age = Console.ReadLine();
                int id = rand.Next(0, 999999);
                Console.WriteLine("ID студента сгенерировано: {0}", id);
                Console.WriteLine("Введите путь до CV");
                string pass = "123456789";
                string pathCV = Console.ReadLine();

                XmlElement studentx = xdoc.CreateElement("student");
                studentx.SetAttribute("ID", Convert.ToString(id));
                XmlElement namex = xdoc.CreateElement("Name");
                namex.InnerText = name;
                XmlElement snamex = xdoc.CreateElement("Surname");
                snamex.InnerText = sname;
                XmlElement agex = xdoc.CreateElement("Age");
                agex.InnerText = age;
                
                XmlElement passx = xdoc.CreateElement("Passsword");
                passx.InnerText = pass;
                XmlElement pathCVx = xdoc.CreateElement("CVpath");

                XmlElement activationx = xdoc.CreateElement("Active");
                activationx.InnerText = "false";


                rootx.AppendChild(studentx);
                studentx.AppendChild(namex);
                studentx.AppendChild(snamex);
                studentx.AppendChild(agex);
                studentx.AppendChild(passx);
                studentx.AppendChild(pathCVx);
                studentx.AppendChild(activationx);
                xdoc.AppendChild(rootx);

                xdoc.Save(path);

                Console.WriteLine("Студент создан {0}, пароль поумолчанию 123456789");
                Console.ReadKey();
                #endregion
            }
            else
            {
                #region Создаем
                Console.WriteLine("Файла не существует. Создать?(да/нет)");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    default:
                        break;
                    case "да":
                        {
                            #region
                            Random rand = new Random();
                            Console.WriteLine("Введите имя студента");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите фамилию студента");
                            string sname = Console.ReadLine();
                            Console.WriteLine("Введите возраст студента");
                            string age = Console.ReadLine();
                            int id = rand.Next(0, 999999);
                            Console.WriteLine("ID студента сгенерировано: {0}", id);
                            Console.WriteLine("Введите путь до CV");
                            string pass = "123456789";
                            string pathCV = Console.ReadLine();

                            XmlDocument xdoc = new XmlDocument();
                            XmlDeclaration xmldecl = xdoc.CreateXmlDeclaration("1.0", "utf-8", null);

                            xdoc.AppendChild(xmldecl);

                            XmlElement rootx = xdoc.CreateElement("Students");
                            XmlElement studentx = xdoc.CreateElement("student");
                            studentx.SetAttribute("ID", Convert.ToString(id));
                            XmlElement namex = xdoc.CreateElement("Name");
                            namex.InnerText = name;
                            XmlElement snamex = xdoc.CreateElement("Surname");
                            snamex.InnerText = sname;
                            XmlElement agex = xdoc.CreateElement("Age");
                            agex.InnerText = age;

                            XmlElement passx = xdoc.CreateElement("Passsword");
                            passx.InnerText = pass;
                            XmlElement pathCVx = xdoc.CreateElement("CVpath");
                            XmlElement activationx = xdoc.CreateElement("Active");
                            activationx.InnerText = "false";

                            rootx.AppendChild(studentx);
                            studentx.AppendChild(namex);
                            studentx.AppendChild(snamex);
                            studentx.AppendChild(agex);

                            studentx.AppendChild(passx);
                            studentx.AppendChild(pathCVx);
                            studentx.AppendChild(activationx);

                            xdoc.AppendChild(rootx);
                            xdoc.Save(path);
                            Console.WriteLine("Студент создан {0}, пароль поумолчанию 123456789");
                            Console.ReadKey();
                            #endregion
                        }
                        break;
                    case "нет": break;
                }
                #endregion
            }

        }
        public void activateAccount()
        {
            Console.WriteLine("Выберите тип пользователя (студент / COP(англ) / Компания)");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "студент":
                    {
                        string path = Directory.GetCurrentDirectory() + "\\XML\\student.xml";
                        
                        XmlDocument xdoc = new XmlDocument();
                        
                        xdoc.Load(path);
                        XmlElement xRoot = xdoc.DocumentElement;
                        Console.WriteLine("Активировать или деактивировать?");

                        string active = Console.ReadLine();

                        if (active == "Активировать")
                            active = "true";
                        else if (active == "деактивировать")
                            active = "false";

                        Console.WriteLine("Введите ID студента");
                        string id = Console.ReadLine();
                        xRoot.SelectSingleNode("/Students/student[@ID='" + id + "']/Active").InnerText = active;
                        xdoc.Save(path);
                    }
                    break;
                case "COP":
                    {

                    }
                    break;
                case "Компания":
                    {

                    }
                    break;
                default:
                    break;
            }
        }

        public void showCriteria() { }
        //   public string sendAttendance() { }// отпрвка на почту COPу о посещении компании
        public void acceptAttendance() { }
        public void denyAttendance() { }
        
    }
}
