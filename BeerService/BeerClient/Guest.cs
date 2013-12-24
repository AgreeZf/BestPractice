using System;
using System.ServiceModel;
using BeerClient.BeerInventoryGateway;

namespace BeerClient
{
    public class Guest:BeerInventoryGateway.BeerInventoryServiceCallback
    {
        private BeerInventoryGateway.BeerInventoryServiceClient _client;
        private string _name;
        public Guest(string name)
        {
            _name = name;
            _client = new BeerInventoryServiceClient(new InstanceContext(this), "WSDualHttpBinding_BeerInventoryService");
            //_client.Open();
        }
        public void JoinParty()
        {
            _client.JoinParty(Name);

        }
        public void Run(int number)
        {
            _client.MakeBeerRun(Name,10);
        }

        public void Leave()
        {
            _client.LeaveParty(Name);
            //_client.Close();
        }
        public string Name
        {
            get { return _name; }
        }

        public void NotifyJoinParty(string guestName)
        {
            Console.WriteLine("guest {0} Joined the party at {1}",guestName,DateTime.Now.ToLongDateString());
        }

        public void NotifyBeerChanged(string guestName, int numberofBeers)
        {
            if (numberofBeers>0)
            {
                Console.WriteLine("guest {0} run {1} beers",guestName,numberofBeers);
            }
        }

        public void NotifyLeaveParty(string guestName)
        {
            Console.WriteLine("guest {0} leaved the party",guestName);
            ;
        }
    }
}