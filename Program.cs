using System;
using System.Collections.Generic;
using Class;
using System.Threading;

namespace HW28._04
{
    class Program
    {
        static List<Client> MainClientList = new List<Client>();
        static int LastId = 0;
        static void Main(string[] args)
        {
            bool command = true;
            decimal balance;
            int age;
            string fname, lname, mname;
            
            
            
           
            Thread SelectThread = new Thread(new ThreadStart(()=>{}));
            
            while(command)
            {
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
                Timer timer = new Timer(callback, null, 0, 1000);
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
                        age = int.Parse(Console.ReadLine());

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
                        Thread InsertThread = new Thread(new ThreadStart(()=>Client.Insert(newclient,MainClientList)));
                        break;
                    case 2:
                        Console.Write("Choose id: ");
                        int id= int.Parse(Console.ReadLine());

                        if (!Client.SelectById(id, MainClientList))
                            Console.WriteLine("Error: No client with such id!");
                        else
                        {
                            Console.WriteLine("Write new data, if necessary, or click enter near field, if not.");
                            Console.Write("FirstName: ");
                            fname = Console.ReadLine();

                            Console.Write("LastName:     ");
                            lname = Console.ReadLine();

                            Console.Write("MiddleName:");
                            mname = Console.ReadLine();

                            Console.Write("Age:");
                            age = int.Parse(Console.ReadLine());

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
                            Thread UpdateThread = new Thread(new ThreadStart(()=>{Client.UpdateById(updatedClient,MainClientList);}));
                        }                    
                        break;
                    case 3:
                        Console.Write("Choose Id of client to delete: ");
                        id= int.Parse(Console.ReadLine());

                        if (!Client.SelectById(id, MainClientList))
                            Console.WriteLine("Error: No client with such id!");
                        else 
                        { 
                            Thread DeleteThread = new Thread(new ThreadStart(()=>Client.Delete(id, MainClientList)));
                            Console.WriteLine($"Client with id {id} was deleted");
                        }                   
                        break;
                    case 4:
                        Console.Write("Choose id: ");
                        id= int.Parse(Console.ReadLine());

                        if (!Client.SelectById(id, MainClientList))
                            Console.WriteLine("Error: No client with such id!");
                        else
                        {
                            Thread DeleteThread = new Thread(new ThreadStart(()=>Client.SelectById(id, MainClientList)));
                            Console.WriteLine("--------------------------------");
                        }
                        break;
                    case 5:
                        Thread SelectAllThread = new Thread(new ThreadStart(()=>Client.SelectAll( MainClientList)));
                        Console.WriteLine("--------------------------------");
                        break;
                    case 6:
                        Console.WriteLine("Bye!");
                        Console.WriteLine("--------------------------------");
                        command = false;
                        break;
                    default:
                        Console.WriteLine("Error: Wrong command. Try again!");
                        Console.WriteLine("--------------------------------");
                        break;
                   

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
                if (balancechangestatus)
                {
                    Console.WriteLine("Balance changings list:");
                    Console.WriteLine("|Id     |PrevBalance|Curbalance |Difference|");
                    Console.WriteLine("-------------------------------");
                }
                if (c.PreviousBalance != -1)
                {
                    if (!balancechangestatus) balancechangestatus = true;

                    Console.ForegroundColor = (c.PreviousBalance > c.CurrentBalance)? ConsoleColor.Red :ConsoleColor.Green; 
                    difference = Math.Abs(c.PreviousBalance - c.CurrentBalance);
                    sign = (c.PreviousBalance > c.CurrentBalance) ? '-' : '+';
                    Console.WriteLine($"{c.Id,-9} {c.PreviousBalance,-5} {c.CurrentBalance, -5}{difference,-5}");
                    c.PreviousBalance = -1;
                }
            }
        }

    }
    
}
