using System;
using System.Collections.Generic;
using HW28._04;

namespace Class
{

public class ListandClient
{
    public List<Client> ClientList{get;set;}
    public Client client{get;set;}
}

public class ListAndId
{
    public List<Client> ClientList{get;set;}
    public int id{get; set;}

}
public class Client
{
    int Id{get; set;}
    decimal Balance{get; set;}
    string FirstName{get; set;}
    string LastName{get; set;}
    string MiddleName{get; set;}
    int Age{get; set;}
    public Client()
    {
        Id = 0;
        FirstName = null;
        LastName = null;
        MiddleName = null;
        Balance = -1;
        Age = 0;
    }
    public Client(int id = 0, string firstname = null, string lastname = null, string midname = null, decimal balance = -1, int age = 0)
    {
        Id = id;
        FirstName = firstname;
        LastName = lastname;
        MiddleName = midname;
        Balance = balance;
    }
    public static void Insert(object obj, List<Client> MainList)
    {
        Client client = obj as Client;
        MainList.Add(client);            
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
                if (updatedClient.Balance != -1 && updatedClient.Balance >= 0) MainList[i].Balance = updatedClient.Balance;
                if (updatedClient.Age != 0 && updatedClient.Age > 0) MainList[i].Age = updatedClient.Age;
            }
        }
    }
    public static void Delete(object obj, List<Client> MainList)
    {
        Client deletingClient = obj as Client;
        MainList.Remove(deletingClient);
    }
    public static void Select(object obj, List<Client> MainList)
    {
        int selectedClientId = (int)obj;
        Client ans = new Client();
        foreach (Client c in MainList)
        {
            if (c.Id == selectedClientId)
            {
                Console.Write("|id   |FIO                |Age     |Balance \n");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"{c.Id,-3} {c.FirstName+c.LastName+c.MiddleName,-9} {c.Age,-5}{c.Balance,-15}");
            }
            break;
        }
    }
}
}
