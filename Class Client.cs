using System;
using System.Collections.Generic;
using HW28._04;

namespace Class
{


public class Client
{
    public int Id{get; set;}
    public decimal CurrentBalance{get; set;}
    public decimal PreviousBalance {get; set;}
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public string MiddleName{get; set;}
    public int Age{get; set;}
    
    public Client()
    {
        Id = 0;
        FirstName = null;
        LastName = null;
        MiddleName = null;
        CurrentBalance = -1;
        PreviousBalance  = -1;
        Age = 0;
    }
    public Client(int id = 0, string firstname = null, string lastname = null, string midname = null, decimal Currentbalance = -1, int age = 0)
    {
        Id = id;
        FirstName = firstname;
        LastName = lastname;
        MiddleName = midname;
        CurrentBalance = Currentbalance;
        Age = age;
    }
    public static void Insert(object obj, List<Client> MainList)
    {
        Client client = obj as Client;
        MainList.Add(client);  
        Console.WriteLine("---------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Client was successfully inserted!");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("---------------------------------");
                                  
    }
    public static void UpdateById(object obj, List<Client> MainList)
    {
        Client updatedClient = obj as Client;
        for(int i = 0; i < MainList.Count; i++)
        {
            if (MainList[i].Id == updatedClient.Id)
            {
                if (updatedClient.FirstName != null) MainList[i].FirstName = updatedClient.FirstName;
                if (updatedClient.LastName != null) MainList[i].LastName = updatedClient.LastName;
                if (updatedClient.MiddleName != null) MainList[i].MiddleName = updatedClient.MiddleName;
                if (updatedClient.CurrentBalance != -1 && updatedClient.CurrentBalance >= 0) MainList[i].CurrentBalance = updatedClient.CurrentBalance;
                if (updatedClient.Age != 0 && updatedClient.Age > 0) MainList[i].Age = updatedClient.Age;
                if (updatedClient.CurrentBalance != -1 && updatedClient.CurrentBalance >= 0)
                { 
                    if (MainList[i].PreviousBalance != MainList[i].CurrentBalance)
                        MainList[i].PreviousBalance = MainList[i].CurrentBalance;
                    MainList[i].CurrentBalance = updatedClient.CurrentBalance;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Client was successfully updated!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("---------------------------------");
            }
        }
    }
    public static void Delete(object obj, List<Client> MainList)
    {
        Client deletingClient = obj as Client;
        MainList.Remove(deletingClient);
    }
    public static bool SelectById(object obj, List<Client> MainList)
    {
        bool clientExistStatus = false;
        int selectedClientId = (int)obj;
        for(int i = 0; i < MainList.Count; i++)
        {
            Client c = MainList[i];
            if (c.Id == selectedClientId)
            {
                clientExistStatus = true;
                Console.Write("|id   |FIO                |Age     |CurrentBalance \n");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"{c.Id,-3} {c.FirstName+c.LastName+c.MiddleName,-9} {c.Age,-5}{c.CurrentBalance,-15}");
            }
            break;
        }
        return clientExistStatus;
    }
    public static void SelectAll(List<Client> MainList)
    {
        Console.WriteLine($"COUNT:   {MainList.Count}");
        Console.Write("|id   |FIO                |Age     |CurrentBalance \n");
        Console.WriteLine("----------------------------------------");
        foreach(Client c in MainList)
            Console.WriteLine($"{c.Id,-3} {c.FirstName+c.LastName+c.MiddleName,-9} {c.Age,-5}{c.CurrentBalance,-15}");           
    }
}
}
