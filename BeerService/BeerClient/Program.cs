using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Guest guest=new Guest(name);
            guest.JoinParty();
            guest.Run(10);
            guest.Leave();
            Console.ReadLine();
        }
    }
}
