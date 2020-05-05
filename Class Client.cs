using System;
using System.Collections.Generic;


namespace HW28._04
{
public class Client
{
    public int Id{get; set;}
    public decimal CurrentBalance{get; set;}
    public decimal PreviousBalance {get; set;}
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public string MiddleName{get; set;}
    public int? Age{get; set;}
    
    public Client()
    {
        Id = 0;
        FirstName = null;
        LastName = null;
        MiddleName = null;
        CurrentBalance = -1;
        PreviousBalance  = -1;
        Age = null;
    }
    public Client(int id = 0, string firstname = null, string lastname = null, string midname = null, decimal Currentbalance = -1, int? age = null)
    {
        Id = id;
        FirstName = firstname;
        LastName = lastname;
        MiddleName = midname;
        CurrentBalance = Currentbalance;
        PreviousBalance  = -1;
        Age = age;
    }
    public static void Insert(object obj)
    {
        Client client = obj as Client;
        Program.MainClientList.Add(client);  
        Console.WriteLine("---------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Client was successfully inserted!");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("---------------------------------");
                                  
    }
    public static void UpdateById(object obj)
    {
        Client updatedClient = obj as Client;
        for(int i = 0; i < Program.MainClientList.Count; i++)
        {
            if (Program.MainClientList[i].Id == updatedClient.Id)
            {
                if (updatedClient.FirstName != null) Program.MainClientList[i].FirstName = updatedClient.FirstName;
                if (updatedClient.LastName != null) Program.MainClientList[i].LastName = updatedClient.LastName;
                if (updatedClient.MiddleName != null) Program.MainClientList[i].MiddleName = updatedClient.MiddleName;
                if (updatedClient.Age != null || updatedClient.Age > 0) Program.MainClientList[i].Age = updatedClient.Age;
                if (updatedClient.CurrentBalance != -1 && updatedClient.CurrentBalance >= 0)
                { 
                    if (Program.MainClientList[i].PreviousBalance == -1)
                        Program.MainClientList[i].PreviousBalance = Program.MainClientList[i].CurrentBalance;
                    Program.MainClientList[i].CurrentBalance = updatedClient.CurrentBalance;
                }
                Console.WriteLine("--------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Client was successfully updated!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("---------------------------------");
            }
        }
    }
    public static void Delete(object obj)
    {
        Client deletingClient = new Client();
        int ClientId = (int)obj;
        for (int i = 0; i < Program.MainClientList.Count; i++)
        {
            if (Program.MainClientList[i].Id == ClientId) 
            {
                Program.MainClientList.RemoveAt(i);
                Console.WriteLine("---------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Client was successfully deleted!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("---------------------------------");
            }
        }
    }
    public static bool SelectById(object obj)
    {
        bool clientExistStatus = false;
        int selectedClientId = (int)obj;
        foreach(Client c in Program.MainClientList)
        {
            if (c.Id == selectedClientId)
            {
                clientExistStatus = true;
                Console.Write("|id   |FIO                |Age     |CurrentBalance \n");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"{c.Id,-3} {c.FirstName+c.LastName+c.MiddleName} {c.Age,-5}{c.CurrentBalance,-15}");
                break;
            }
        }
        if (!clientExistStatus) Console.WriteLine("Error: No client with such id!");
        return clientExistStatus;
    }
    public static void SelectAll()
    {
        Console.Write("|id   |FIO                   |CurrentBalance \n");
        Console.WriteLine("----------------------------------------");
        foreach(Client c in Program.MainClientList)
            Console.WriteLine($"{c.Id,-3} {c.FirstName+c.LastName+c.MiddleName}  {c.Age}    {c.CurrentBalance,-5}");           
        Console.WriteLine("--------------------------------");
    }
}
}

/* Данное домашнее задание оказалось для меня очень трудным, потом что
в процессе работы я столкнулась с кучей-кучей проблем, возможно это видно из моего
постоянного переделывания кода. Перечислю некоторые из них
1) Одной из больших глупостей было то, что я не 
поискав как следует ответ на вопрос: Как использовать статическую переменную из Program.cs в 
реализации классов в Classes.cs, поэтому я очень усложнила себе работу.
2) По окончанию написания кода я поняла что использовала слишком длинные
названия переменных, что в конечном итоге сделало мой год ооочень тяжёлым для чтения
но для исправления этого у меня не отсалось никаких эмоциональных сил
3) Так как данное ДЗ я сдавала не в срок, то постаралась максимально продумать
и протестировать ошибки в каждом пункте. И так и вышло: в написании каждой операции
(Insert, Update, Delete, ...) я делала больше 5-6 ошибок, что в общем-то очень полезно,
ведь теперь я выучила где и что находится в моём коде
*/