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
            
            
            
            Thread DeleteThread = new Thread(new ThreadStart(()=>{}));
            Thread SelectThread = new Thread(new ThreadStart(()=>{}));
            
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
                        age = int.Parse(Console.ReadLine());

                        Console.Write("Balance:   ");
                        balance = decimal.Parse(Console.ReadLine());

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
                            
                            Client updatedClient = new Client(id, fname, lname, mname, balance, age);
                            Thread UpdateThread = new Thread(new ThreadStart(()=>{Client.UpdateById(updatedClient,MainClientList);}));
                        }                    
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
