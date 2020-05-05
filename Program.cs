using System;
using System.Collections.Generic;
using System.Threading;
/* Данное домашнее задание оказалось для меня очень трудным, потом что
в процессе работы я столкнулась с кучей-кучей проблем, возможно это видно из моего
постоянного переделывания кода. Перечислю некоторые из них
1) Одной из больших глупостей было то, что я не 
поискав как следует ответ на вопрос: Как использовать статическую переменную из Program.cs в 
реализации классов в Classes.cs, я очень усложнила себе работу, так как
в каждый метод добавлла мой статичный объект. Описав все функции
и столкнувшись с проблемой использования ref в потоке(что запрещено), я полезла искать
решение в гитхабе одного из тех кто уже сдал дз(Спасибо Рамзу Назарову), и поняла как
обращаться к статичному объекту через Program.Object.
2) По окончанию написания кода я поняла что использовала слишком длинные
названия переменных, что в конечном итоге сделало мой год ооочень тяжёлым для чтения
но для исправления этого у меня не отсалось никаких эмоциональных сил, просто 
поняла что в будущем надо придумывать более локаничные названия переменным и методам
3) Так как данное ДЗ я сдавала не в срок, то постаралась максимально продумать
и протестировать ошибки в каждом пункте. И так и вышло: в написании каждой операции
(Insert, Update, Delete, ...) я делала больше 5-6 ошибок, что в общем-то очень полезно,
ведь теперь я выучила где и что находится в моём коде

Помимо перечисленного было куча мелких ошибок, которые с боем, но в конечном итоге решились
*/

namespace HW28._04
{
    class Program
    {
        public static List<Client> MainClientList = new List<Client>();
        static int LastId = 0;
        static void Main(string[] args)
        {
            Client client = new Client();
            bool command = true;
            decimal balance;
            int? age = null;
            string fname, lname, mname;   
            while(command)
            {
           //     if (Console.BackgroundColor != ConsoleColor.Gray) 
           //         Console.BackgroundColor = ConsoleColor.Gray;
                Console.WriteLine("Choose action: ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Insert client--1");
                Console.WriteLine("Update client--2");
                Console.WriteLine("Delete client--3");
                Console.WriteLine("Select by id --4");
                Console.WriteLine("Select all ----5");
                Console.WriteLine("Exit-----------6");
                Console.WriteLine("--------------------------------");
                int action = int.Parse(Console.ReadLine());
                TimerCallback callback = new TimerCallback((i)=>BalanceChangingStatistic());
                Timer timer = new Timer(callback, null, 0, 2000);
                switch(action)
                {
                    case 1:
                        Console.Write("FirstName: ");
                        fname = Console.ReadLine();
                        
                        Console.Write("LastName:");
                        lname = Console.ReadLine();

                        Console.Write("MiddleName:");
                        mname = Console.ReadLine();

                        Console.Write("Age:");
                        object s = Console.ReadLine();
                        if (s != null) age = s as int?;

                        Console.Write("Balance:   ");
                        balance = decimal.Parse(Console.ReadLine());
                        if (balance <= 0){
                                Console.WriteLine("---------------------------------");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect data of balance");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("---------------------------------");
                                break;
                            }
                        Client newclient = new Client(++LastId, fname, lname, mname, balance, age);                        
                        Thread InsertThread = new Thread(new ThreadStart(()=>Client.Insert(newclient)));
                        InsertThread.Start();
                        Thread.Sleep(400);
                        break;
                    case 2:
                        Console.Write("Choose id: ");
                        int id= int.Parse(Console.ReadLine());
                       
                        if (Client.SelectById(id))
                        {
                            Console.WriteLine("Write new data, if necessary, or click enter near field, if not.");
                            Console.Write("FirstName: ");
                            fname = Console.ReadLine();

                            Console.Write("LastName:");
                            lname = Console.ReadLine();

                            Console.Write("MiddleName:");
                            mname = Console.ReadLine();

                            Console.Write("Age:");
                            s = Console.ReadLine();
                            if (s != null) age = s as int?;
                            
                            Console.Write("Balance:   ");
                            balance = decimal.Parse(Console.ReadLine());
                            if (balance <= 0){
                                Console.WriteLine("---------------------------------");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect data of balance");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("---------------------------------");
                                break;
                            }
                            Client updatedClient = new Client(id, fname, lname, mname, balance, age);
                            Thread UpdateThread = new Thread(new ThreadStart(()=>{Client.UpdateById(updatedClient);}));
                            UpdateThread.Start();
                            Thread.Sleep(400);
                        }                    
                        break;
                    case 3:
                        Console.Write("Choose Id of client to delete: ");
                        id= int.Parse(Console.ReadLine());
                        
                        Thread DeleteThread = new Thread(new ThreadStart(()=>Client.Delete(id)));
                        DeleteThread.Start();         
                        Thread.Sleep(400);                                      
                        break;
                    case 4:
                        Console.Write("Choose id: ");
                        id= int.Parse(Console.ReadLine());
                        Thread SelectThread = new Thread(new ThreadStart(()=>Client.SelectById(id)));
                        SelectThread.Start();
                        Console.WriteLine("--------------------------------");
                        Thread.Sleep(400);
                        break;
                    case 5:
                        Thread SelectAllThread = new Thread(new ThreadStart(()=>Client.SelectAll()));
                        SelectAllThread.Start();
                        Thread.Sleep(400);
                        break;
                    case 6:
                        Console.WriteLine("Bye!");
                        Console.WriteLine("--------------------------------");
                        command = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong commad! Try again!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("---------------------------------");break;
                }
            }
        }
        public static void BalanceChangingStatistic()
        {
            bool balancechangestatus = false;
            char sign;
            decimal difference = 0;
            foreach(Client c in MainClientList)
            {
                if (c.PreviousBalance != -1)
                {
                    if (!balancechangestatus)
                    {
                        Console.WriteLine("Balance changings list:");
                        Console.WriteLine("|Id     |PrevBalance|Curbalance |Difference|");
                        Console.WriteLine("-------------------------------");
                        balancechangestatus = balancechangestatus = true;
                    }
                    Console.ForegroundColor = (c.PreviousBalance > c.CurrentBalance)? ConsoleColor.Red :ConsoleColor.Green; 
                    difference = Math.Abs(c.PreviousBalance - c.CurrentBalance);
                    sign = (c.PreviousBalance > c.CurrentBalance) ? '-' : '+';
                    Console.WriteLine($"{c.Id,-9} | {c.PreviousBalance,-5} | {c.CurrentBalance, -5}  | {sign} {difference,-5}");
                    c.PreviousBalance = -1;
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
    
}
