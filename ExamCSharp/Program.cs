using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin;
namespace ExamCSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Вырать профиль (1 admin / 2 user / 3 cop /4 student / 5 company)");
            string menu = Console.ReadLine();
            switch (menu)
            {
                default:
                    break;
                case "1":
                    {
                        #region Админ
                        Admin.Administrator admin1 = new Administrator();
                        Console.WriteLine("1. Активировать аккаунт\n" +
                            "2. Создать учетку\n3. Показать " +
                            "критерии приемлимости компании для процесса найма\n" +
                            "4. Принять или отклонить посещение компании");
                        string adminchoice = Console.ReadLine();
                        switch (adminchoice)
                        {
                            default:
                                break;
                            case "1": admin1.activateAccount(); break;
                            case "2": admin1.createRole(); break;
                            case "3": admin1.showCriteria(); break;
                            case "4": admin1.acceptAttendance(); break;
                        }
                        #endregion
                    }
                    break;
                case "2":
                    {

                    }
                    break;
                case "3":
                    {
                        cop.COPcl cop1 = new cop.COPcl();
                        Console.WriteLine("1. посмотреть уведомление о посещении компании\n" +
                            "2. Отправить уведомление о посещении студенту\n" +
                            "3. Выбор студента для компании" +
                            "4. Отправка уведомления студенту");
                        string copChoice = Console.ReadLine();
                        switch (copChoice)
                        {
                            default:
                                break;
                            case "1": { }break;
                            case "2": { cop1.sendAttendance(); } break;
                            case "3": { } break;
                            case "4": { cop1.sendNotification(); } break;
                        }
                        
                    }
                    break;
                case "4": { }break;
                case "5"://только для компании создается объект в мэйне т.к. только она может сама зарегаться
                    {
                        Company.Company company1 = new Company.Company();
                        company1.menu();//делегаты интерфейс и наследование тут
                    } break;
                    
            }

            Console.ReadKey();


        }
    }
}
