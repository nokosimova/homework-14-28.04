using System;
using System.Collections.Generic;
using Class;
using System.Threading;

namespace HW28._04
{
    class Program
    {
        static List<Client> MainClientList = new List<Client>();
        static void Main(string[] args)
        {
          //  Client newclient = new Client();
            ListandClient x = new ListandClient();
            bool command = true;
            int LastId = 0;
            decimal balance;
            string fname, lname, mname;
            
            Thread InsertThread = new Thread(new ThreadStart(()=>{
            }));
            Thread UpdateThread = new Thread(new ThreadStart(()=>{}));
            Thread DeleteThread = new Thread(new ThreadStart(()=>{}));
            Thread SelectThread = new Thread(new ThreadStart(()=>{})));
            
            while(command)
            {
                Console.WriteLine("Choose action: ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Insert client--1");
                Console.WriteLine("Update client--2");
                Console.WriteLine("Delete client--3");
                Console.WriteLine("Select by id --4");
                Console.WriteLine("Exit-----------5");
                int action = int.Parse(Console.ReadLine());
                
                switch(action)
                {
                    case 1:
                        Console.Write("FirstName: ");
                        fname = Console.ReadLine();

                        Console.Write("LastName:     ");
                        lname = Console.ReadLine();

                        Console.Write("MiddleName:");
                        mname = Console.ReadLine();

                        Console.Write("Age:");


                        Console.Write("Баланс:   ");
                        balance = decimal.Parse(Console.ReadLine());

                        Client newclient = new Client(++LastId, fname, lname, mname, balance);
                        x.client = newclient;
                        x.ClientList = MainClientList;
                        
                        InsertThread.Start(x);
                        break;
                    case 2:
                        Client updateclient = new Client();
                        Console.WriteLine("id клиента: ");
                     //   updateclient

                        Console.Write("Фамилия: ");
                        fname = Console.ReadLine();

                        Console.Write("Имя:     ");
                        lname = Console.ReadLine();

                        Console.Write("Отчество:");
                        mname = Console.ReadLine();

                        Console.Write("Баланс:   ");
                        balance = decimal.Parse(Console.ReadLine());

                        
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Console.WriteLine("Пока!");
                        command = false;
                        break;

                }
            }
        
        }
    }
    
}
