using System;
using System.Collections.Generic;

namespace classes
{
public class Client
{
    int id{get; set;}
    decimal Balance{get; set;}
    string FirstName{get; set;}
    string LastName{get; set;}
    string MiddleName{get; set;}
    
    public void Insert(ref List<Client> ClientList)
    {
        Client newclient = new Client();

        newclient.id = this.id;
        newclient.Balance = this.Balance;
        newclient.FirstName = this.FirstName;
        newclient.LastName = this.LastName;
        newclient.MiddleName = this.MiddleName;

        ClientList.Add(newclient);
    }
    public void Update(ref Client client, string FirstName = null, string LastName = null,string MiddleName = null, decimal Balance = -1)
    {
        if (FirstName != null) client.FirstName = FirstName;
        if (LastName != null) client.LastName = LastName;
        if (MiddleName != null) client.MiddleName = MiddleName;
        if (Balance != -1 && Balance >= 0) client.Balance = Balance;
    }
    public void Delete(ref List<Client> ClientList)
    {
        ClientList.Remove(this);
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
