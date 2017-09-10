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
        public void createRole()
        {
            Console.WriteLine("Выберите тип учетки для (1 cop / 2 студент)");
            string role = Console.ReadLine();

            switch (role)
            {
                default:
                    break;
                case "1":
                    {
                        string path = Directory.GetCurrentDirectory() + "\\XML\\cop.xml";
                        if (File.Exists(path))
                        {
                            #region добавляем в существующий
                            XmlDocument xdoc = new XmlDocument();
                            xdoc.Load(path);
                            XmlElement rootx = xdoc.DocumentElement;

                            Console.WriteLine("Введите имя cop");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите фамилию cop");
                            string sname = Console.ReadLine();
                            Console.WriteLine("Введите возраст cop");
                            string age = Console.ReadLine();
                            int id = Convert.ToInt32(rootx.LastChild.Attributes[0].Value) + 1;
                            Console.WriteLine("ID cop сгенерировано: {0}", id);
                            string pass = "123456789";
                            
                            XmlElement copx = xdoc.CreateElement("cop");
                            copx.SetAttribute("ID", Convert.ToString(id));
                            XmlElement namex = xdoc.CreateElement("Name");
                            namex.InnerText = name;
                            XmlElement snamex = xdoc.CreateElement("Surname");
                            snamex.InnerText = sname;
                            XmlElement agex = xdoc.CreateElement("Age");
                            agex.InnerText = age;
                            XmlElement passx = xdoc.CreateElement("Passsword");
                            passx.InnerText = pass;
                            XmlElement activationx = xdoc.CreateElement("Active");
                            activationx.InnerText = "false";


                            rootx.AppendChild(copx);
                            copx.AppendChild(namex);
                            copx.AppendChild(snamex);
                            copx.AppendChild(agex);
                            copx.AppendChild(passx);
                            copx.AppendChild(activationx);
                            
                            xdoc.AppendChild(rootx);

                            xdoc.Save(path);

                            Console.WriteLine("COP создан {0}, пароль поумолчанию 123456789");
                            #endregion
                        }
                        else
                        {
                            #region Создаем
                            if (!File.Exists(path))
                                Directory.CreateDirectory(path.Substring(0, path.LastIndexOf('\\')));
                            Console.WriteLine("Файла не существует. Создать?(да/нет)");
                            string choice = Console.ReadLine();
                            switch (choice)
                            {
                                default:
                                    break;
                                case "да":
                                    {
                                        #region
                                        Console.WriteLine("Введите имя cop");
                                        string name = Console.ReadLine();
                                        Console.WriteLine("Введите фамилию cop");
                                        string sname = Console.ReadLine();
                                        Console.WriteLine("Введите возраст cop");
                                        string age = Console.ReadLine();
                                        int id = 100000;
                                        Console.WriteLine("ID студента сгенерировано: {0}", id);
                                        
                                        string pass = "123456789";
                                        
                                        XmlDocument xdoc = new XmlDocument();
                                        XmlDeclaration xmldecl = xdoc.CreateXmlDeclaration("1.0", "utf-8", null);

                                        xdoc.AppendChild(xmldecl);

                                        XmlElement rootx = xdoc.CreateElement("COPS");
                                        XmlElement studentx = xdoc.CreateElement("cop");
                                        studentx.SetAttribute("ID", Convert.ToString(id));
                                        XmlElement namex = xdoc.CreateElement("Name");
                                        namex.InnerText = name;
                                        XmlElement snamex = xdoc.CreateElement("Surname");
                                        snamex.InnerText = sname;
                                        XmlElement agex = xdoc.CreateElement("Age");
                                        agex.InnerText = age;
                                        XmlElement passx = xdoc.CreateElement("Passsword");
                                        passx.InnerText = pass;
                                        XmlElement activationx = xdoc.CreateElement("Active");
                                        activationx.InnerText = "false";

                                        rootx.AppendChild(studentx);
                                        studentx.AppendChild(namex);
                                        studentx.AppendChild(snamex);
                                        studentx.AppendChild(agex);
                                        studentx.AppendChild(passx);
                                        studentx.AppendChild(activationx);

                                        xdoc.AppendChild(rootx);
                                        xdoc.Save(path);
                                        Console.WriteLine("COP создан {0}, пароль поумолчанию 123456789");
                                        #endregion
                                    }
                                    break;
                                case "нет": break;
                            }
                            #endregion
                        }
                    }
                    break;
                case "2":
                    {
                        string path = Directory.GetCurrentDirectory() + "\\XML\\student.xml";
                        if (File.Exists(path))
                        {
                            #region добавляем в существующий
                            XmlDocument xdoc = new XmlDocument();
                            xdoc.Load(path);
                            XmlElement rootx = xdoc.DocumentElement;

                            Console.WriteLine("Введите имя студента");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите фамилию студента");
                            string sname = Console.ReadLine();
                            Console.WriteLine("Введите возраст студента");
                            string age = Console.ReadLine();
                            int id = Convert.ToInt32(rootx.LastChild.Attributes[0].Value) + 1;
                            Console.WriteLine("ID студента сгенерировано: {0}", id);
                            Console.WriteLine("Введите путь до CV");
                            string pass = "123456789";
                            string pathCV = Console.ReadLine();
                            Console.WriteLine("Введите текст критерия 1");
                            string criteria1 = Console.ReadLine();
                            Console.WriteLine("Введите текст критерия 2");
                            string criteria2 = Console.ReadLine();
                            Console.WriteLine("Введите текст критерия 3");
                            string criteria3 = Console.ReadLine();


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
                            pathCVx.InnerText = pathCV;
                            XmlElement criteria1x = xdoc.CreateElement("Criteria1");
                            criteria1x.InnerText = criteria1;
                            XmlElement criteria2x = xdoc.CreateElement("Criteria2");
                            criteria2x.InnerText = criteria2;
                            XmlElement criteria3x = xdoc.CreateElement("Criteria3");
                            criteria3x.InnerText = criteria3;
                            XmlElement activationx = xdoc.CreateElement("Active");
                            activationx.InnerText = "false";


                            rootx.AppendChild(studentx);
                            studentx.AppendChild(namex);
                            studentx.AppendChild(snamex);
                            studentx.AppendChild(agex);
                            studentx.AppendChild(passx);
                            studentx.AppendChild(pathCVx);
                            studentx.AppendChild(activationx);
                            studentx.AppendChild(criteria1x);
                            studentx.AppendChild(criteria2x);
                            studentx.AppendChild(criteria3x);
                            xdoc.AppendChild(rootx);

                            xdoc.Save(path);

                            Console.WriteLine("Студент создан {0}, пароль поумолчанию 123456789");
                            #endregion
                        }
                        else
                        {
                            #region Создаем
                            if (!File.Exists(path))
                                Directory.CreateDirectory(path.Substring(0, path.LastIndexOf('\\')));
                            Console.WriteLine("Файла не существует. Создать?(да/нет)");
                            string choice = Console.ReadLine();
                            switch (choice)
                            {
                                default:
                                    break;
                                case "да":
                                    {
                                        #region
                                        Console.WriteLine("Введите имя студента");
                                        string name = Console.ReadLine();
                                        Console.WriteLine("Введите фамилию студента");
                                        string sname = Console.ReadLine();
                                        Console.WriteLine("Введите возраст студента");
                                        string age = Console.ReadLine();
                                        int id = 100000;
                                        Console.WriteLine("ID студента сгенерировано: {0}", id);
                                        Console.WriteLine("Введите путь до CV");
                                        string pass = "123456789";
                                        string pathCV = Console.ReadLine();
                                        Console.WriteLine("Введите текст критерия 1");
                                        string criteria1 = Console.ReadLine();
                                        Console.WriteLine("Введите текст критерия 2");
                                        string criteria2 = Console.ReadLine();
                                        Console.WriteLine("Введите текст критерия 3");
                                        string criteria3 = Console.ReadLine();

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
                                        XmlElement criteria1x = xdoc.CreateElement("Criteria1");
                                        criteria1x.InnerText = criteria1;
                                        XmlElement criteria2x = xdoc.CreateElement("Criteria2");
                                        criteria2x.InnerText = criteria2;
                                        XmlElement criteria3x = xdoc.CreateElement("Criteria3");
                                        criteria3x.InnerText = criteria3;

                                        rootx.AppendChild(studentx);
                                        studentx.AppendChild(namex);
                                        studentx.AppendChild(snamex);
                                        studentx.AppendChild(agex);
                                        studentx.AppendChild(passx);
                                        studentx.AppendChild(pathCVx);
                                        studentx.AppendChild(activationx);
                                        studentx.AppendChild(criteria1x);
                                        studentx.AppendChild(criteria2x);
                                        studentx.AppendChild(criteria3x);

                                        xdoc.AppendChild(rootx);
                                        xdoc.Save(path);
                                        Console.WriteLine("Студент создан {0}, пароль поумолчанию 123456789");
                                        #endregion
                                    }
                                    break;
                                case "нет": break;
                            }
                            #endregion
                        }
                    }
                    break;
            }
        }
        public void activateAccount()
        {
            Console.WriteLine("Выберите тип пользователя (1 студент / 2 cop(англ) / 3 Компания)");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    {
                        string path = Directory.GetCurrentDirectory() + "\\XML\\student.xml";

                        XmlDocument xdoc = new XmlDocument();

                        xdoc.Load(path);
                        XmlElement xRoot = xdoc.DocumentElement;
                        Console.WriteLine("1 активировать / 2 деактивировать?");

                        string active = Console.ReadLine();

                        if (active == "1")
                            active = "true";
                        else if (active == "2")
                            active = "false";

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
                        xRoot.SelectSingleNode("/Students/student[@ID='" + id + "']/Active").InnerText = active;
                        xdoc.Save(path);
                    }
                    break;
                case "2":
                    {

                    }
                    break;
                case "3":
                    {

                    }
                    break;
                default:
                    break;
            }
        }
        public void showCriteria()
        {
            Console.WriteLine("Выберите тип учетки для (1 компания / 2 cop (англ) / 3 студент)");
            string role = Console.ReadLine();
            switch (role)
            {
                default:
                    break;
                case "1": role = "\\company.xml"; break;
                case "2": role = "\\cop.xml"; break;
                case "3": role = "\\student.xml"; break;
            }
            string path = Directory.GetCurrentDirectory() + "\\XML\\" + role;

            XmlDocument xdoc = new XmlDocument();

            xdoc.Load(path);
            XmlElement xRoot = xdoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                Console.WriteLine("Тип учетки: {0}", xnode.Name);
                Console.WriteLine("{0}: {1}", xnode.Attributes[0].Name, xnode.Attributes[0].Value);
                foreach (XmlNode childnode in xnode.ChildNodes)
                    Console.WriteLine("{0}: {1}", childnode.Name, childnode.InnerText);

                Console.WriteLine();
            }
        }
        //   public string sendAttendance() { }// отпрвка на почту COPу о посещении компании
        public void acceptAttendance() { }
    }
}
