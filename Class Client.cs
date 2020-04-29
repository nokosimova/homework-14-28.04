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
    {}
    public void Update(ref Client client)
    {}
    public void Delete(ref Client client)
    {}
    public void Select(Client client)
    {}
}
}
