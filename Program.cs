using System;
using System.Collections.Generic;
using classes;
using System.Threading;

namespace HW28._04
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Client> NewClientList = new List<Client>();
            Client newclient = new Client();
            ListandClient x = new ListandClient();
            x.client = newclient;
            x.ClientList = NewClientList;
            
            Thread InsertThread = new Thread(new ParameterizedThreadStart(Client.Insert));
            Thread UpdateThread = new Thread(new ParameterizedThreadStart(Client.Update));
            Thread DeleteThread = new Thread(new ParameterizedThreadStart(Client.Delete));
            Thread SelectThread = new Thread(new ParameterizedThreadStart(Client.Select));
            
            InsertThread.Start();
            
        
        }
    }
    
}
