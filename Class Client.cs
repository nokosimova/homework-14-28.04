using System;
using System.Collections.Generic;

namespace classes
{
public class ListandClient
{
    public List<Client> ClientList{get;set;}
    public Client client{get;set;}
}
public class Client
{
    int id{get; set;}
    decimal Balance{get; set;}
    string FirstName{get; set;}
    string LastName{get; set;}
    string MiddleName{get; set;}
    
    public static void Insert(ref object obj)
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
    public static void Update(ref Client client, string FirstName = null, string LastName = null,string MiddleName = null, decimal Balance = -1)
    {
        if (FirstName != null) client.FirstName = FirstName;
        if (LastName != null) client.LastName = LastName;
        if (MiddleName != null) client.MiddleName = MiddleName;
        if (Balance != -1 && Balance >= 0) client.Balance = Balance;
    }
    public static void Delete(ref List<Client> ClientList, Client client)
    {
        ClientList.Remove(client);
    }
    public static Client Select(List<Client> ClientList, Client client)
    {
        Client ans = new Client();
        foreach (Client c in ClientList)
        {
            if (c == client) ans = c;
        }
        return ans;
    }
}
}
