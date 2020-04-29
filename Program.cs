using System;
using System.Collections.Generic;
using classes;
using System.Threading;

namespace HW28._04
{
    class Program
    {
        static List<Client> NewClientList = new List<Client>();
        static void Main(string[] args)
        {
          //  Client newclient = new Client();
            ListandClient x = new ListandClient();
            bool command = true;
            int LastId = 0;
            decimal balance;
            string fname, lname, mname;
            
            Thread InsertThread = new Thread(new ParameterizedThreadStart(Client.Insert));
            Thread UpdateThread = new Thread(new ParameterizedThreadStart(Client.Update));
            Thread DeleteThread = new Thread(new ParameterizedThreadStart(Client.Delete));
            Thread SelectThread = new Thread(new ParameterizedThreadStart(Client.Select));
            
            while(command)
            {
                Console.WriteLine("Выберите действия: ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Добавить пользователя-1");
                Console.WriteLine("Обновить пользователя-2");
                Console.WriteLine("Удалить пользователя -3");
                Console.WriteLine("Выбрать по id --------4");
                Console.WriteLine("Выход ----------------5");
                int action = int.Parse(Console.ReadLine());
                
                switch(action)
                {
                    case 1:
                        Console.Write("Фамилия: ");
                        fname = Console.ReadLine();

                        Console.Write("Имя:     ");
                        lname = Console.ReadLine();

                        Console.Write("Отчество:");
                        mname = Console.ReadLine();

                        Console.Write("Баланс:   ");
                        balance = decimal.Parse(Console.ReadLine());

                        Client newclient = new Client(++LastId, fname, lname, mname, balance);
                        x.client = newclient;
                        x.ClientList = NewClientList;
                        
                        InsertThread.Start(x);
                        break;
                }
            }
        
        }
    }
    
}
