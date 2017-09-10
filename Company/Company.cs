using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Company
{
    public class Company : IUser
    {
        delegate void choiceMenu();
        public string name { get; set; }
        private string password { get; set; }
        public string criteria1 { get; set; }
        public int criteria2 { get; set; }
        public bool criteria3 { get; set; }
        public bool login(int id, int pass)
        {
            string path = Directory.GetCurrentDirectory() + "\\XML\\company.xml";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(path);
            XmlElement xRoot = xdoc.DocumentElement;
            if (xRoot.SelectSingleNode("/Companies/company[@ID='" + id + "']/Passsword").InnerText == Convert.ToString(pass))
                return true;
            else
                return false;
        }
        public void menu()
        {
            choiceMenu menuDelegate;
            Console.WriteLine("1 Войти\n2 Регистрация");
            string choice = Console.ReadLine();
            switch (choice)
            {
                default:
                    break;
                case "1":
                    {
                        Console.WriteLine("Введите ID компании");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите пароль");
                        int pass = Convert.ToInt32(Console.ReadLine());
                        if (login(id, pass))
                        {
                            Console.WriteLine("1 Редактировать профиль\n" +
                                "2 Поменять пароль\n3 Выбор(тест) студента по критериям");
                            string loginChoice = Console.ReadLine();
                            switch (loginChoice)
                            {
                                default:
                                    break;
                                case "1": { menuDelegate = editProfile; menuDelegate.Invoke(); } break;
                                case "2": { menuDelegate = changePass; menuDelegate.Invoke(); } break;
                                case "3": { menuDelegate = test; menuDelegate.Invoke(); } break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверно введен ID/пароль");
                        }
                    }
                    break;
                case "2":
                    {
                        Company company1 = new Company();
                        Console.WriteLine("Введите имя компании");
                        company1.name = Console.ReadLine();
                        Console.WriteLine("Введите пароль");
                        company1.password = Console.ReadLine();
                        Console.WriteLine("Введите первый критерий (string)");
                        company1.criteria1 = Console.ReadLine();
                        Console.WriteLine("Введите первый критерий (int обязательно!)");
                        company1.criteria2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите первый критерий (bool (true/false) обязательно!)");
                        company1.criteria3 = Convert.ToBoolean(Console.ReadLine());
                        register(company1);
                    }
                    break;
            }
        }
        public void editProfile()
        {
            Console.WriteLine("Введите ID компании");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите пароль");
            int pass = Convert.ToInt32(Console.ReadLine());
            string path = Directory.GetCurrentDirectory() + "\\XML\\company.xml";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(path);
            XmlElement xRoot = xdoc.DocumentElement;
            if (xRoot.SelectSingleNode("/Companies/company[@ID='" + id + "']/Passsword").InnerText == Convert.ToString(pass))
            {
                Console.WriteLine("Введите новое имя компании");
                xRoot.SelectSingleNode("/Companies/company[@ID='" + id + "']/Name").InnerText = Console.ReadLine();
                Console.WriteLine("Введите новый критерий 1 (string)");
                xRoot.SelectSingleNode("/Companies/company[@ID='" + id + "']/Criteria1").InnerText = Console.ReadLine();
                Console.WriteLine("Введите новый критерий 2 (int)");
                xRoot.SelectSingleNode("/Companies/company[@ID='" + id + "']/Criteria2").InnerText = Console.ReadLine();
                Console.WriteLine("Введите новый критерий 1 (bool (true/false) )");
                xRoot.SelectSingleNode("/Companies/company[@ID='" + id + "']/Criteria3").InnerText = Console.ReadLine();
                xdoc.Save(path);
            }
            else
                Console.WriteLine("Неправильный ID/пароль");
        }
        public void changePass()
        {
            //если бы не делегат, не пришлось бы вводит второй раз, хотя обычно второй ввод иногда есть на какихнить сайтах)))
            Console.WriteLine("Введите ID компании");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите пароль");
            int pass = Convert.ToInt32(Console.ReadLine());
            string path = Directory.GetCurrentDirectory() + "\\XML\\company.xml";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(path);
            XmlElement xRoot = xdoc.DocumentElement;

            if (xRoot.SelectSingleNode("/Companies/company[@ID='" + id + "']/Passsword").InnerText == Convert.ToString(pass))
            {
                Console.WriteLine("Введите новый пароль");
                string newpass = Console.ReadLine();
                xRoot.SelectSingleNode("/Companies/company[@ID='" + id + "']/Passsword").InnerText = newpass;
                xdoc.Save(path);
            }
            else
                Console.WriteLine("Неправильный ID/пароль");

        }
        public void register(Company company)
        {
            string path = Directory.GetCurrentDirectory() + "\\XML\\company.xml";
            if (File.Exists(path))
            {
                #region добавляем в существующий
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(path);
                XmlElement rootx = xdoc.DocumentElement;

                int id = Convert.ToInt32(rootx.LastChild.Attributes[0].Value) + 1;
                Console.WriteLine("ID компании сгенерировано: {0}", id);


                XmlElement companyx = xdoc.CreateElement("company");
                companyx.SetAttribute("ID", Convert.ToString(id));
                XmlElement namex = xdoc.CreateElement("Name");
                namex.InnerText = company.name;
                XmlElement passx = xdoc.CreateElement("Passsword");
                passx.InnerText = company.password;
                XmlElement criteria1 = xdoc.CreateElement("Criteria1");
                criteria1.InnerText = company.criteria1;
                XmlElement criteria2 = xdoc.CreateElement("Criteria2");
                criteria2.InnerText = Convert.ToString(company.criteria2);
                XmlElement criteria3 = xdoc.CreateElement("Criteria3");
                criteria3.InnerText = Convert.ToString(company.criteria3);
                XmlElement activationx = xdoc.CreateElement("Active");
                activationx.InnerText = "true";


                rootx.AppendChild(companyx);
                companyx.AppendChild(namex);
                companyx.AppendChild(passx);
                companyx.AppendChild(activationx);
                companyx.AppendChild(criteria1);
                companyx.AppendChild(criteria2);
                companyx.AppendChild(criteria3);
                xdoc.AppendChild(rootx);

                xdoc.Save(path);

                Console.WriteLine("Компания зарегистрирована {0}, пароль {1}", company.name, company.password);
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
                            int id = 100000;
                            Console.WriteLine("ID компании сгенерировано: {0}", id);


                            XmlDocument xdoc = new XmlDocument();
                            XmlDeclaration xmldecl = xdoc.CreateXmlDeclaration("1.0", "utf-8", null);

                            xdoc.AppendChild(xmldecl);

                            XmlElement rootx = xdoc.CreateElement("Companies");
                            XmlElement companyx = xdoc.CreateElement("company");
                            companyx.SetAttribute("ID", Convert.ToString(id));
                            XmlElement namex = xdoc.CreateElement("Name");
                            namex.InnerText = company.name;
                            XmlElement passx = xdoc.CreateElement("Passsword");
                            passx.InnerText = company.password;
                            XmlElement criteria1 = xdoc.CreateElement("Criteria1");
                            criteria1.InnerText = company.criteria1;
                            XmlElement criteria2 = xdoc.CreateElement("Criteria2");
                            criteria2.InnerText = Convert.ToString(company.criteria2);
                            XmlElement criteria3 = xdoc.CreateElement("Criteria3");
                            criteria3.InnerText = Convert.ToString(company.criteria3);
                            XmlElement activationx = xdoc.CreateElement("Active");
                            activationx.InnerText = "true";

                            rootx.AppendChild(companyx);
                            companyx.AppendChild(namex);
                            companyx.AppendChild(passx);
                            companyx.AppendChild(activationx);
                            companyx.AppendChild(criteria1);
                            companyx.AppendChild(criteria2);
                            companyx.AppendChild(criteria3);
                            xdoc.AppendChild(rootx);
                            xdoc.Save(path);
                            Console.WriteLine("Компания зарегистрирована {0}, пароль {1}", company.name, company.password);
                            #endregion
                        }
                        break;
                    case "нет": break;
                }
                #endregion
            }
        }
        public void test() { }//тест студента по критериям
    }
}
