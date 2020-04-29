using System;
using System.Collections.Generic;

namespace classes
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
    int id{get; set;}
    decimal Balance{get; set;}
    string FirstName{get; set;}
    string LastName{get; set;}
    string MiddleName{get; set;}
    public Client()
    {
        id = 0;
        FirstName = null;
        LastName = null;
        MiddleName = null;
        Balance = -1;

    }
    public Client(int i, string f, string l, string m, decimal b)
    {
        id = i;
        FirstName = f;
        LastName = l;
        MiddleName = m;
        Balance = b;
    }
    public static void Insert(object obj)
    {
        ListandClient x = obj as ListandClient;
        Client newclient = new Client();
        newclient.id = x.client.id;
        newclient.Balance = x.client.Balance;
        newclient.FirstName = x.client.FirstName;
        newclient.LastName = x.client.LastName;
        newclient.MiddleName = x.client.MiddleName;

        x.ClientList.Add(newclient);
    }
    public static void Update(object obj)
    {
        ListandClient x = obj as ListandClient;
        Client ans = new Client();
        for(int i = 0; i < (x.ClientList).Count; i++)
        {
            if (x.ClientList[i].id == x.client.id)
            {
                if (x.client.FirstName != null) x.ClientList[i].FirstName = x.client.FirstName;
                if (x.client.LastName != null) x.ClientList[i].LastName = x.client.LastName;
                if (x.client.MiddleName != null) x.ClientList[i].MiddleName = x.client.MiddleName;
                if (x.client.Balance != -1 && x.client.Balance >= 0) x.ClientList[i].Balance = x.client.Balance;

            }
        }
    }
    public static void Delete(object obj)
    {
        ListandClient x = obj as ListandClient;
        x.ClientList.Remove(x.client);
    }
    public static void Select(object obj)
    {
        ListAndId x = obj as ListAndId;
        Client ans = new Client();
        foreach (Client c in x.ClientList)
        {
            if (c.id == x.id)
            {
                Console.WriteLine($"Client id: = {c.id}");
                Console.WriteLine($"FIO = {c.FirstName} {c.LastName} {c.MiddleName}");
                Console.WriteLine($"Balance: {c.Balance} сом");
            }
            break;
        }
    }
}
}
